using _8MileRD2.Models;
using Microsoft.EntityFrameworkCore;

namespace _8MileRD2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categoies { get; set; }
        public DbSet<David> Davids { get; set; }
    }
}
