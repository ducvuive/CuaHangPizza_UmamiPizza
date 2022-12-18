using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        private readonly LapTopContext _context;

        public HoaDonController(LapTopContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDon
        public IActionResult Index(int trangthai)
        {
            trangthai--;
            List<Hoadon> dsHd = new List<Hoadon>();
            if (trangthai == -1)
            {
                var query = from hd in _context.Hoadon select hd;
                dsHd = query.ToList();
            }
            else if (trangthai == 0)
            {
                var query = from hd in _context.Hoadon where hd.Trangthai == 0 select hd;
                dsHd = query.ToList();
            }
            else if (trangthai == 1)
            {
                var query = from hd in _context.Hoadon where hd.Trangthai == 1 select hd;
                dsHd = query.ToList();
            }
            else if (trangthai == 2)
            {
                var query = from hd in _context.Hoadon where hd.Trangthai == 2 select hd;
                dsHd = query.ToList();
            }
            else
            {
                var query = from hd in _context.Hoadon where hd.Trangthai == 3 select hd;
                dsHd = query.ToList();
            }
            return View(dsHd);

        }

        // GET: Admin/HoaDon/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cthd = await _context.Cthd
        //        .Include(c => c.MahdNavigation)
        //        .FirstOrDefaultAsync(m => m.Mahd == id);
        //    if (cthd == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cthd);
        //}

        public IActionResult Details(int id)
        {

            List<Cthd> listdata = _context.Cthd.Where(cthd => cthd.Mahd == id).Select(cthd => new Cthd
            {
                Mahd = cthd.Mahd,
                Masp = cthd.Masp,
                MahdNavigation = cthd.MahdNavigation,
                MaspNavigation = cthd.MaspNavigation,
                Soluong = cthd.Soluong,

            }).ToList();
            foreach(var ct in listdata)
            {
                TempData["TongCong"] = ct.MahdNavigation.Tongtien?.ToString("#,##0 VND");
            }
            return View(listdata);
        }
        public IActionResult changeStatus(int mahd)
        {
            Hoadon result = (from hd in _context.Hoadon
                             where hd.Mahd == mahd
                             select hd).SingleOrDefault();

            result.Trangthai++;

            _context.SaveChanges();
            return RedirectToAction("Index", new { trangthai = 0 });
        }

        //// GET: Admin/HoaDon/Create
        //public IActionResult Create()
        //{
        //    ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh");
        //    ViewData["Mask"] = new SelectList(_context.Sukien, "Mask", "Mask");
        //    return View();
        //}

        //// POST: Admin/HoaDon/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Mahd,Makh,Mask,Ngayhd,Nguoinhan,nhanvienmanv,Sdt,Diachigiaohang,Tongtien,Thanhtien,Trangthai")] Hoadon hoadon)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(hoadon);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh", hoadon.Makh);
        //    ViewData["Mask"] = new SelectList(_context.Sukien, "Mask", "Mask", hoadon.Mask);
        //    return View(hoadon);
        //}

        //// GET: Admin/HoaDon/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hoadon = await _context.Hoadon.FindAsync(id);
        //    if (hoadon == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh", hoadon.Makh);
        //    ViewData["Mask"] = new SelectList(_context.Sukien, "Mask", "Mask", hoadon.Mask);
        //    return View(hoadon);
        //}

        //// POST: Admin/HoaDon/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Mahd,Makh,Mask,Ngayhd,Nguoinhan,nhanvienmanv,Sdt,Diachigiaohang,Tongtien,Thanhtien,Trangthai")] Hoadon hoadon)
        //{
        //    if (id != hoadon.Mahd)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(hoadon);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HoadonExists(hoadon.Mahd))
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
        //    ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh", hoadon.Makh);
        //    ViewData["Mask"] = new SelectList(_context.Sukien, "Mask", "Mask", hoadon.Mask);
        //    return View(hoadon);
        //}

        //// GET: Admin/HoaDon/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hoadon = await _context.Hoadon
        //        .Include(h => h.MakhNavigation)
        //        .Include(h => h.MaskNavigation)
        //        .FirstOrDefaultAsync(m => m.Mahd == id);
        //    if (hoadon == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hoadon);
        //}

        //// POST: Admin/HoaDon/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hoadon = await _context.Hoadon.FindAsync(id);
        //    _context.Hoadon.Remove(hoadon);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool HoadonExists(int id)
        //{
        //    return _context.Hoadon.Any(e => e.Mahd == id);
        //}
    }
}
