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
    public class GatewaysController : Controller
    {
        private readonly DashboardDBContext _context;

        public GatewaysController(DashboardDBContext context)
        {
            _context = context;
        }

        // GET: Gateways
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gateways.ToListAsync());
        }

        // GET: Gateways/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gateways = await _context.Gateways
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gateways == null)
            {
                return NotFound();
            }

            return View(gateways);
        }

        // GET: Gateways/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gateways/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mac,Type,Name,Location")] Gateways gateways)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gateways);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gateways);
        }

        // GET: Gateways/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gateways = await _context.Gateways.FindAsync(id);
            if (gateways == null)
            {
                return NotFound();
            }
            return View(gateways);
        }

        // POST: Gateways/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mac,Type,Name,Location")] Gateways gateways)
        {
            if (id != gateways.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gateways);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GatewaysExists(gateways.Id))
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
            return View(gateways);
        }

        // GET: Gateways/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gateways = await _context.Gateways
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gateways == null)
            {
                return NotFound();
            }

            return View(gateways);
        }

        // POST: Gateways/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gateways = await _context.Gateways.FindAsync(id);
            _context.Gateways.Remove(gateways);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GatewaysExists(int id)
        {
            return _context.Gateways.Any(e => e.Id == id);
        }
    }
}
