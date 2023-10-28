using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CMS.Models
{
    public partial class QLTIEM : DbContext
    {
        public QLTIEM()
            : base("name=QLTIEM")
        {
        }

        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichTiem> LichTiems { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<VacXin> VacXins { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<PhieuSucKhoe> PhieuSucKhoes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Ten)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();
        }
    }
}