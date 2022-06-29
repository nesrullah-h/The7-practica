using Microsoft.EntityFrameworkCore;
using The7_Backend.Models;

namespace The7_Backend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Intro> Intros { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
