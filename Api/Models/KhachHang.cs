using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class KhachHang
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public int? SoDt { get; set; }
        public string? Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Cccd { get; set; }
        public string? MatKhau { get; set; }

        public int? TrangThai { get; set; }

        public string? Token { get; set; }
    }
}
