using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Windows.Input;

namespace CMS.Controllers
{
    public class NhanVienController : Controller
    {
        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        // GET: NhanVien
        private readonly QLTIEM _db = new QLTIEM();

        [HttpGet]
        public ActionResult Index()
        {
            var result = _db.NhanViens.ToList();
            return View(result);
        }

        [HttpPost]
        public Boolean CreateOrUpdate(NhanVien modal)
        {
            try
            {
                if (modal.Id == 0)
                {
                    var res = _db.NhanViens.Where(x => x.TaiKhoan == modal.TaiKhoan).FirstOrDefault();
                    if(res != null)
                    {
                        return false;
                    }
                    //modal.Quyen = " NhanVien";
                    modal.MatKhau = Encrypt(modal.MatKhau);
                    _db.NhanViens.Add(modal);
                    _db.SaveChanges();
                }
                else
                {
                    var result = _db.NhanViens.Find(modal.Id);
                    modal.TaiKhoan = result.TaiKhoan;
                    //modal.Quyen = result.Quyen;
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

        private string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
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