using EventsViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsViewer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
    }
}
