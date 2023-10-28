using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class LichTiemController : Controller
    {
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.LichTiems.ToList();
            if (Session["Menu"] == "bacsi")
            {
                var id = int.Parse(Session["BacSi"].ToString());
                result = _db.LichTiems.Where(x => x.IdBacSi == id).ToList();
            }
            ViewBag.Bacsi = _db.NhanViens.Where(x => x.Quyen.Contains("BacSi")).ToList();
            ViewBag.Result = result;
            return View();
        }

        [HttpGet]
        public Boolean CreateOrUpdate(int Id, int TrangThai, int IdBacSi, string DiaDiemTiem)
        {
            try
            {
                var result = _db.LichTiems.Find(Id);
                result.TrangThai = TrangThai;
                result.DiaDiemTiem = DiaDiemTiem;
                result.IdBacSi = IdBacSi;
                _db.LichTiems.AddOrUpdate(result);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Delete(int Id)
        {
            try
            {
                var result = _db.LichTiems.Where(x => x.Id == Id).FirstOrDefault();
                _db.LichTiems.Remove(result);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActionResult findOne(int Id)
        {
            var result = _db.LichTiems.FirstOrDefault(x => x.Id == Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}