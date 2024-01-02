using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COMP1004_Project.Models;

namespace COMP1004_Project.Data
{
    public class COMP1004_ProjectContext : DbContext
    {
        public COMP1004_ProjectContext(DbContextOptions<COMP1004_ProjectContext> options)
            : base(options)
        {
        }

    }
}
