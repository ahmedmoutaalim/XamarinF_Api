using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class productContext : DbContext
    {
        public productContext(DbContextOptions<productContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<products> Product { get; set; }

    }
}
