using Microsoft.EntityFrameworkCore;
using FrogGameAPI.Models;

namespace FrogGameAPI.Data
{
    public class AppDbContext : DbContext
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSet mapeja la classe User i Score a la base de dades
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
