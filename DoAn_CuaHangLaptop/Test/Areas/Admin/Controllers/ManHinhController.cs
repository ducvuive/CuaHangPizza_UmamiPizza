﻿//using System;
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
//    public class ManHinhController : Controller
//    {
//        private readonly LapTopContext _context;

//        public ManHinhController(LapTopContext context)
//        {
//            _context = context;
//        }

//        // GET: Manhinh
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Manhinh.ToListAsync());
//        }

//        // GET: Manhinh/Details/5
//        //public async Task<IActionResult> Details(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var manhinh = await _context.Manhinh
//        //        .FirstOrDefaultAsync(m => m.Mamh == id);
//        //    if (manhinh == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(manhinh);
//        //}

//        // GET: Manhinh/Create
//        //public IActionResult Create()
//        //{
//        //    return View();
//        //}

//        // POST: Manhinh/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Mamh,Kichthuoc,Dophangiai,Tansoquet,Congnghemh,Camung")] Manhinh manhinh)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(manhinh);
//                await _context.SaveChangesAsync();
//                TempData["AlertMessage"] = "Tạo thành công";
//                TempData["AlertType"] = "alert alert-success";
//                return RedirectToAction(nameof(Index));
//            }
//            return View(manhinh);
//        }

//        // GET: Manhinh/Edit/5
//        public async Task<IActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var manhinh = await _context.Manhinh.FindAsync(id);
//            if (manhinh == null)
//            {
//                return NotFound();
//            }
//            return View(manhinh);
//        }

//        // POST: Manhinh/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, [Bind("Mamh,Kichthuoc,Dophangiai,Tansoquet,Congnghemh,Camung")] Manhinh manhinh)
//        {
//            if (id != manhinh.Mamh)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(manhinh);
//                    await _context.SaveChangesAsync();
//                    TempData["AlertMessage"] = "Cập nhật thành công";
//                    TempData["AlertType"] = "alert alert-success";
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ManhinhExists(manhinh.Mamh))
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
//            return View(manhinh);
//        }

//        // GET: Manhinh/Delete/5
//        //public async Task<IActionResult> Delete(string id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    var manhinh = await _context.Manhinh
//        //        .FirstOrDefaultAsync(m => m.Mamh == id);
//        //    if (manhinh == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return View(manhinh);
//        //}

//        // POST: Manhinh/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(string Mamh)
//        {
//            try
//            {
//                var manhinh = await _context.Manhinh.FindAsync(Mamh);
//                _context.Manhinh.Remove(manhinh);
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

//        private bool ManhinhExists(string id)
//        {
//            return _context.Manhinh.Any(e => e.Mamh == id);
//        }
//        [HttpPost]
//        public JsonResult timManHinh(string id)
//        {
//            var mh = _context.Manhinh.Find(id); 
//            return Json(mh);
//        }
//    }
//}
