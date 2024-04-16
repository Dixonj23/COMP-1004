using COMP1004_Project.Data;
using COMP1004_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

// This controller manages the DND section of the application
// it uses both previously seen and new technologies to run smoothly and merge multiple models:
// 1. Index is here again but this time utilising Route to clean up the URL and returning the CustomViewModel to output data from two models to one view
// 2. Details is split into Details and DetailsC to return the character and class details individually
// 3. Create is split into multiple functios to utilise the CustomViewModel to create a charater consisting of merged models this
// also allows a character to be created across multiple views providing a step by step character creation process
// 4. Edit uses custom view model to change the characters, class or race model. Additionally, it uses split, length and parse to allow 
// the characters class and level to be output and input in the following format (Class Level) i.e. Wizard 2 
// 5. Delete and Exists are the same as usual but only change the character object
//



namespace COMP1004_Project.Controllers
{
    public class DND : Controller
    {
        private readonly ApplicationDbContext _context;

        public DND(ApplicationDbContext context)
        {
            _context = context;
        }


        // 1. 
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

        // GET: 2. Character/Details/5
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


        // GET: 3. Characters/Create
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

        // GET: 3. Characters/Create2
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


        // POST: 3. Characters/Create2
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
                    Races = await _context.Race.ToListAsync()
                }) :
                 Problem("Entity set 'ApplicationDbContext.Character' or 'ApplicationDbContext.Class' or 'ApplicationDbContext.Race' is null.");
        }

        // GET: 4. Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
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

        // POST: 4. Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Class classes, [Bind("Id,Name,Race,Classes,Level,Image")] Character character)
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
                
            }

            var characterClass = classes;

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

        // 5. check character exists
        private bool CharacterExists(int id)
        {
            return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
