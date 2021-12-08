using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_CuaHangLaptop.Models;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class ManHinhController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.LayDSManHinh());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ManHinh();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManHinh mh)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;

            if (context.TaoManHinh(mh) != 0)
            {
                return Redirect("/ManHinh/Index");
            }
            return Redirect("/ManHinh/Index");
        }

        public ActionResult Details(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["ManHinh"] = context.LayManHinh(id);
            return View();
        }

        public ActionResult Edit(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["ManHinh"] = context.LayManHinh(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ManHinh mh)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (context.CapNhatManHinh(mh) != 0)
            {
                return Redirect("/ManHinh/Index");
            }
            return Redirect("/ManHinh/Index");
        }

        public ActionResult Delete(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["ManHinh"] = context.LayManHinh(id);
            if (context.XoaManHinh(id) != 0)
            {
                return Redirect("/ManHinh/Index");
            }
            return Redirect("/ManHinh/Index");
        }
    }
}
