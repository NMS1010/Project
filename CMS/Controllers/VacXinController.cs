using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class VacXinController : Controller
    {
        // GET: VacXin
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.VacXins.ToList();
            ViewBag.Result = result;
            ViewBag.NhaCungCap = _db.NhaCungCaps.ToList();
            return View();
        }

        [HttpPost]
        public Boolean CreateOrUpdate(VacXin modal)
        {
            try
            {
                _db.VacXins.AddOrUpdate(modal);
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
                var result = _db.VacXins.Where(x => x.Id == Id).FirstOrDefault();
                _db.VacXins.Remove(result);
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
            var result = _db.VacXins.FirstOrDefault(x => x.Id == Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}