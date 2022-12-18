//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Test.Data;
//using Test.Models;

//namespace Test.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize(Roles = "admin")]
//    public class BoXuLyController : Controller
//    {
//        private readonly LapTopContext _context;

//        public BoXuLyController(LapTopContext context)
//        {
//            _context = context;
//        }

//        // GET: Boxuly
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Boxuly.ToListAsync());
//        }

//        // GET: Boxuly/Details/5
//        //public async Task<IActionResult> Details(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var boxuly = await _context.Boxuly
//        //        .FirstOrDefaultAsync(m => m.Mabxl == id);
//        //    if (boxuly == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(boxuly);
//        //}

//        // GET: Boxuly/Create
//        //public IActionResult Create()
//        //{
//        //    return View();
//        //}

//        // POST: Boxuly/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Mabxl,Congnghecpu,Sonhan,Soluong,Tocdocpu,Tocdotoida,Bonhodem")] Boxuly boxuly)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(boxuly);
//                await _context.SaveChangesAsync();
//                TempData["AlertMessage"] = "Tạo thành công";
//                TempData["AlertType"] = "alert alert-success";
//                return RedirectToAction(nameof(Index));
//            }
//            return View(boxuly);
//        }

//        // GET: Boxuly/Edit/5
//        public async Task<IActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var boxuly = await _context.Boxuly.FindAsync(id);
//            if (boxuly == null)
//            {
//                return NotFound();
//            }
//            return View(boxuly);
//        }

//        // POST: Boxuly/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, [Bind("Mabxl,Congnghecpu,Sonhan,Soluong,Tocdocpu,Tocdotoida,Bonhodem")] Boxuly boxuly)
//        {
//            if (id != boxuly.Mabxl)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(boxuly);
//                    await _context.SaveChangesAsync();
//                    TempData["AlertMessage"] = "Cập nhật thành công";
//                    TempData["AlertType"] = "alert alert-success";
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!BoxulyExists(boxuly.Mabxl))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(boxuly);
//        }

//        // GET: Boxuly/Delete/5
//        //public async Task<IActionResult> Delete(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var boxuly = await _context.Boxuly
//        //        .FirstOrDefaultAsync(m => m.Mabxl == id);
//        //    if (boxuly == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(boxuly);
//        //}

//        // POST: Boxuly/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(string Mabxl)
//        {
//            try
//            {
//                var boxuly = await _context.Boxuly.FindAsync(Mabxl);
//                _context.Boxuly.Remove(boxuly);
//                await _context.SaveChangesAsync();
//                TempData["AlertMessage"] = "Xóa thành công";
//                TempData["AlertType"] = "alert alert-success";
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                TempData["AlertMessage"] = "Xóa không thành công";
//                TempData["AlertType"] = "alert alert-danger";
//                return RedirectToAction(nameof(Index));
//            }
//        }

//        private bool BoxulyExists(string id)
//        {
//            return _context.Boxuly.Any(e => e.Mabxl == id);
//        }

//        [HttpPost]
//        public JsonResult timBoXuLy(string id)
//        {
//            var bxl = _context.Boxuly.Find(id); ;
//            return Json(bxl);
//        }
//    }
//}
