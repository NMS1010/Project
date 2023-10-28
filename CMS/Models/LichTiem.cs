namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichTiem")]
    public partial class LichTiem
    {
        public int Id { get; set; }

        public int IdKH { get; set; }

        [StringLength(50)]
        public string DiaDiemTiem { get; set; }

        public DateTime? NgayTiem { get; set; }

        public int? IdVacXin { get; set; }
        public int? IdBacSi{ get; set; }

        public int? TrangThai { get; set; }

        [NotMapped]
        public string TRANGTHAI { get; set; }

        [NotMapped]
        public string NGAYTIEM { get; set; }
    }
}