using PhatTrienWeb_Laptop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Controllers
{
    public class CTHDController : Controller
    {
        // GET: CTHDController
        public ActionResult Index(string mahd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewBag.dsCTHD = context.layDSCTHD(mahd);
            return View();
        }
        [HttpPost]
        public JsonResult timCTHD(string mahd, string masp)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            var cthd = context.layThongTinCTHD(mahd, masp);
            return Json(cthd);
        }
        // GET: CTHDController/Details/5
        public ActionResult Details(string mahd, string masp)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinCTHD(mahd, masp));
        }

        // GET: CTHDController/Create
        public ActionResult Create(string mahd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            TempData["maHD"] = mahd;
            ViewBag.dsSP = context.dsSPTonTai(mahd);
            return View();
        }

        // POST: CTHDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CTHD cthd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(cthd);
            }
            if (context.taoCTHD(cthd) != 0)
            {

                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index", new { mahd = cthd.MaHD });
            }

            return View();
        }

        // GET: CTHDController/Edit/5
        public ActionResult Edit(string mahd, string masp)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            TempData["tensp"] = context.LaySanPham(masp).TenSP;
            TempData["soluong"] = context.LaySanPham(masp).SoLuong;
            return View(context.layThongTinCTHD(mahd, masp));
        }

        // POST: CTHDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string mahd, string masp, CTHD cthd)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (context.capNhatCTHD(mahd,masp,cthd) != 0)
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index", new { mahd = cthd.MaHD });

            }
            return View(cthd);
        }


        // POST: CTHDController/Delete/5
        [HttpPost]
        public ActionResult Delete(string mahd, string masp, CTHD cthd)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            context.xoaCTHD(mahd, masp);
            TempData["AlertMessage"] = "Xóa thành công";
            TempData["AlertType"] = "alert alert-success";
            return RedirectToAction("Index", new { mahd = mahd });


        }
    }
}
