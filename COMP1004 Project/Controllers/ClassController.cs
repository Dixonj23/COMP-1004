using COMP1004_Project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP1004_Project.Controllers
{
    public class ClassController : Controller

    {

        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ClassController
        public async Task<IActionResult> Index()
        {
            return _context.Class != null ?
                        View(await _context.Class.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Class'  is null.");
        }

        // GET: ClassController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Class == null)
            {
                return NotFound();
            }

            var classs = await _context.Class
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classs == null)
            {
                return NotFound();
            }

            return View(classs);
        }

        // GET: ClassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassController/Create
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

        // GET: ClassController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassController/Edit/5
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

        // GET: ClassController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassController/Delete/5
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

        private bool ClassExists(int id)
        {
            return (_context.Class?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
