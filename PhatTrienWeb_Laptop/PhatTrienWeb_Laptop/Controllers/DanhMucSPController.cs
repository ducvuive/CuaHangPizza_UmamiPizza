using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_CuaHangLaptop.Models;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class DanhMucSPController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.LayDSDanhMuc());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new DanhMuc();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMuc dm)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;

            if (context.TaoDanhMuc(dm) != 0)
            {
                return Redirect("/DanhMucSP/Index");
            }
            return Redirect("/DanhMucSP/Index");
        }

        public ActionResult Details(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["DanhMuc"] = context.LayDanhMuc(id);
            return View();
        }

        public ActionResult Edit(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["DanhMuc"] = context.LayDanhMuc(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, DanhMuc dm)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (context.CapNhatDanhMuc(dm) != 0)
            {
                return Redirect("/DanhMucSP/Index");
            }
            return Redirect("/DanhMucSP/Index");
        }

        public ActionResult Delete(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["DanhMuc"] = context.LayDanhMuc(id);
            if (context.XoaDanhMuc(id) != 0)
            {
                return Redirect("/DanhMucSP/Index");
            }
            return Redirect("/DanhMucSP/Index");
        }
    }
}
