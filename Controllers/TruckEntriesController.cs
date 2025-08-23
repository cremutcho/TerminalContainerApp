using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerminalContainerApp.Data;
using TerminalContainerApp.Models;

namespace TerminalContainerApp.Controllers
{
    public class TruckEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TruckEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TruckEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.TruckEntries.ToListAsync());
        }

        // GET: TruckEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckEntry = await _context.TruckEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truckEntry == null)
            {
                return NotFound();
            }

            return View(truckEntry);
        }

        // GET: TruckEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TruckEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TruckPlate,ContainerNumber,EntryTime,ExitTime")] TruckEntry truckEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truckEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truckEntry);
        }

        // GET: TruckEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckEntry = await _context.TruckEntries.FindAsync(id);
            if (truckEntry == null)
            {
                return NotFound();
            }
            return View(truckEntry);
        }

        // POST: TruckEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TruckPlate,ContainerNumber,EntryTime,ExitTime")] TruckEntry truckEntry)
        {
            if (id != truckEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truckEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckEntryExists(truckEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(truckEntry);
        }

        // GET: TruckEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckEntry = await _context.TruckEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truckEntry == null)
            {
                return NotFound();
            }

            return View(truckEntry);
        }

        // POST: TruckEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truckEntry = await _context.TruckEntries.FindAsync(id);
            if (truckEntry != null)
            {
                _context.TruckEntries.Remove(truckEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckEntryExists(int id)
        {
            return _context.TruckEntries.Any(e => e.Id == id);
        }
    }
}
