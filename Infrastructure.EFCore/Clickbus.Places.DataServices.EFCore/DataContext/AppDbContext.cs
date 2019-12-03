using Microsoft.EntityFrameworkCore;

namespace Clickbus.Places.DataServices.EFCore.DataContext
{
    using Domains.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}