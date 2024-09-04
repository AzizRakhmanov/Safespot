using Microsoft.AspNetCore.Mvc;
using Safespot.Models;
using Safespot.Service.DTO.UserDto;
using Safespot.Service.Services.UserService;

namespace Safespot.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: UserController
        public async Task<ActionResult> AllUsers()
        {  
               return View(await this._userService.AllUsersAsync()); 
        }
        

        //// GET: UserController/Details/
        //public async Task<ActionResult> Details(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return null;
        //    }
        //    UserForResultDto user = await this._userService.RetrieveAsync(id);
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    return View(user);
        //}

        // GET: UserController/Create
        [Route("Create")]
        [HttpGet]
        public ActionResult Create(Guid id)
        {
            return View();
        }

        // POST: UserController/Create
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserForCreationDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._userService.AddAsync(dto);

                return RedirectToAction("AllUsers");
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                var user = await this._userService.RetrieveAsync(id);
                
                return View(user);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UserForCreationDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }
                var dd = await this._userService.EditAsync(dto);

                return RedirectToAction("AllUsers");
            }
            catch
            {
                return View();
            }
        }

        [Route("Delete")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await this._userService.DeleteAsync(id);

            return RedirectToAction("AllUsers");
        }

/*        // GET: UserController/Delete/5
        [Route("Delete")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var user = await this._userService.RetrieveAsync(id);
                return View();
            }
            catch(Exception ex) 
            {
                return View("Error");
            }
        }

        // POST: UserController/Delete/5
        [HttpDelete,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(UserForResultDto dto)
        {
            try
            {

                await this._userService.DeleteAsync(dto.Id);
                return RedirectToAction("AllUsers");
            }
            catch
            {
                return View();
            }
        }*/

    }
}
