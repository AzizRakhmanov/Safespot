using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.UserDto;

namespace Safespot.Controllers
{
    [Authorize]
    public class UserRegistrationController : Controller
    {
        private readonly IRepository<User> _repository;
        public UserRegistrationController(IRepository<User> repository)
        {
            this._repository = repository;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForCreationDto model)
        {
            var IsValidUser = await this._repository.SelectAsync(p => p.Password == model.Password);

            if (IsValidUser != null)
            {

                return RedirectToAction("Index", "Employees");
            }

            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

    }
}
