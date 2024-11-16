using Microsoft.AspNetCore.Mvc;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;

namespace Safespot.Controllers
{

    public class ReservationController : Controller
    {
        private readonly IRepository<Reservation> _repository;

        public ReservationController(IRepository<Reservation> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> AllReservations()
        {
            var allReservations = await this._repository.SelectAllAsync(p => !p.Id.Equals(null));

            return View(allReservations);
        }


        public ActionResult Create()
        {

            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
