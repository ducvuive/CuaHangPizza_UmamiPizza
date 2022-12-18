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
    public class CthdController : Controller
    {
        private readonly LapTopContext _context;

        public CthdController(LapTopContext context)
        {
            _context = context;
        }

        // GET: Cthd
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Cthd.Include(c => c.MahdNavigation).Include(c => c.MaspNavigation);
            return View(await lapTopContext.ToListAsync());
        }

        // GET: Cthd/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthd = await _context.Cthd
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (cthd == null)
            {
                return NotFound();
            }

            return View(cthd);
        }

        // GET: Cthd/Create
        public IActionResult Create()
        {
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd");
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Masp");
            return View();
        }

        // POST: Cthd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahd,Masp,Soluong")] Cthd cthd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cthd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", cthd.Mahd);
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Masp", cthd.Masp);
            return View(cthd);
        }

        // GET: Cthd/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthd = await _context.Cthd.FindAsync(id);
            if (cthd == null)
            {
                return NotFound();
            }
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", cthd.Mahd);
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Masp", cthd.Masp);
            return View(cthd);
        }

        // POST: Cthd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahd,Masp,Soluong")] Cthd cthd)
        {
            if (id != cthd.Mahd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cthd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CthdExists(cthd.Mahd))
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
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", cthd.Mahd);
            ViewData["Masp"] = new SelectList(_context.Sanpham, "Masp", "Masp", cthd.Masp);
            return View(cthd);
        }

        // GET: Cthd/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthd = await _context.Cthd
                .Include(c => c.MahdNavigation)
                .Include(c => c.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (cthd == null)
            {
                return NotFound();
            }

            return View(cthd);
        }

        // POST: Cthd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cthd = await _context.Cthd.FindAsync(id);
            _context.Cthd.Remove(cthd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CthdExists(int id)
        {
            return _context.Cthd.Any(e => e.Mahd == id);
        }

        public IActionResult CTHD(int mahd)
        {

            List<Cthd> listdata = _context.Cthd.Where(cthd => cthd.Mahd == mahd).Select(cthd => new Cthd
            {
                Mahd = cthd.Mahd,
                Masp = cthd.Masp,
                MahdNavigation = cthd.MahdNavigation,
                MaspNavigation = cthd.MaspNavigation,
                Soluong = cthd.Soluong,
            }).ToList();


            return View(listdata);
        }
    }
}
