using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GYM.Models;

namespace GYM.Data
{
    public class GYMContext : DbContext
    {
        public GYMContext (DbContextOptions<GYMContext> options)
            : base(options)
        {
        }

        public DbSet<GYM.Models.Employee> Employee { get; set; } = default!;
        public DbSet<GYM.Models.Admin> Admin { get; set; } = default!;
        public DbSet<GYM.Models.Member> Member { get; set; } = default!;
    }
}
