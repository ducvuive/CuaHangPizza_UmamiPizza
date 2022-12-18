/*using System;
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
    public class CongketnoisController : Controller
    {
        private readonly LapTopContext _context;

        public CongketnoisController(LapTopContext context)
        {
            _context = context;
        }

        // GET: Congketnois
        public async Task<IActionResult> Index()
        {
            return View(await _context.Congketnoi.ToListAsync());
        }

        // GET: Congketnois/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congketnoi = await _context.Congketnoi
                .FirstOrDefaultAsync(m => m.Mackn == id);
            if (congketnoi == null)
            {
                return NotFound();
            }

            return View(congketnoi);
        }

        // GET: Congketnois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Congketnois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mackn,Conggiaotiep,Ketnoikhongday,Khedocthenho,Webcam,Tinhnangkhac,Denbanphim")] Congketnoi congketnoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congketnoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congketnoi);
        }

        // GET: Congketnois/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congketnoi = await _context.Congketnoi.FindAsync(id);
            if (congketnoi == null)
            {
                return NotFound();
            }
            return View(congketnoi);
        }

        // POST: Congketnois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mackn,Conggiaotiep,Ketnoikhongday,Khedocthenho,Webcam,Tinhnangkhac,Denbanphim")] Congketnoi congketnoi)
        {
            if (id != congketnoi.Mackn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congketnoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongketnoiExists(congketnoi.Mackn))
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
            return View(congketnoi);
        }

        // GET: Congketnois/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congketnoi = await _context.Congketnoi
                .FirstOrDefaultAsync(m => m.Mackn == id);
            if (congketnoi == null)
            {
                return NotFound();
            }

            return View(congketnoi);
        }

        // POST: Congketnois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var congketnoi = await _context.Congketnoi.FindAsync(id);
            _context.Congketnoi.Remove(congketnoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongketnoiExists(string id)
        {
            return _context.Congketnoi.Any(e => e.Mackn == id);
        }
    }
}
*/