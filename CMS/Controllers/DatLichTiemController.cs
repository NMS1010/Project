using Antlr.Runtime;
using CMS.Models;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class DatLichTiemController : Controller
    {
        private readonly QLTIEM _db = new QLTIEM();

        public class LichTiemDto
        {
            public int Id { get; set; }
            public string TenVacxin { get; set; }
            public string DiaDiemTiem { get; set; }
            public DateTime NgayTiem { get; set; }
            public int TrangThai { get; set; }
        }

        [HttpGet]
        public ActionResult GetOne(int id)
        {
            var lichTiem = _db.LichTiems.Find(id);
            var phieuSucKhoe = _db.PhieuSucKhoes.Where(x => x.IdLichTiem == lichTiem.Id).FirstOrDefault();
            var trangThai = "";
            switch (lichTiem.TrangThai)
            {
                case 0:
                    trangThai = "Từ chối";
                    break;

                case 1:
                    trangThai = "Đã phê duyệt";
                    break;

                case 2:
                    trangThai = "Đã tiêm";
                    break;

                case 3:
                    trangThai = "Đã chờ sau tiêm";
                    break;

                default:
                    trangThai = "Chưa phê duyệt";
                    break;
            }
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            string qr = $@"
                Mã lịch tiêm: #{lichTiem.Id}
                Mã phiếu khám: #{phieuSucKhoe.Id}
                Tên bệnh nhân: {phieuSucKhoe.TenBenhNhan}
                Địa điểm tiêm: {lichTiem.DiaDiemTiem}
                Ngày tiêm: {lichTiem.NgayTiem.Value}
                Trạng thái: {trangThai}
            ";
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(60);
            ImageConverter converter = new ImageConverter();
            byte[] BitmapArray = (byte[])converter.ConvertTo(QrBitmap, typeof(byte[]));
            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));

            return Json(new { phieuSucKhoe = phieuSucKhoe, qrCode = QrUri }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var kh = Session["KhachHang"] as KhachHang;
            if (kh == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var result = _db.LichTiems.Where(x => x.IdKH == kh.Id).ToList();
            var vacxins = _db.VacXins.ToList();
            var resp = new List<LichTiemDto>();
            result.ForEach(x =>
            {
                resp.Add(new LichTiemDto()
                {
                    DiaDiemTiem = x.DiaDiemTiem,
                    NgayTiem = x.NgayTiem.Value,
                    Id = x.Id,
                    TenVacxin = _db.VacXins.Find(x.IdVacXin)?.Ten,
                    TrangThai = x.TrangThai.Value
                });
            });
            ViewData["Result"] = resp;
            ViewData["Vacxin"] = vacxins;
            return View();
        }

        [HttpPost]
        public bool Index(FormCollection formCollection)
        {
            var trans = _db.Database.BeginTransaction();
            try
            {
                var lichTiem = new LichTiem()
                {
                    IdVacXin = int.Parse(formCollection["vacxin"]),
                    DiaDiemTiem = formCollection["diadiem"] ?? "",
                    NgayTiem = DateTime.Parse(formCollection["ngaytiem"]),
                    IdKH = (Session["KhachHang"] as KhachHang).Id,
                    TrangThai = -1
                };
                _db.LichTiems.Add(lichTiem);
                _db.SaveChanges();

                var phieu = new PhieuSucKhoe()
                {
                    IdLichTiem = lichTiem.Id,
                    TenBenhNhan = formCollection["ten"],
                    DiaChi = formCollection["diachi"],
                    SoDienThoai = formCollection["sodt"],
                    NgaySinh = DateTime.Parse(formCollection["ngaysinh"]),
                    GioiTinh = formCollection["gioitinh"],
                    ChieuCao = double.Parse(formCollection["chieucao"]),
                    CanNang = double.Parse(formCollection["cannang"]),
                    DiUng = formCollection["diung"] ?? "",
                    BenhHienTai = formCollection["benhhientai"] ?? "",
                    DangMangThai = bool.Parse(formCollection["mangthai"]),
                    DangDieuTriBenh = bool.Parse(formCollection["dieutri"]),
                    NgayTao = DateTime.Now,
                };
                _db.PhieuSucKhoes.Add(phieu);
                _db.SaveChanges();

                trans.Commit();

                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }
    }
}