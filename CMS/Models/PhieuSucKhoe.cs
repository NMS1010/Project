using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    [Table("PhieuSucKhoe")]
    public class PhieuSucKhoe
    {
        public int Id { get; set; }

        public int IdLichTiem { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool TrangThai { get; set; }

        public double ChieuCao { get; set; }

        public double CanNang { get; set; }

        public string DiUng { get; set; }

        public string BenhHienTai { get; set; }

        public bool DangMangThai { get; set; }

        public bool DangDieuTriBenh { get; set; }

        public string TenBenhNhan { get; set; }
        public string DiaChi { get; set; }

        public DateTime NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        public string SoDienThoai { get; set; }
    }
}