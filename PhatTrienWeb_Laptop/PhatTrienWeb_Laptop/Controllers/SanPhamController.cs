using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhatTrienWeb_Laptop.Models;

namespace PhatTrienWeb_Laptop.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.LayDSSanPham());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new SanPham();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sp)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;

            if (context.TaoSanPham(sp) != 0)
            {
                return Redirect("/SanPham/Index");
            }
            return Redirect("/SanPham/Index");
        }

        public ActionResult Details(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["SanPham"] = context.LaySanPham(id);
            return View();
        }

        public ActionResult Edit(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["SanPham"] = context.LaySanPham(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, SanPham sp)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (context.CapNhatSanPham(sp) != 0)
            {
                return Redirect("/SanPham/Index");
            }
            return Redirect("/SanPham/Index");
        }

        public ActionResult Delete(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["SanPham"] = context.LaySanPham(id);
            if (context.XoaSanPham(id) != 0)
            {
                return Redirect("/SanPham/Index");
            }
            return Redirect("/SanPham/Index");
        }
    }
}
