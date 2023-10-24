using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        private readonly QLTIEM _db = new QLTIEM();
        public ActionResult Index()
        {
            var sovx = _db.VacXins.Count();
            ViewBag.sovx = sovx;
            var sonv = _db.NhanViens.Count();
            ViewBag.sonv = sonv;
            var sokh = _db.KhachHangs.Count();
            ViewBag.sokh = sokh;
            var soncc = _db.NhaCungCaps.Count();
            ViewBag.soncc = soncc;
            int Tong = 0;
            var loavacxin = _db.LichTiems.Where(x=> x.TrangThai == 2).Select(x=> x.IdVacXin).ToList().Distinct();
            foreach(var item in loavacxin)
            {
                var sovacxin = _db.LichTiems.Where(x => x.IdVacXin == item && x.TrangThai == 2).ToList().Count();
                int gia = _db.VacXins.Where(x => x.Id == item).Select(x=> x.GiaTien).FirstOrDefault();
                Tong = Tong + sovacxin * gia;
            }
            ViewBag.TongTien = Tong;

            return View();
        }
    }
}