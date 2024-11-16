using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ParkingZone;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Controllers
{
    [Route("api/[controller]")]
    public class AdminParkingZoneController : Controller
    {
        private readonly IAdminParkingZoneService _adminParkingZoneService;
        private readonly IMapper _mapper;
        public AdminParkingZoneController(
            IAdminParkingZoneService adminParkingZoneService,
            IMapper mapper)
        {
            this._adminParkingZoneService = adminParkingZoneService;
            this._mapper = mapper;
        }

        /// <summary>
        /// takes all ParkingZones from database and returns back to the user
        /// </summary>
        /// <returns></returns>
        [Route("AllParkingZones")]
        [HttpGet]
        public async Task<IActionResult> AllParkingZones()
        {
            var all = await this._adminParkingZoneService.RetrieveAllAsync();

            return View(all);
        }

        [Route("Create")]
        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public async ValueTask<IActionResult> Create(ParkingZoneForDetailsDto dto)
        {
            if (ModelState.IsValid)
            {
                ParkingZoneForCreationDto parkingZoneForCreationDto =
                    new ParkingZoneForCreationDto()
                    {
                        Id = new Guid(),
                        Name = dto.Name,
                        FreeSlot = dto.FreeSlot,
                        EconomSlot = dto.EconomSlot,
                        BusinessSlot = dto.BusinessSlot,
                        AddressId = new Guid(),
                        Addresses = new Address()
                        {
                            Id = dto.AddressId,
                            Country = dto.Country,
                            Region = dto.Region,
                            City = dto.District,
                            CreatedAt = DateTime.Now,
                            GoogleMapUrl = dto.GoogleMapUrl
                        }
                    };
                var result = await this._adminParkingZoneService.AddAsync(parkingZoneForCreationDto);
                return View();
            }
            return View(dto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Details")]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
                return BadRequest();

            var result = await this._adminParkingZoneService.RetrieveParkingZoneDetails(id);

            return View(result);
        }

        /// <summary>
        /// removes the entity with given id from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._adminParkingZoneService.RemoveAsync(id);
            return RedirectToAction("AllParkingZones");
        }

        /// <summary>
        /// gets the ParkingZoneForCreationDto from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var @object = await _adminParkingZoneService.RetrieveAsync(id);
            if (@object == null) return NotFound();

            var result = this._mapper.Map<ParkingZoneForCreationDto>(@object);

            return View(result);
        }

        /// <summary>
        /// updates the ParkingZoneResultDto from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParkingZoneForResultDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the view with the current data if validation fails.
            }

            try
            {
                var creationDto = this._mapper.Map<ParkingZoneForCreationDto>(model);
                await this._adminParkingZoneService.UpdateAsync(creationDto);
                return RedirectToAction("AllParkingZones"); // Redirect to a list or confirmation page after successful save.
            }
            catch (Exception ex)
            {
                ModelState.AddModelError($"", $"{ex.Message}\n {ex.InnerException} Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(model);
            }
        }

    }
}
