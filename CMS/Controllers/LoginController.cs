using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class LoginController : Controller
    {
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private readonly QLTIEM _db = new QLTIEM();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fC)
        {
            string acccount = fC["username"];
            string password = fC["password"];
            int type = int.Parse(fC["type"]);
            var pass = Encrypt(password);
            var result = _db.NhanViens.Where(x => x.TaiKhoan == acccount && x.MatKhau == pass).FirstOrDefault();
            if (result != null)
            {
                if(type == 1 && result.Quyen.Contains("Admin"))
                {
                    Session["Menu"] = "admin";
                    return RedirectToAction("Index", "NhanVien");
                }    
                else if (type == 2 && result.Quyen.Contains("NhanVien")) 
                { 
                    Session["Menu"] = "nhanvien";
                    Session["NhanVienId"] = result.Id;
                    return RedirectToAction("IndexView", "LienHe");
                }
                else
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
                    return View();
                }    
            }
            else
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
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