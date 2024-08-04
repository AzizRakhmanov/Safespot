using Microsoft.AspNetCore.Mvc;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.Extentions;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Controllers
{
    public class ParkingZoneAdminController : Controller
    {
        private readonly IAdminParkingZoneService _service;

        public ParkingZoneAdminController(IAdminParkingZoneService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> AllParkingZones(PaginationParams @params)
        {
            @params.PageIndex = 2;
            @params.PageSize = 2;
            var all = await this._service.RetrieveAllAsync(@params);

            return View(all);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var parkingZoneForResultDto = await this._service.RetrieveAsync(id);

            return View(parkingZoneForResultDto);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(ParkingZoneForCreationDto dto)
        {
            var result = await this._service.AddAsync(dto);

            return View(result);
        }



        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, ParkingZoneForCreationDto dto)
        {
            var result = await this._service.UpdateAsync(id, dto);

            return View(result);
        }
    }
}
