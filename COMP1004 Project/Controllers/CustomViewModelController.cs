using COMP1004_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//This controller is unique in the fact that the model it controls is made of three other models (character, race and class) and as such,
//it contains the same methods as the other controllers but is almost never used to manipulate its object.


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
