using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<LichTiem> LichTiems { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<VacXin> VacXins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(50)
                    .HasColumnName("CCCD");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoDt).HasColumnName("SoDT");

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<LichTiem>(entity =>
            {
                entity.ToTable("LichTiem");

                entity.Property(e => e.DiaDiemTiem).HasMaxLength(50);

                entity.Property(e => e.IdKh).HasColumnName("IdKH");

                entity.Property(e => e.NgayTiem).HasColumnType("datetime");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.ToTable("NhaCungCap");

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.Quyen)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SoDt).HasColumnName("SoDT");

                entity.Property(e => e.TaiKhoan).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<VacXin>(entity =>
            {
                entity.ToTable("VacXin");

                entity.Property(e => e.Nccid)
                    .HasMaxLength(50)
                    .HasColumnName("NCCId");

                entity.Property(e => e.SoLo).HasMaxLength(50);

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.TieuChuan).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
