using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int IdLichTiem { get; set; }
        public decimal TongTien { get; set; }
        public string NguoiThanhToan { get; set; }
    }
}