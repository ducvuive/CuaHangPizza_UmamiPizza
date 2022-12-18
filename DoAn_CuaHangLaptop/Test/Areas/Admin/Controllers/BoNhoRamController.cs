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
//    public class BoNhoRamController : Controller
//    {
//        private readonly LapTopContext _context;

//        public BoNhoRamController(LapTopContext context)
//        {
//            _context = context;
//        }

//        // GET: Bonhoram
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Bonhoram.ToListAsync());
//        }

//        // GET: Bonhoram/Details/5
//        //public async Task<IActionResult> Details(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var bonhoram = await _context.Bonhoram
//        //        .FirstOrDefaultAsync(m => m.Maram == id);
//        //    if (bonhoram == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(bonhoram);
//        //}

//        // GET: Bonhoram/Create
//        //public IActionResult Create()
//        //{
//        //    return View();
//        //}

//        // POST: Bonhoram/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Maram,Dungluongram,Loairam,Busram,Hotrotoida")] Bonhoram bonhoram)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(bonhoram);
//                await _context.SaveChangesAsync();
//                TempData["AlertMessage"] = "Tạo thành công";
//                TempData["AlertType"] = "alert alert-success";
//                return RedirectToAction(nameof(Index));
//            }
//            return View(bonhoram);
//        }

//        // GET: Bonhoram/Edit/5
//        public async Task<IActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var bonhoram = await _context.Bonhoram.FindAsync(id);
//            if (bonhoram == null)
//            {
//                return NotFound();
//            }
//            return View(bonhoram);
//        }

//        // POST: Bonhoram/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, [Bind("Maram,Dungluongram,Loairam,Busram,Hotrotoida")] Bonhoram bonhoram)
//        {
//            if (id != bonhoram.Maram)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(bonhoram);
//                    await _context.SaveChangesAsync();
//                    TempData["AlertMessage"] = "Cập nhật thành công";
//                    TempData["AlertType"] = "alert alert-success";
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!BonhoramExists(bonhoram.Maram))
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
//            return View(bonhoram);
//        }

//        // GET: Bonhoram/Delete/5
//        //public async Task<IActionResult> Delete(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var bonhoram = await _context.Bonhoram
//        //        .FirstOrDefaultAsync(m => m.Maram == id);
//        //    if (bonhoram == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(bonhoram);
//        //}

//        // POST: Bonhoram/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(string Maram)
//        {
//            try
//            {
//                var bonhoram = await _context.Bonhoram.FindAsync(Maram);
//                _context.Bonhoram.Remove(bonhoram);
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

//        private bool BonhoramExists(string id)
//        {
//            return _context.Bonhoram.Any(e => e.Maram == id);
//        }
//        [HttpPost]
//        public JsonResult timBoNhoRam(string id)
//        {
//            var ram = _context.Bonhoram.Find(id); ;
//            return Json(ram);
//        }
//    }
//}
