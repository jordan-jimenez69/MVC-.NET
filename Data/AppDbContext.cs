using Microsoft.EntityFrameworkCore;
using MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVC.Data
{
    public class AppDbContext : IdentityDbContext<Teacher>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}