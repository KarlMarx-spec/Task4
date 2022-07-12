using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

namespace ConsoleApp.Web.Controllers
{
    public class RTypesController : Controller
    {
        private readonly GeneralContext _context;

        public RTypesController(GeneralContext context)
        {
            _context = context;
        }

        // GET: RTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RTypes.ToListAsync());
        }

        // GET: RTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rType = await _context.RTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rType == null)
            {
                return NotFound();
            }

            return View(rType);
        }

        // GET: RTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RType rType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rType);
        }

        // GET: RTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rType = await _context.RTypes.FindAsync(id);
            if (rType == null)
            {
                return NotFound();
            }
            return View(rType);
        }

        // POST: RTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RType rType)
        {
            if (id != rType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RTypeExists(rType.Id))
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
            return View(rType);
        }

        // GET: RTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rType = await _context.RTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rType == null)
            {
                return NotFound();
            }

            return View(rType);
        }

        // POST: RTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rType = await _context.RTypes.FindAsync(id);
            _context.RTypes.Remove(rType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RTypeExists(int id)
        {
            return _context.RTypes.Any(e => e.Id == id);
        }
    }
}
