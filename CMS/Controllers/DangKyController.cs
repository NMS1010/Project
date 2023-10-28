using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class DangKyController : Controller
    {
        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private readonly QLTIEM _db = new QLTIEM();

        // GET: DangKy
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(KhachHang model)
        {
            try
            {
                var kh = _db.KhachHangs.Where(x => x.Email == model.Email).FirstOrDefault();
                if(kh != null)
                {
                    ViewBag.Error = "Email đã tồn tại!";
                    ViewBag.KhachHang = model;
                    return View();
                }
                model.MatKhau = Encrypt(model.MatKhau);
                _db.KhachHangs.AddOrUpdate(model);
                _db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                ViewBag.Error = "Có lỗi xảy ra khi đăng ký, vui lòng kiểm tra lại thông tin";
                ViewBag.KhachHang = model;
                return View();
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
    }
}