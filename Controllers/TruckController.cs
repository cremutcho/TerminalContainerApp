using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TerminalContainerApp.Data;
using TerminalContainerApp.Models;

namespace TerminalContainerApp.Data
{
    // DbContext representando seu banco de dados
    public class TerminalDbContext : DbContext
    {
        public DbSet<TruckEntry> TruckEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TerminalDB;Trusted_Connection=True;");
        }
    }
}

namespace TerminalContainerApp.Controllers
{
    public class TruckController
    {
        private readonly TerminalDbContext _context;

        public TruckController()
        {
            _context = new TerminalDbContext();
        }

        public void AddEntry(TruckEntry entry)
        {
            _context.TruckEntries.Add(entry);
            _context.SaveChanges();
        }

        public void UpdateExit(int id, DateTime exitTime)
        {
            var entry = _context.TruckEntries.Find(id);
            if (entry != null)
            {
                entry.ExitTime = exitTime;
                _context.SaveChanges();
            }
        }

        public List<TruckEntry> GetAllEntries()
        {
            return _context.TruckEntries.ToList();
        }
    }
}
