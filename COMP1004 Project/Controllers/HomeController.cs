using COMP1004_Project.Data;
using COMP1004_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

//This controller is used to manage the game selection home screen and as such, contains the bare minimum functions
// it contains the standard Index, Details and Exists functions for the Game object however it differs beyond them:
//  1. it has a privacy function for a privacy view
//  2. it has an error function to return the request id of an error
//  3. this has been mentioned in other controllers but in contains Authorise for the purpose of redirecting a logged out user to the sign in page on startup 

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

        //  1. privacy
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

        // 2. error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // check game exists
        private bool GameExists(int id)
        {
            return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}