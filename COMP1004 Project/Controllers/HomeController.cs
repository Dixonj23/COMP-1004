using COMP1004_Project.Data;
using COMP1004_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace COMP1004_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        public async Task<IActionResult> IndexAsync()
        {
            return _context.Game != null ?
                       View(await _context.Game.ToListAsync()) :
                       Problem("Entity set 'ApplicationDbContext.Game'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private bool GameExists(int id)
        {
            return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}