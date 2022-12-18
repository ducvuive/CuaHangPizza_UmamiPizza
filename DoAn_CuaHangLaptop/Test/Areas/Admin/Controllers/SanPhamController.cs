using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class SanPhamController : Controller
    {
        private readonly LapTopContext _context;

        private readonly IConfiguration _configuration;
        public SanPhamController(LapTopContext context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        // GET: Sanpham
        public async Task<IActionResult> Index()
        {
            var lapTopContext = _context.Sanpham.Include(s => s.DanhmucNavigation);
            ViewBag.Danhmuc = _context.Danhmucsanpham.ToList();
            return View(await lapTopContext.ToListAsync());
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = _context.Sanpham.Find(id);

            ViewData["SanPham"] = sanpham;
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);

        }

        // GET: Sanpham/Create
        //public IActionResult Create()
        //{
        //    ViewData["Boxuly"] = new SelectList(_context.Boxuly, "Mabxl", "Mabxl");
        //    ViewData["Congketnoi"] = new SelectList(_context.Congketnoi, "Mackn", "Mackn");
        //    ViewData["Danhmuc"] = new SelectList(_context.Danhmucsanpham, "Madm", "Madm");
        //    ViewData["Manhinh"] = new SelectList(_context.Manhinh, "Mamh", "Mamh");
        //    ViewData["Ram"] = new SelectList(_context.Bonhoram, "Maram", "Maram");
        //    return View();
        //}

        // POST: Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masp,Manhinh,Boxuly,Ram,Congketnoi,Danhmuc,Tensp,Soluong,Mausac,Ocung,Cardmanhinh,Dacbiet,Hdh,Thietke,KichthuocTrongluong,Webcam,Pin,Ramat,Mota,Dongia,HinhAnhFile")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.HinhAnhFile != null)
                {
                    string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot", "HinhAnh", sanpham.HinhAnhFile.FileName);
                    using (var file = new FileStream(fullPath, FileMode.Create))
                    {
                        sanpham.HinhAnhFile.CopyTo(file);
                    }
                    sanpham.Hinhanh = "/HinhAnh/" + sanpham.HinhAnhFile.FileName;
                }
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsanpham, "Madm", "Madm", sanpham.Danhmuc);
            return View(sanpham);
        }

        // GET: Sanpham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsanpham, "Madm", "Madm", sanpham.Danhmuc);
            return View(sanpham);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masp,Manhinh,Boxuly,Ram,Congketnoi,Danhmuc,Tensp,Soluong,Mausac,Ocung,Cardmanhinh,Dacbiet,Hdh,Thietke,KichthuocTrongluong,Webcam,Pin,Ramat,Mota,Dongia,HinhAnhFile")] Sanpham sanpham)
        {
            if (id != sanpham.Masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (sanpham.HinhAnhFile != null)
                    {
                        string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                                            "wwwroot", "HinhAnh", sanpham.HinhAnhFile.FileName);
                        using (var file = new FileStream(fullPath, FileMode.Create))
                        {
                            sanpham.HinhAnhFile.CopyTo(file);
                        }
                        sanpham.Hinhanh = "/HinhAnh/" + sanpham.HinhAnhFile.FileName;
                    }
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Masp))
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
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsanpham, "Madm", "Madm", sanpham.Danhmuc);
            return View(sanpham);
        }

        // GET: Sanpham/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sanpham = await _context.Sanpham
        //        .Include(s => s.BoxulyNavigation)
        //        .Include(s => s.CongketnoiNavigation)
        //        .Include(s => s.DanhmucNavigation)
        //        .Include(s => s.ManhinhNavigation)
        //        .Include(s => s.RamNavigation)
        //        .FirstOrDefaultAsync(m => m.Masp == id);
        //    if (sanpham == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sanpham);
        //}

        // POST: Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string Masp)
        {
            try
            {
                var sanpham = await _context.Sanpham.FindAsync(Masp);
                _context.Sanpham.Remove(sanpham);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                TempData["AlertMessage"] = "Xóa không thành công";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool SanphamExists(string id)
        {
            return _context.Sanpham.Any(e => e.Masp == id);
        }
        [HttpPost]
        public JsonResult timSanPham(string id)
        {
            var sp = _context.Sanpham.Find(id);
            return Json(sp);
        }
    }
}
