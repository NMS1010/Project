using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTIEM _db = new QLTIEM();
        // GET: Home
        public ActionResult Index()
        {
            var sonv = _db.NhanViens.Count();
            ViewBag.sonv = sonv;
            var sokh = _db.KhachHangs.Count();
            ViewBag.sokh = sokh;
            var soncc = _db.NhaCungCaps.Count();
            ViewBag.soncc = soncc;
            var sovx = _db.VacXins.Count();
            ViewBag.sovx = sovx;

            var banggia = _db.VacXins.ToList();
            foreach(var item in banggia)
            {
                var ncc = _db.NhaCungCaps.Find(int.Parse(item.NCCId));
                item.TenNCC = ncc.Ten;
            }
            ViewBag.banggia = banggia;
            return View();
        }

        [HttpPost]
        public ActionResult ConTact(FormCollection fC)
        {
            LienHe model = new LienHe();
            model.TenKH = fC["hovaten"];
            model.Email = fC["email"];
            model.SoDT = int.Parse(fC["phone"]);
            model.TieuDe = fC["tieude"];
            model.NoiDung = fC["noidung"];
            model.NgayGui = DateTime.UtcNow;
            _db.LienHes.AddOrUpdate(model);
            _db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult ConTact()
        {
            return View();
        }
    }
}