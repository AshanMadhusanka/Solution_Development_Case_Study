#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryControl.Models;

namespace InventoryControl.Controllers
{
    public class InventoryInfomationsController : Controller
    {
        private readonly InventoryControlContext _context;

        public InventoryInfomationsController(InventoryControlContext context)
        {
            _context = context;
        }

        // GET: InventoryInfomations
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryInfomations.ToListAsync());
        }

        // GET: InventoryInfomations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryInfomation = await _context.InventoryInfomations
                .FirstOrDefaultAsync(m => m.InventId == id);
            if (inventoryInfomation == null)
            {
                return NotFound();
            }

            return View(inventoryInfomation);
        }

        // GET: InventoryInfomations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryInfomations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventId,Name,NuOfUnit,ReOrderLevel,UnitPrice")] InventoryInfomation inventoryInfomation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryInfomation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryInfomation);
        }

        // GET: InventoryInfomations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryInfomation = await _context.InventoryInfomations.FindAsync(id);
            if (inventoryInfomation == null)
            {
                return NotFound();
            }
            return View(inventoryInfomation);
        }

        // POST: InventoryInfomations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InventId,Name,NuOfUnit,ReOrderLevel,UnitPrice")] InventoryInfomation inventoryInfomation)
        {
            if (id != inventoryInfomation.InventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryInfomation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryInfomationExists(inventoryInfomation.InventId))
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
            return View(inventoryInfomation);
        }

        // GET: InventoryInfomations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryInfomation = await _context.InventoryInfomations
                .FirstOrDefaultAsync(m => m.InventId == id);
            if (inventoryInfomation == null)
            {
                return NotFound();
            }

            return View(inventoryInfomation);
        }

        // POST: InventoryInfomations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var inventoryInfomation = await _context.InventoryInfomations.FindAsync(id);
            _context.InventoryInfomations.Remove(inventoryInfomation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryInfomationExists(string id)
        {
            return _context.InventoryInfomations.Any(e => e.InventId == id);
        }
    }
}
