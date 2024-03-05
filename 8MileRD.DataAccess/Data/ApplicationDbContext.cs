using _8MileRD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _8MileRD2.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Category> Categoies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name="Kupus",
                    DisplayOrder = 1,
                },
                new Category
                {
                    Id = 2,
                    Name = "Krastavac",
                    DisplayOrder = 2 ,
                }) ;
        }
    }
}
