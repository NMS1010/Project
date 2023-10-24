using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly Context _db;
        public ProfileController(Context db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("xemthongtincanhan")]
        public async Task<IActionResult> XemThongTinCaNhan(int idKh)
        {
            var result = await _db.KhachHangs.FindAsync(idKh);
            return Ok(result);
        }

        [HttpGet]
        [Route("xemlichsu")]
        public async Task<IActionResult> XemLichSu(int idKh)
        {
            var result = await _db.LichTiems.Where(x => x.IdKh == idKh).ToListAsync();
            foreach(var item in result)
            {
                if (item.TrangThai == 1) { item.Status = "Chưa Tiêm"; }
                else if (item.TrangThai == 2) { item.Status = "Đã Tiêm"; }
                else { item.Status = "Từ chối"; }
            }
            return Ok(result);
        }
    }
}