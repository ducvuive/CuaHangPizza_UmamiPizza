using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_CuaHangLaptop.Models;

namespace DoAn_CuaHangLaptop.Controllers
{
    public class CongKetNoiController : Controller
    {
        public IActionResult Index()
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            return View(context.LayDSCongKetNoi());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CongKetNoi();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CongKetNoi ckn)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;

            if (context.TaoCongKetNoi(ckn) != 0)
            {
                return Redirect("/CongKetNoi/Index");
            }
            return Redirect("/CongKetNoi/Index");
        }

        public ActionResult Details(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["CongKetNoi"] = context.LayCongKetNoi(id);
            return View();
        }

        public ActionResult Edit(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["CongKetNoi"] = context.LayCongKetNoi(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, CongKetNoi ckn)
        {

            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            if (context.CapNhatCongKetNoi(ckn) != 0)
            {
                return Redirect("/CongKetNoi/Index");
            }
            return Redirect("/CongKetNoi/Index");
        }

        public ActionResult Delete(string id)
        {
            LapTopContext context = HttpContext.RequestServices.GetService(typeof(DoAn_CuaHangLaptop.Models.LapTopContext)) as LapTopContext;
            ViewData["CongKetNoi"] = context.LayCongKetNoi(id);
            if (context.XoaCongKetNoi(id) != 0)
            {
                return Redirect("/CongKetNoi/Index");
            }
            return Redirect("/CongKetNoi/Index");
        }
    }
}
