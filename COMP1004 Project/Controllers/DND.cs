using COMP1004_Project.Data;
using COMP1004_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace COMP1004_Project.Controllers
{
    public class DND : Controller
    {
        private readonly ApplicationDbContext _context;

        public DND(ApplicationDbContext context)
        {
            _context = context;
        }



        [Route("Home/{name?}")]
        public async Task<IActionResult> Index()
        {

            return (_context.Character != null && _context.Class != null) ?
                View("Index", new CustomViewModel
                {
                    Characters = await _context.Character.ToListAsync(),
                    Classes = await _context.Class.ToListAsync()
                }) :
                Problem("Entity set 'ApplicationDbContext.Character' or 'ApplicationDbContext.Class' is null.");

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

        // GET: Character/Details/5
        public async Task<IActionResult> DetailsC(int? id)
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


        // GET: Characters/Create
        public async Task<IActionResult> Create()
        {
            return (_context.Character != null && _context.Class != null && _context.Race != null) ?
                View(new CustomViewModel
                {
                    Characters = await _context.Character.ToListAsync(),
                    Classes = await _context.Class.ToListAsync(),
                    Races = await _context.Race.ToListAsync()
                }) :
                 Problem("Entity set 'ApplicationDbContext.Character' or 'ApplicationDbContext.Class' or 'ApplicationDbContext.Race' is null.");
        }

        // GET: Characters/Create2
        public IActionResult Create2()
        {
            return (_context.Character != null && _context.Class != null) ?
                 View() :
                 Problem("Entity set 'ApplicationDbContext.Character' or 'ApplicationDbContext.Class' is null.");
        }

        public IActionResult Create3()
        {
            return View();
        }


        // POST: Characters/Create2
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("Id,Name,Race,Classes,Level,Image")] Character character)
        {
            character.Level = 1;
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return (_context.Character != null && _context.Class != null && _context.Race != null) ?
                View(new CustomViewModel
                {
                    Characters = await _context.Character.ToListAsync(),
                    Classes = await _context.Class.ToListAsync(),
                    Races = await _context.Race.ToListAsync(),
        }) :
                 Problem("Entity set 'ApplicationDbContext.Character' or 'ApplicationDbContext.Class' or 'ApplicationDbContext.Race' is null.");
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            var classes = await _context.Class.FindAsync(id);
            var race = await _context.Race.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            var characterClass = await _context.Class
               .FirstOrDefaultAsync(c => c.Name == character.Classes);

            var characterRace = await _context.Race
               .FirstOrDefaultAsync(c => c.Name == character.Race);

            // Create an instance of CustomViewModel and populate it with the necessary data
            var customViewModel = new CustomViewModel
            {
                Character = character,
                Class = characterClass,
                Race = characterRace
            };

            return View(customViewModel);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Race,Classes,Level,Image")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            var characterClass = await _context.Class
               .FirstOrDefaultAsync(c => c.Name == character.Classes); 

            var characterRace = await _context.Race
               .FirstOrDefaultAsync(c => c.Name == character.Race);

            // Create an instance of CustomViewModel and populate it with the necessary data
            var customViewModel = new CustomViewModel
            {
                Character = character,
                Class = characterClass,
                Race = characterRace
            };

            return View(customViewModel);
        }

        // GET: Characters/Delete/5
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

        // POST: Characters/Delete/5
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

        private bool CharacterExists(int id)
        {
            return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
