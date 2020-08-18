using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudMVCCore.Models;

namespace CrudMVCCore.Controllers
{
    public class BeaconsController : Controller
    {
        private readonly DashboardDBContext _context;

        public BeaconsController(DashboardDBContext context)
        {
            _context = context;
        }

        // GET: Beacons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beacons.ToListAsync());
        }

        // GET: Beacons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacons = await _context.Beacons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beacons == null)
            {
                return NotFound();
            }

            return View(beacons);
        }

        // GET: Beacons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beacons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mac,Type,Name,Location,Date,Rssi1,Rssi2,Rssi3,Rssi4")] Beacons beacons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beacons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beacons);
        }

        // GET: Beacons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacons = await _context.Beacons.FindAsync(id);
            if (beacons == null)
            {
                return NotFound();
            }
            return View(beacons);
        }

        // POST: Beacons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mac,Type,Name,Location,Date,Rssi1,Rssi2,Rssi3,Rssi4")] Beacons beacons)
        {
            if (id != beacons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beacons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeaconsExists(beacons.Id))
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
            return View(beacons);
        }

        // GET: Beacons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacons = await _context.Beacons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beacons == null)
            {
                return NotFound();
            }

            return View(beacons);
        }

        // POST: Beacons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beacons = await _context.Beacons.FindAsync(id);
            _context.Beacons.Remove(beacons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeaconsExists(int id)
        {
            return _context.Beacons.Any(e => e.Id == id);
        }
    }
}
