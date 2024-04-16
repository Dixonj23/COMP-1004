using COMP1004_Project.Data;
using COMP1004_Project.Models;
using Microsoft.AspNetCore.Authorization;
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

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return _context.Class != null ?
                        View(await _context.Class.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Class'  is null.");
        }

        // GET: Class/Details/5
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

        // GET: Classes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Hitdie,Level,Features")] Class classs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classs);
        }

        // GET: Classes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Class == null)
            {
                return NotFound();
            }

            var classs = await _context.Class.FindAsync(id);
            if (classs == null)
            {
                return NotFound();
            }
            return View(classs);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Hitdie,Level,Features")] Class classs)
        {
            if (id != classs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(classs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classs);
        }

        // GET: Classes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)   
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

        // POST: Classes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Class == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Class'  is null.");
            }
            var classs = await _context.Class.FindAsync(id);
            if (classs != null)
            {
                _context.Class.Remove(classs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

