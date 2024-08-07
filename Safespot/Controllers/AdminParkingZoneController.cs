using Microsoft.AspNetCore.Mvc;
using Safespot.Service.DTO.ParkingZone;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.Exceptions;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Controllers
{
    public class AdminParkingZoneController : Controller
    {
        private readonly IAdminParkingZoneService _adminParkingZoneService;

        public AdminParkingZoneController(IAdminParkingZoneService adminParkingZoneService)
        {
            this._adminParkingZoneService = adminParkingZoneService;
        }

        [HttpGet]
        public async Task<IActionResult> AllParkingZones()
        {
            var all = await this._adminParkingZoneService.RetrieveAllAsync();

            return View(all);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(ParkingZoneForCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await this._adminParkingZoneService.AddAsync(dto);
                return View();
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
                return BadRequest();

            var result =  await this._adminParkingZoneService.RetrieveParkingZoneDetails(id);

            return View(result);
        }


        [HttpDelete]
        public async ValueTask<IActionResult> Delete(Guid id)
        {
            var result = await this._adminParkingZoneService.RemoveAsync(id);
            return RedirectToAction("AllParkingZones");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ParkingZoneForCreationDto dto)
        {
            if(id == null)
                return BadRequest();

           var result = await this._adminParkingZoneService.UpdateAsync(id,dto);

            return View(result);
        }

    }
}
