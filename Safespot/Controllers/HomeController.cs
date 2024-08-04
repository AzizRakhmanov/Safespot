using Microsoft.AspNetCore.Mvc;
using Safespot.Data.IRepositories;
using Safespot.Models;
using Safespot.Models.Entities;
using System.Diagnostics;

namespace Safespot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User> repository;

        public HomeController(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index(User user)
        {
            if (ModelState.IsValid)
            {
                await this.repository.InsertAsync(user);
            }
            return View();
        }

        public async Task<IActionResult> SubmitForm(User user)
        {
            if (ModelState.IsValid)
            {
                await this.repository.InsertAsync(user);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
