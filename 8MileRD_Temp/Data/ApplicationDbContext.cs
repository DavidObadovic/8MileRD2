using _8MileRD_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace _8MileRD_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) {}

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id=1,Name="David",DisplayOrder=3},
                new Category() { Id=2,Name="Marijana",DisplayOrder=4},
                new Category() { Id = 3, Name = "Marijana", DisplayOrder = 4 }
                );
        }
    }
}
