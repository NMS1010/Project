using Api.Dtos;
using Api.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatLichController : Controller
    {
        private readonly Context _db;
        public DatLichController(Context db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("datlich")]
        public async Task<IActionResult> DatLich(LichTiemDto dto)
        {
            var lich = new LichTiem();
            lich.IdKh = dto.IdKh;
            lich.IdVacXin = dto.IdVacXin;
            lich.NgayTiem = dto.ThoiGian;
            lich.DiaDiemTiem = dto.DiaDiem;
            lich.TrangThai = 1;
            await _db.LichTiems.AddAsync(lich);
            await _db.SaveChangesAsync();
            var kh = await _db.KhachHangs.FindAsync(dto.IdKh);
            await SendMail(kh.Email, dto.ThoiGian);
            return Ok("Success");
        }

        [HttpGet]
        [Route("vacxin")]
        public async Task<IActionResult> VacXin()
        {
            var result = await _db.VacXins.ToListAsync();
            foreach(var item in result)
            {
                var ncc = _db.NhaCungCaps.Find(int.Parse(item.Nccid));
                if (ncc != null)
                {
                    item.Ten = item.Ten + " - " + ncc.Ten;
                }
            }    
            return Ok(result);
        }

        private async Task SendMail(string emailRe, DateTime thoigian)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Hệ thống tiêm chủng ",""));
            email.To.Add(new MailboxAddress("Khách hàng", emailRe));
            email.Subject = "Thông báo lịch tiêm chủng";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<b>Bạn có lịch tiêm vào ngày : {thoigian.ToString("dd/MM/yyyy")} </b>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("duongnm110198@gmail.com", "...");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
