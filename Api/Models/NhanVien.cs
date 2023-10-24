using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class NhanVien
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public int? SoDt { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? Quyen { get; set; }
    }
}
