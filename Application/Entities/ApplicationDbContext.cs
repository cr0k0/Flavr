using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Entities
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Unique constraint for CategoryName
            builder.Entity<Category>()
                .HasIndex(u => u.CategoryName)
                .IsUnique();
        }

        public virtual DbSet<Category> Category { get; set; }


        private static string GetConnectionString()
        {
            const string databaseName = "Flavr";
            const string databaseUser = "flavr";
            const string databasePass = "FlavrUs3r$11";

            return $"Server=localhost;" +
                   $"database={databaseName};" +
                   $"uid={databaseUser};" +
                   $"pwd={databasePass};" +
                   $"pooling=true;";
        }
    }
}
