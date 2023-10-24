namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? SoDT { get; set; }

        [StringLength(50)]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }
        public DateTime? NgayGui { get; set; }

        public int? NhanVienId { get; set; }

        [NotMapped]
        public string TenNhanVien { get; set; }
    }
}