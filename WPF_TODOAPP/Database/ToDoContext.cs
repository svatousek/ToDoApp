using Microsoft.EntityFrameworkCore;
using WPF_TODOAPP.Models;

namespace WPF_TODOAPP.Database
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<ToDoEntity> ToDoSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source = ToDoAppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoEntity>().HasData(
                new ToDoEntity { Id = 1, IsDone = true, Title = "Vyluxovat" },
                new ToDoEntity { Id = 2, IsDone = false, Title = "Nakopat"}
                );
        }
    }
}
