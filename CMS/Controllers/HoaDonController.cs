using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly QLTIEM _db = new QLTIEM();

        // GET: HoaDon
        [HttpGet]
        public ActionResult Index()
        {
            var hoadons = _db.HoaDons.ToList();
            var lichtiems = new List<LichTiem>();
            hoadons.ForEach(x =>
            {
                var lt = _db.LichTiems.Find(x.IdLichTiem);
                lichtiems.Add(lt);
            });
            var vacxins = new List<VacXin>();
            lichtiems.ForEach(x =>
            {
                var lt = _db.VacXins.Find(x.IdVacXin);
                vacxins.Add(lt);
            });
            ViewBag.LichTiem = lichtiems;
            ViewBag.Vacxin = vacxins;
            ViewBag.Result = hoadons;
            return View();
        }

        [HttpPost]
        public int Create(int idLichTiem)
        {
            var hd = _db.HoaDons.Where(x => x.IdLichTiem == idLichTiem).FirstOrDefault();
            if (hd != null)
            {
                return -1;
            }
            var trans = _db.Database.BeginTransaction();
            try
            {
                var lichtiem = _db.LichTiems.Where(x => x.Id == idLichTiem).FirstOrDefault();
                var vacxin = _db.VacXins.Where(x => x.Id == lichtiem.IdVacXin).FirstOrDefault();
                var phieuSucKhoe = _db.PhieuSucKhoes.Where(x => x.IdLichTiem == lichtiem.Id).FirstOrDefault();
                var hoadon = new HoaDon()
                {
                    IdLichTiem = lichtiem.Id,
                    NgayThanhToan = DateTime.Now,
                    NguoiThanhToan = phieuSucKhoe.TenBenhNhan,
                    TongTien = vacxin.GiaTien
                };
                vacxin.SoLuong -= 1;

                _db.VacXins.AddOrUpdate(vacxin);
                _db.HoaDons.Add(hoadon);

                _db.SaveChanges();
                trans.Commit();
                return 1;
            }
            catch
            {
                trans.Rollback();
                return 0;
            }
        }
    }
}