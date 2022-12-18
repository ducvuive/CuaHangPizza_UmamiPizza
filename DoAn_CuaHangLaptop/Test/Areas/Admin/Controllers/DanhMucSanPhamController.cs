using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class DanhMucSanPhamController : Controller
    {
        private readonly LapTopContext _context;

        public DanhMucSanPhamController(LapTopContext context)
        {
            _context = context;
        }

        // GET: Admin/DanhMucSanPham
        public async Task<IActionResult> Index()
        {
            return View(await _context.Danhmucsanpham.ToListAsync());
        }

        // GET: Admin/DanhMucSanPham/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var danhmucsanpham = await _context.Danhmucsanpham
        //        .FirstOrDefaultAsync(m => m.Madm == id);
        //    if (danhmucsanpham == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(danhmucsanpham);
        //}

        // GET: Admin/DanhMucSanPham/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Admin/DanhMucSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madm,Tendm")] Danhmucsanpham danhmucsanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhmucsanpham);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));
            }
            return View(danhmucsanpham);
        }

        // GET: Admin/DanhMucSanPham/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmucsanpham = await _context.Danhmucsanpham.FindAsync(id);
            if (danhmucsanpham == null)
            {
                return NotFound();
            }
            return View(danhmucsanpham);
        }

        // POST: Admin/DanhMucSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madm,Tendm")] Danhmucsanpham danhmucsanpham)
        {
            if (id != danhmucsanpham.Madm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhmucsanpham);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cập nhật thành công";
                    TempData["AlertType"] = "alert alert-success";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucsanphamExists(danhmucsanpham.Madm))
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
            return View(danhmucsanpham);
        }

        // GET: Admin/DanhMucSanPham/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var danhmucsanpham = await _context.Danhmucsanpham
        //        .FirstOrDefaultAsync(m => m.Madm == id);
        //    if (danhmucsanpham == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(danhmucsanpham);
        //}

        // POST: Admin/DanhMucSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Madm)
        {
            try
            {

                var danhmucsanpham = await _context.Danhmucsanpham.FindAsync(Madm);
                _context.Danhmucsanpham.Remove(danhmucsanpham);
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

        private bool DanhmucsanphamExists(int id)
        {
            return _context.Danhmucsanpham.Any(e => e.Madm == id);
        }
        [HttpPost]
        public JsonResult timDanhMuc(string id)
        {
            var dm = _context.Danhmucsanpham.Find(id); ;
            return Json(dm);
        }
    }
}
