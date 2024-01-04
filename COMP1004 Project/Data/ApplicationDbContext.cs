using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using COMP1004_Project.Models;

namespace COMP1004_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<COMP1004_Project.Models.Game> Game { get; set; } = default!;
        public DbSet<COMP1004_Project.Models.Character> Character { get; set; } = default!;
    }
}