using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhatTrienWeb_Laptop.Models;

namespace PhatTrienWeb_Laptop.Controllers
{
    public class BoXuLyController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.LayDSBoXuLy());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new BoXuLy();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoXuLy bxl)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;

            if (context.TaoBoXuLy(bxl) != 0)
            {
                return Redirect("/BoXuLy/Index");
            }
            return Redirect("/BoXuLy/Index");
        }

        public ActionResult Details(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["BoXuLy"] = context.LayBoXuLy(id);
            return View();
        }

        public ActionResult Edit(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["BoXuLy"] = context.LayBoXuLy(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, BoXuLy bxl)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (context.CapNhatBoXuLy(bxl) != 0)
            {
                return Redirect("/BoXuLy/Index");
            }
            return Redirect("/BoXuLy/Index");
        }

        public ActionResult Delete(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["BoXuLy"] = context.LayBoXuLy(id);
            if (context.XoaBoXuLy(id) != 0)
            {
                return Redirect("/BoXuLy/Index");
            }
            return Redirect("/BoXuLy/Index");
        }
    }
}
