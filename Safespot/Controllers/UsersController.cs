using Microsoft.AspNetCore.Mvc;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.UserDto;

namespace Safespot.Controllers
{
    ////[Authorize]
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersController : Controller
    {
        private readonly IRepository<User> _repository;

        public UsersController(IRepository<User> repository)
        {
            this._repository = repository;
        }

        public IActionResult Login(UserForLoginDto dto)
        {

            return View();
        }
    }
}
