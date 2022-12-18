using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class SukienController : Controller
    {
        private readonly LapTopContext _context;

        public SukienController(LapTopContext context)
        {
            _context = context;
        }

        // GET: Sukien
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sukien.ToListAsync());
        }

        // GET: Sukien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sukien = await _context.Sukien
                .FirstOrDefaultAsync(m => m.Mask == id);
            if (sukien == null)
            {
                return NotFound();
            }

            return View(sukien);
        }

        // GET: Sukien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sukien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mask,Tensk,Phantramgiamgia,Ngaybd,Ngaykt")] Sukien sukien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sukien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sukien);
        }

        // GET: Sukien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sukien = await _context.Sukien.FindAsync(id);
            if (sukien == null)
            {
                return NotFound();
            }
            return View(sukien);
        }

        // POST: Sukien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mask,Tensk,Phantramgiamgia,Ngaybd,Ngaykt")] Sukien sukien)
        {
            if (id != sukien.Mask)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sukien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SukienExists(sukien.Mask))
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
            return View(sukien);
        }

        // GET: Sukien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sukien = await _context.Sukien
                .FirstOrDefaultAsync(m => m.Mask == id);
            if (sukien == null)
            {
                return NotFound();
            }

            return View(sukien);
        }

        // POST: Sukien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sukien = await _context.Sukien.FindAsync(id);
            _context.Sukien.Remove(sukien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SukienExists(string id)
        {
            return _context.Sukien.Any(e => e.Mask == id);
        }
    }
}
