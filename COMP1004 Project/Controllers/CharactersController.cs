using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP1004_Project.Data;
using COMP1004_Project.Models;

//This controls the Character object and its functions:
// 1. It can return a list of characters to the index page
// 2. It can return a single character using a given id
// 3. It can create a new character using given properties  of the new character
// 4. It can change a characters properties given an id and the new properties
// 5. It can delete a character when given that characters id
// 6. lastly it can check if a character exists when given an id
//
//all these controllers have similar functions excluding the CustomViewModelController, HomeController and DND controller,
//as such this text may be similar in other controllers
//
//This controller has little variation and is the closest to a standard controller


namespace COMP1004_Project.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: 1. Characters 
        public async Task<IActionResult> Index()
        {
              return _context.Character != null ? 
                          View(await _context.Character.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Character'  is null.");
        }

        // GET: 2. Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: 3. Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: 3. Characters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Race,Classes,Level,Image")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: 4. Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: 4. Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Race,Classes,Level,Image")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            return View(character);
        }

        // GET: 5. Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: 5. Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Character == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Character'  is null.");
            }
            var character = await _context.Character.FindAsync(id);
            if (character != null)
            {
                _context.Character.Remove(character);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 6. Check character exists
        private bool CharacterExists(int id)
        {
          return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
