using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class LichTiem
    {
        public int Id { get; set; }
        public int? IdKh { get; set; }
        public string? DiaDiemTiem { get; set; }
        public DateTime? NgayTiem { get; set; }
        public int? TrangThai { get; set; }
        [NotMapped]
        public string? Status { get; set; }
        public int? IdVacXin { get; set; }
    }
}
