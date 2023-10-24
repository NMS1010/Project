using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.NhanViens.ToList();
            return View(result);
        }

        [HttpPost]
        public Boolean CreateOrUpdate(NhanVien  modal)
        {
            try
            {
                if(modal.Id == 0)
                {
                    modal.Quyen = " NhanVien";
                    _db.NhanViens.Add(modal);
                    _db.SaveChanges();
                }
                else
                {
                    var result = _db.NhanViens.Find(modal.Id);
                    modal.Quyen = result.Quyen; 
                    _db.NhanViens.AddOrUpdate(modal);
                    _db.SaveChanges();
                }    
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
                var result = _db.NhanViens.Where(x => x.Id == Id).FirstOrDefault();
                _db.NhanViens.Remove(result);
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
            var result = _db.NhanViens.FirstOrDefault(x => x.Id == Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}