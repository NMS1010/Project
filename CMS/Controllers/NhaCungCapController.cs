using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.NhaCungCaps.ToList();
            ViewBag.Result = result;
            return View();
        }

        [HttpPost]
        public Boolean CreateOrUpdate(NhaCungCap modal)
        {
            try
            {
                _db.NhaCungCaps.AddOrUpdate(modal);
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
                var result = _db.NhaCungCaps.Where(x => x.Id == Id).FirstOrDefault();
                _db.NhaCungCaps.Remove(result);
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
            var result = _db.NhaCungCaps.FirstOrDefault(x => x.Id == Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}