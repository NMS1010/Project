using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class LienHeController : Controller
    {
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.LienHes.ToList();
            foreach (var item in result)
            {
                if(item.NhanVienId != null)
                {
                    var re = _db.NhanViens.Find(item.NhanVienId);
                    item.TenNhanVien = re.Ten;
                }    
            }
            ViewBag.Result = result;

            var nhanvien = _db.NhanViens.Where(x=> x.Quyen.Contains("NhanVien")).ToList();  
            ViewBag.NhanVien = nhanvien;
            return View();
        }

        public ActionResult findOne(int Id)
        {
            var result = _db.LienHes.FirstOrDefault(x => x.Id == Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public Boolean PhanCong(int Id, int NhanVienId)
        {
            try
            {
                var result = _db.LienHes.Find(Id);
                result.NhanVienId = NhanVienId;
                _db.LienHes.AddOrUpdate(result);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActionResult IndexView()
        {
            string Id = Session["NhanVienId"].ToString();
            var result = _db.LienHes.Where(x=> x.NhanVienId.ToString().Contains(Id)).ToList();
            ViewBag.Result = result;
            return View();
        }
    }
}