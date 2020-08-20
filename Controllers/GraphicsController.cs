using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudMVCCore.Models;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = System.Web.Mvc.JsonResult;

namespace CrudMVCCore.Controllers
{
    public class GraphicsController : Controller
    {
        private readonly DashboardDBContext _context;

        public GraphicsController(DashboardDBContext context)
        {
            _context = context;
        }

        // GET: Graphics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Graphics.ToListAsync());
        }

        //public JsonResult GetChart()
        //{
        //    var DbResult = from d in _context.Graphics
        //                   select new
        //                   {
        //                       d.Location,
        //                       d.Rssi
        //                   };
        //    return JsonResult(DbResult, serializerSettings: JsonRequestBehavior.AllowGet);
        //}



        //// GET: Graphics/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var graphics = await _context.Graphics
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (graphics == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(graphics);
        //}

        //// GET: Graphics/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Graphics/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Microsoft.AspNetCore.Mvc.HttpPost]
        //[Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Location,Rssi")] Graphics graphics)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(graphics);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(graphics);
        //}

        //// GET: Graphics/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var graphics = await _context.Graphics.FindAsync(id);
        //    if (graphics == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(graphics);
        //}

        //// POST: Graphics/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Location,Rssi")] Graphics graphics)
        //{
        //    if (id != graphics.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(graphics);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GraphicsExists(graphics.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(graphics);
        //}

        //// GET: Graphics/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var graphics = await _context.Graphics
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (graphics == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(graphics);
        //}

        //// POST: Graphics/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var graphics = await _context.Graphics.FindAsync(id);
        //    _context.Graphics.Remove(graphics);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool GraphicsExists(int id)
        {
            return _context.Graphics.Any(e => e.Id == id);
        }
    }
}
