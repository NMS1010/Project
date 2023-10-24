using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.KhachHangs.ToList();
            ViewBag.Result = result;
            return View();
        }

        [HttpPost]
        public Boolean CreateOrUpdate(KhachHang modal)
        {
            try
            {
                if(modal.NgaySinh == null && modal.Id > 0) 
                { 

                    var result = _db.KhachHangs.Find(modal.Id);
                    modal.NgaySinh = result.NgaySinh;
                }
                _db.KhachHangs.AddOrUpdate(modal);
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
                var result = _db.KhachHangs.Where(x => x.Id == Id).FirstOrDefault();
                _db.KhachHangs.Remove(result);
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
            var result = _db.KhachHangs.FirstOrDefault(x => x.Id == Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}