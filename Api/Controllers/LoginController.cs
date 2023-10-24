using Api.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop.Infrastructure;
using MimeKit;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly Context _db;
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public LoginController(Context db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("dangnhap")]
        public async Task<IActionResult> DangNhap(int sodt,string password)
        {
            var pass = Encrypt(password);
            var result = await  _db.KhachHangs.Where(x => x.SoDt == sodt && x.MatKhau == pass && x.TrangThai == 1).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("Tài khoản or mật khẩu không đúng !!.");
            }
            else
            {
                return Ok(result);
            }    
        }

        [HttpPost]
        [Route("dangky")]
        public async Task<IActionResult> DangKy(KhachHang dto)
        {
            dto.Id = 0;
            string token = Guid.NewGuid().ToString();
            dto.MatKhau = Encrypt(dto.MatKhau);
            dto.TrangThai = 2;
            dto.Token = token;
            if (dto.NgaySinh== null)
            {
                dto.NgaySinh = DateTime.UtcNow;
            }
            await _db.KhachHangs.AddAsync(dto);
            await _db.SaveChangesAsync();
            await SendMail(dto.Email, token);
            return Ok();
        }

        [HttpGet]
        [Route("Verify")]
        public async Task<IActionResult> Verify(string token)
        {
            var result = _db.KhachHangs.Where(x => x.Token == token).FirstOrDefault();
            if (result != null)
            {
                result.TrangThai = 1;
            }
             _db.KhachHangs.Update(result);
            await _db.SaveChangesAsync();
            return Ok();
        }

        private async Task SendMail(string emailRe,string token)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Xác thực người dùng ", ""));
            email.To.Add(new MailboxAddress("Khách hàng", emailRe));
            email.Subject = "Đăng ký người dùng";
            string url = $"https://localhost:44300/Login/Verify?token={token}";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<a href='{url}'> Xác thực đăng ký </a>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("duongnm110198@gmail.com", "...");
                smtp.Send(email);
                smtp.Disconnect(true);
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
