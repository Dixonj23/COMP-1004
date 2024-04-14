using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP1004_Project.Data;
using COMP1004_Project.Models;

//This controls the Race object and its functions:
// 1. It can return a list of races to the index page
// 2. It can return a single race using a given id
// 3. It can create a new race using given properties  of the new character
// 4. It can change a races properties given an id and the new properties
// 5. It can delete a race when given that characters id
// 6. lastly it can check if a race exists when given an id
//
//all these controllers have similar functions excluding the CustomViewModelController, HomeController and DND controller,
//as such this text may be similar in other controllers
//
//Similarly to the CharactersController, the RacesController varies very little from a generic controller



namespace COMP1004_Project.Controllers
{
    public class RacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: 1. Races
        public async Task<IActionResult> Index()
        {
              return _context.Race != null ? 
                          View(await _context.Race.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Race'  is null.");
        }

        // GET: 2. Races/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Race == null)
            {
                return NotFound();
            }

            var race = await _context.Race
                .FirstOrDefaultAsync(m => m.Id == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // GET: 3. Races/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: 3. Races/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Speed,Size,Abilities,Proficiencies,Languages,Skills,Traits")] Race race)
        {
            if (ModelState.IsValid)
            {
                _context.Add(race);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(race);
        }

        // GET: 4. Races/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Race == null)
            {
                return NotFound();
            }

            var race = await _context.Race.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }
            return View(race);
        }

        // POST: 4. Races/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Speed,Size,Abilities,Proficiencies,Languages,Skills,Traits")] Race race)
        {
            if (id != race.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(race);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExists(race.Id))
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
            return View(race);
        }

        // GET: 5. Races/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Race == null)
            {
                return NotFound();
            }

            var race = await _context.Race
                .FirstOrDefaultAsync(m => m.Id == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: 5. Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Race == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Race'  is null.");
            }
            var race = await _context.Race.FindAsync(id);
            if (race != null)
            {
                _context.Race.Remove(race);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 6. check race exists
        private bool RaceExists(int id)
        {
          return (_context.Race?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
