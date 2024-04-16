using COMP1004_Project.Data;
using COMP1004_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//This controls the Class object and its functions:
// 1. It can return a list of classes to the index page
// 2. It can return a single class using a given id
// 3. It can create a new class using given properties  of the new character
// 4. It can change a classes properties given an id and the new properties
// 5. It can delete a class when given that characters id
// 6. lastly it can check if a class exists when given an id
//
//all these controllers have similar functions excluding the CustomViewModelController, HomeController and DND controller,
//as such this text may be similar in other controllers
//
//This controller uses authorisation to ensure that only logged in users can access certain pages i.e. the create, edit and delete views



namespace COMP1004_Project.Controllers
{
    public class ClassController : Controller

    {

        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: 1. Classes
        public async Task<IActionResult> Index()
        {
            return _context.Class != null ?
                        View(await _context.Class.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Class'  is null.");
        }

        // GET: 2. Class/Details/5
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

        // GET: 3. Classes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: 3. Classes/Create
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

        // GET: 4. Classes/Edit/5
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

        // POST: 4. Classes/Edit/5
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

        // GET: 5. Classes/Delete/5
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

        // POST: 5. Classes/Delete/5
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

        //6. check class exists
        private bool ClassExists(int id)
        {
            return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

