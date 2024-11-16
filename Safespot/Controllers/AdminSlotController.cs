using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Safespot.Models.Entities;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Controllers
{
    public class AdminSlotController : Controller
    {
        private readonly IAdminSlotService _adminSlotService;
        private readonly IMapper mapper;
        public AdminSlotController(
            IAdminSlotService adminSlotService,
            IMapper mapper)
        {
            this._adminSlotService = adminSlotService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AllSlots(SlotCategory slotCategory)
        {
            var all = await this._adminSlotService.RetrieveAllAsync(slotCategory);
            return View(all);
        }
    }
}
