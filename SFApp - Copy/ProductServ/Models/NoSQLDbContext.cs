using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServ.Models
{
    public class NoSQLDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        // the instance of DbCOntext will be returnd from the pool (.NET Core 2.x+)
        public NoSQLDbContext(DbContextOptions<NoSQLDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // the container name
            modelBuilder.HasDefaultContainer("Products");
            // relations
        }
    }
}
