using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext:DbContext
    {
        public  DbSet<Education>Educations { get; set; }
        public DbSet<Group>Groups { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9DDEKNH\\SQLEXPRESS;Database=CourseApp;Trusted_Connection=true");
        }

    }
}
