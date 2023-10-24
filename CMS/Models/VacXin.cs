namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VacXin")]
    public partial class VacXin
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string NCCId { get; set; }

        [StringLength(50)]
        public string TieuChuan { get; set; }

        [StringLength(50)]
        public string SoLo { get; set; }

        public int GiaTien { get; set; }

        [StringLength(50)]
        public string PhongBenh { get; set; }

        [NotMapped]
        public string TenNCC { get; set; }
    }
}
