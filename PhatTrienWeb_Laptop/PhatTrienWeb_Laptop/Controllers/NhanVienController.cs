using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhatTrienWeb_Laptop.Models;

namespace PhatTrienWeb_Laptop.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewBag.dsNV = context.layDSNhanVien();
            return View();
        }
        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhanVien nv)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(nv);
            }
            int temp = context.taoNhanVien(nv);
            if (temp == 0)
            {
                ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
            }
            else if (temp == 1)
            {
                ModelState.AddModelError("", "Người lao động phải lớn hơn 16 tuổi");

            }
            else
            {
                TempData["AlertMessage"] = "Tạo thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index");

            }
            return View(nv);
        }

        // GET: NhanVienController/Details/5

        public ActionResult Details(string manv)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinNV(manv));
        }
        // GET: NhanVienController/Edit/5

        public ActionResult Edit(string manv)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.layThongTinNV(manv));
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string manv, NhanVien nvien)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (context.capNhatNhanVien(manv,nvien) == 0)
            {
                ModelState.AddModelError("", "Người lao động phải lớn hơn 16 tuổi");
            }
            else
            {
                context.capNhatNhanVien(manv,nvien);
                TempData["AlertMessage"] = "Cập nhật thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpPost]
        public JsonResult timNhanVien(string manv)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            var nv = context.layThongTinNV(manv);
            return Json(nv);
        }

        // POST: NhanVienController/Delete/5
        [HttpPost]
        public ActionResult Delete(string manv, string tendangnhap)
        {

            try
            {
                LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;

                context.xoaNhanVien(manv, tendangnhap);
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success";
                return RedirectToAction(nameof(Index));

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                TempData["AlertMessage"] = "Tồn tại đơn hàng của người dùng này. Không thể xóa";
                TempData["AlertType"] = "alert alert-danger";
                return RedirectToAction("Index");
            }
        }
    }
}
