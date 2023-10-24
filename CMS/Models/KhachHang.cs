namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public int? SoDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string CCCD { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [NotMapped]
        public string NGAYSINHs { get; set; }
    }
}
