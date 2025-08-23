using Microsoft.EntityFrameworkCore;
using TerminalContainerApp.Models;

namespace TerminalContainerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TruckEntry> TruckEntries { get; set; }
    }
}
