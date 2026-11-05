using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? HoTen { get; set; }
        public string? AnhDaiDien { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
        public int? MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
    }

    public class ApplicationRole : IdentityRole<int>
    {
        public string? MoTa { get; set; }
    }

    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int MaTaiKhoan { get; set; }
        [Required, MaxLength(100)]
        public string TenDangNhap { get; set; } = string.Empty;
        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string MatKhauHash { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
        public bool TrangThai { get; set; } = true;

        public virtual NguoiDung? NguoiDung { get; set; }
        public virtual ICollection<TaiKhoan_VaiTro> TaiKhoan_VaiTros { get; set; } = new List<TaiKhoan_VaiTro>();
    }

    [Table("VaiTro")]
    public class VaiTro
    {
        [Key]
        public int MaVaiTro { get; set; }
        [Required, MaxLength(50)]
        public string TenVaiTro { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? MoTa { get; set; }

        public virtual ICollection<TaiKhoan_VaiTro> TaiKhoan_VaiTros { get; set; } = new List<TaiKhoan_VaiTro>();
    }

    [Table("TaiKhoan_VaiTro")]
    public class TaiKhoan_VaiTro
    {
        public int MaTaiKhoan { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }

        public int MaVaiTro { get; set; }
        public virtual VaiTro? VaiTro { get; set; }
    }

    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }
        public int MaTaiKhoan { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }

        [Required, MaxLength(150)]
        public string HoTen { get; set; } = string.Empty;
        [MaxLength(20)]
        public string? SoDienThoai { get; set; }
        [MaxLength(500)]
        public string? AnhDaiDien { get; set; }
        public DateTime? NgaySinh { get; set; }
        [MaxLength(10)]
        public string? GioiTinh { get; set; }
        [MaxLength(250)]
        public string? DiaChi { get; set; }

        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }
        public virtual ViTien? ViTien { get; set; }
        public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();
        public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
        public virtual ICollection<ThongBao> ThongBaos { get; set; } = new List<ThongBao>();
        public virtual ICollection<BaoCaoViPham> BaoCaoViPhams { get; set; } = new List<BaoCaoViPham>();
    }

    [Table("HoSoHocSinh")]
    public class HoSoHocSinh
    {
        [Key]
        public int MaHoSoHocSinh { get; set; }
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        public int? MaKhoiLop { get; set; }
        public virtual KhoiLop? KhoiLop { get; set; }

        public int DiemXP { get; set; } = 0;

        public int? MaCapDo { get; set; }
        public virtual CapDo? CapDo { get; set; }

        public int? MaGoiPremium { get; set; }
        public virtual GoiPremium? GoiPremium { get; set; }
        public DateTime? NgayHetHanPremium { get; set; }

        public virtual QuotaAI? QuotaAI { get; set; }
        public virtual ICollection<HocSinh_ToHop> HocSinh_ToHops { get; set; } = new List<HocSinh_ToHop>();
        public virtual ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; } = new List<DangKyKhoaHoc>();
        public virtual ICollection<TienDoBaiHoc> TienDoBaiHocs { get; set; } = new List<TienDoBaiHoc>();
        public virtual ICollection<BaiLam> BaiLams { get; set; } = new List<BaiLam>();
        public virtual ICollection<NopBaiTap> NopBaiTaps { get; set; } = new List<NopBaiTap>();
        public virtual ICollection<TienDoNhiemVu> TienDoNhiemVus { get; set; } = new List<TienDoNhiemVu>();
        public virtual ICollection<TheoDoi> TheoDois { get; set; } = new List<TheoDoi>();
    }

    [Table("HoSoGiaoVien")]
    public class HoSoGiaoVien
    {
        [Key]
        public int MaHoSoGiaoVien { get; set; }
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        [MaxLength(1000)]
        public string? GioiThieu { get; set; }
        [MaxLength(500)]
        public string? BangCapChungChi { get; set; }
        public int SoNamKinhNghiem { get; set; } = 1;
        public double DanhGiaTB { get; set; } = 5.0;

        public TrangThaiHoSoGiaoVien TrangThaiDuyet { get; set; } = TrangThaiHoSoGiaoVien.ChoDuyet;
        [MaxLength(500)]
        public string? LyDoTuChoi { get; set; }

        public virtual ICollection<GiaoVien_MonHoc> GiaoVien_MonHocs { get; set; } = new List<GiaoVien_MonHoc>();
        public virtual ICollection<LichRanhGiaoVien> LichRanhGiaoViens { get; set; } = new List<LichRanhGiaoVien>();
        public virtual ICollection<TaiKhoanNhanTien> TaiKhoanNhanTiens { get; set; } = new List<TaiKhoanNhanTien>();
        public virtual ICollection<LenhRutTien> LenhRutTiens { get; set; } = new List<LenhRutTien>();
        public virtual ICollection<BaiTapGiao> BaiTapGiaos { get; set; } = new List<BaiTapGiao>();
        public virtual ICollection<BaoCaoDoanhThuGiaoVien> BaoCaoDoanhThuGiaoViens { get; set; } = new List<BaoCaoDoanhThuGiaoVien>();
    }

    [Table("GiaoVien_MonHoc")]
    public class GiaoVien_MonHoc
    {
        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        public int MaMonHoc { get; set; }
        public virtual MonHoc? MonHoc { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaTienMoiGio { get; set; } = 150000;
    }

    [Table("TaiKhoanNhanTien")]
    public class TaiKhoanNhanTien
    {
        [Key]
        public int MaTaiKhoanNhanTien { get; set; }
        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        [Required, MaxLength(100)]
        public string TenNganHang { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string SoTaiKhoan { get; set; } = string.Empty;
        [Required, MaxLength(150)]
        public string TenChuTaiKhoan { get; set; } = string.Empty;
        [MaxLength(150)]
        public string? ChiNhanh { get; set; }
        public bool MacDinh { get; set; } = true;

        public virtual ICollection<LenhRutTien> LenhRutTiens { get; set; } = new List<LenhRutTien>();
    }
}

