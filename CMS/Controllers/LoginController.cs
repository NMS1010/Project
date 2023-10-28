using CMS.Models;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class LoginController : Controller
    {
        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private readonly QLTIEM _db = new QLTIEM();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            if (TempData["success-email"] != null)
                ViewBag.RestorePassword = TempData["success-email"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fC)
        {
            string acccount = fC["username"];
            string password = fC["password"];
            int type = int.Parse(fC["type"]);
            var pass = Encrypt(password);
            if (type == 3)
            {
                var res = _db.KhachHangs.Where(x => x.Email == acccount && x.MatKhau == pass).FirstOrDefault();
                if (res != null)
                {
                    Session["Menu"] = "khachhang";
                    Session["KhachHang"] = res;
                    return RedirectToAction("Index", "Home");
                }
            }
            var result = _db.NhanViens.Where(x => x.TaiKhoan == acccount && x.MatKhau == pass).FirstOrDefault();
            if (result != null)
            {
                if (type == 1 && result.Quyen.Contains("Admin"))
                {
                    Session["Menu"] = "admin";
                    Session["Admin"] = result.Id;
                    return RedirectToAction("Index", "NhanVien");
                }
                else if (type == 2 && result.Quyen.Contains("BacSi"))
                {
                    Session["Menu"] = "bacsi";
                    Session["BacSi"] = result.Id;
                    return RedirectToAction("Index", "LichTiem");
                }
                else if (type == 4 && result.Quyen.Contains("KeToan"))
                {
                    Session["Menu"] = "ketoan";
                    Session["KeToan"] = result.Id;
                    return RedirectToAction("Index", "VacXin");
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

        [HttpGet]
        public ActionResult DangXuat()
        {
            string menu = Session["Menu"].ToString();
            if (!string.IsNullOrEmpty(menu))
            {
                Session.Remove("KhachHang");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RestorePassword()
        {
            if (TempData["error"] != null)
                ViewBag.Error = TempData["error"];
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RestorePassword(FormCollection fC)
        {
            try
            {
                string email = fC["email"].ToString();
                var tk = _db.KhachHangs.Where(x => x.Email == email).FirstOrDefault();
                if (tk != null)
                {
                    var newPass = tk.Email + "123";
                    tk.MatKhau = Encrypt(newPass);
                    _db.KhachHangs.AddOrUpdate(tk);
                    _db.SaveChanges();
                    string content = "<h2>Chào " + tk.Ten + ", </h2><h3>Đây là mật khẩu mới cho tài khoản <em>" + tk.Email + "</em>: <p>" + newPass + "</p> </h3>" + "<h4>Bạn vui lòng không chia sẽ mật khẩu này cho bất kỳ ai. Xin cảm ơn!!!</h4>";
                    string title = "VNVC - Xác nhận đặt lại mật khẩu";
                    await SendMail(tk.Ten, tk.Email, content, title);

                    TempData["success-email"] = "Vui lòng kiểm tra email để nhận mật khẩu mới";
                    return RedirectToAction("Index", "Login");
                }
                TempData["error"] = "Email không tồn tại";
                return RedirectToAction("RestorePassword", "Login");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Email không tồn tại";
                return RedirectToAction("RestorePassword", "Login");
            }
        }

        private readonly string MJ_APIKEY_PUBLIC = "0f58e8c894d6cc32b72e4b2cb40368c6";
        private readonly string MJ_APIKEY_PRIVATE = "4b27f76ed7a6f8d36372b8abcff9381a";

        public async Task<bool> SendMail(string name, string email, string content, string title)
        {
            try
            {
                MailjetClient client = new MailjetClient(MJ_APIKEY_PUBLIC, MJ_APIKEY_PRIVATE);
                MailjetRequest request = new MailjetRequest
                {
                    Resource = Send.Resource,
                }
                   .Property(Send.FromEmail, "nmsonc81010@gmail.com")
                   .Property(Send.FromName, "VNVC - Tiêm chủng")
                   .Property(Send.Subject, title)
                   .Property(Send.HtmlPart, content)
                   .Property(Send.Recipients, new JArray {
                            new JObject {
                                 {"Email", email},
                                 {"Name", name}
                            }
                       });
                MailjetResponse response = await client.PostAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}