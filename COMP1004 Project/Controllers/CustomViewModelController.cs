using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1004_Project.Controllers
{
    public class CustomViewModelController : Controller
    {
        // GET: CustomViewModelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomViewModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomViewModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomViewModelController/Create
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

        // GET: CustomViewModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomViewModelController/Edit/5
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

        // GET: CustomViewModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomViewModelController/Delete/5
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
