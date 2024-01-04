using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using COMP1004_Project.Data;
using COMP1004_Project.Models;

namespace COMP1004_Project.Views.DND
{
    public class IndexModel : PageModel
    {
        private readonly COMP1004_Project.Data.ApplicationDbContext _context;

        public IndexModel(COMP1004_Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Character != null)
            {
                Character = await _context.Character.ToListAsync();
            }
        }
    }
}
