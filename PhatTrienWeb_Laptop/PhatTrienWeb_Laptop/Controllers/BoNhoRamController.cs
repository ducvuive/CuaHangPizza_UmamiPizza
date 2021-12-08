using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhatTrienWeb_Laptop.Models;

namespace PhatTrienWeb_Laptop.Controllers
{
    public class BoNhoRamController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.LayDSBoNhoRAM());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new BoNhoRAM();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoNhoRAM ram)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;

            if (context.TaoBoNhoRAM(ram) != 0)
            {
                return Redirect("/BoNhoRam/Index");
            }
            return Redirect("/BoNhoRam/Index");
        }

        public ActionResult Details(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["BoNhoRam"] = context.LayBoNhoRAM(id);
            return View();
        }

        public ActionResult Edit(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["BoNhoRam"] = context.LayBoNhoRAM(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, BoNhoRAM ram)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (context.CapNhatBoNhoRAM(ram) != 0)
            {
                return Redirect("/BoNhoRam/Index");
            }
            return Redirect("/BoNhoRam/Index");
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, BoNhoRAM ram)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            ViewData["BoNhoRam"] = context.LayBoNhoRAM(id);
            if (context.XoaBoNhoRAM(id) != 0)
            {
                return Redirect("/BoNhoRam/Index");
            }
            return Redirect("/BoNhoRam/Index");
        }
    }
}
