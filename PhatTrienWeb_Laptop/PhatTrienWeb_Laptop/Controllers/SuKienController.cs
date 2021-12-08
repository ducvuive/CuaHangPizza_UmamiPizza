using PhatTrienWeb_Laptop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Controllers
{
    public class SuKienController : Controller
    {
        // GET: KhachHangController
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            return View(context.laySuKien());
        }
        // GET: SuKienController
        /*  public ActionResult Index()
          {
              return View();
          }*/

        // GET: SuKienController/Details/5
        public ActionResult Details(SuKien sk)
        {
            return View(sk);
        }

        // GET: SuKienController/Create
        public ActionResult Create()
        {
            var model = new SuKien();
            return View();
        }

        // POST: SuKienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuKien sk)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            if (!ModelState.IsValid)
            {
                return View(sk);
            }
            else if (context.capNhatSuKien(sk) == 0)
            {
                ModelState.AddModelError("", "Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
            }
            else
            {
                return Redirect("/SuKien/Index");
            }
            return Redirect("/SuKien/Index");
        }

        // GET: SuKienController/Edit/5
        public ActionResult Edit(string mask)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            SuKien sk = context.laySuKien(mask);
            return View(sk);
        }

        // POST: SuKienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuKien sk)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            //ViewBag.greet = makh;
            if(context.capNhatSuKien(sk) == 0)
            {
                ModelState.AddModelError("", "Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
            }
            else
            {
                return Redirect("/SuKien/Index");
            }
            return View(sk);
        }

        // GET: SuKienController/Delete/5
        public ActionResult Delete(SuKien sk)
        {
            return View(sk);
        }

        // POST: SuKienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string mask)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(PhatTrienWeb_Laptop.Models.LapTopContext)) as LapTopContext;
            //ViewBag.greet = makh;
            if (context.xoaSuKien(mask) != 0)
            {
                return Redirect("/SuKien/Index");
            }
            return Redirect("/SuKien/Index");
        }
    }
}
