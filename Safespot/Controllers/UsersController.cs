using Microsoft.AspNetCore.Mvc;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.Authentication;

namespace Safespot.Controllers
{
    ////[Authorize]
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersController : Controller
    {
        private readonly IJwtManagerRepository _jwtManagerRepository;
        private readonly IRepository<User> _repository;
        public UsersController(
            IJwtManagerRepository jwtManagerRepository,
            IRepository<User> repository)
        {
            this._jwtManagerRepository = jwtManagerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var all = new List<User>()
            {
                new User()   {
                    Id = Guid.NewGuid(),
                    FirstName = "Aziz",
                    LastName = "Rakhmanov",
                    BirthDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Role = UserRole.Admin
                }};


            return View(all);
        }

        [HttpPost]
        public IActionResult Authenticate(Users usersdata)
        {
            //var user = await this._repository.SelectAsync(p => p.Password == usersdata.Password);
            //if()
            //var token = this._jwtManagerRepository.Authenticate(usersdata);

            ////if (token == null) {
            ////    return Unauthorized();
            //}
            return View();

        }

    }
}
