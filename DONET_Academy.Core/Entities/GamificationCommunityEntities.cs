using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DONET_Academy.Core.Entities
{
    [Table("MauNhiemVu")]
    public class MauNhiemVu
    {
        [Key]
        public int MaMauNhiemVu { get; set; }
        [Required, MaxLength(150)]
        public string TenNhiemVu { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public int PhanThuongXP { get; set; } = 50;
        [MaxLength(100)]
        public string? IconName { get; set; }

        public virtual ICollection<NhiemVuNgay> NhiemVuNgays { get; set; } = new List<NhiemVuNgay>();
    }

    [Table("NhiemVuNgay")]
    public class NhiemVuNgay
    {
        [Key]
        public int MaNhiemVuNgay { get; set; }
        public int MaMauNhiemVu { get; set; }
        public virtual MauNhiemVu? MauNhiemVu { get; set; }

        public DateTime NgayApDung { get; set; } = DateTime.UtcNow.Date;
        public int SoLuongYeuCau { get; set; } = 1;

        public virtual ICollection<TienDoNhiemVu> TienDoNhiemVus { get; set; } = new List<TienDoNhiemVu>();
    }

    [Table("TienDoNhiemVu")]
    public class TienDoNhiemVu
    {
        [Key]
        public int MaTienDoNhiemVu { get; set; }
        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int MaNhiemVuNgay { get; set; }
        public virtual NhiemVuNgay? NhiemVuNgay { get; set; }

        public int TienDoHienTai { get; set; } = 0;
        public bool DaHoanThanh { get; set; } = false;
        public bool DaNhanThuong { get; set; } = false;
    }

    [Table("CapDo")]
    public class CapDo
    {
        [Key]
        public int MaCapDo { get; set; }
        [Required, MaxLength(50)]
        public string TenCapDo { get; set; } = "Tập sự";
        public int DiemXPToiThieu { get; set; } = 0;
        [MaxLength(100)]
        public string? IconHuyHieu { get; set; }

        public virtual ICollection<HoSoHocSinh> HoSoHocSinhs { get; set; } = new List<HoSoHocSinh>();
    }

    [Table("QuotaAI")]
    public class QuotaAI
    {
        [Key]
        public int MaQuotaAI { get; set; }
        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int SoLuotToiDaNgay { get; set; } = 20;
        public int SoLuotDaDung { get; set; } = 0;
        public DateTime NgayReset { get; set; } = DateTime.UtcNow.Date;
    }

    [Table("GoiPremium")]
    public class GoiPremium
    {
        [Key]
        public int MaGoiPremium { get; set; }
        [Required, MaxLength(100)]
        public string TenGoi { get; set; } = "Gói Học Tốt Toàn Diện";

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaThang { get; set; } = 99000;
        public string? MoTa { get; set; }
        public string? UuDai { get; set; }

        public virtual ICollection<HoSoHocSinh> HoSoHocSinhs { get; set; } = new List<HoSoHocSinh>();
    }

    [Table("BaiDang")]
    public class BaiDang
    {
        [Key]
        public int MaBaiDang { get; set; }
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        [Required, MaxLength(250)]
        public string TieuDe { get; set; } = string.Empty;
        [Required]
        public string NoiDung { get; set; } = string.Empty;
        public DateTime NgayDang { get; set; } = DateTime.UtcNow;
        public int LuotXem { get; set; } = 0;
        public bool TrangThai { get; set; } = true;

        public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }

    [Table("BinhLuan")]
    public class BinhLuan
    {
        [Key]
        public int MaBinhLuan { get; set; }
        public int MaBaiDang { get; set; }
        public virtual BaiDang? BaiDang { get; set; }

        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        [Required]
        public string NoiDung { get; set; } = string.Empty;
        public DateTime NgayBinhLuan { get; set; } = DateTime.UtcNow;
    }

    [Table("Vote")]
    public class Vote
    {
        public int MaBaiDang { get; set; }
        public virtual BaiDang? BaiDang { get; set; }

        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        public int DiemVote { get; set; } = 1; // +1 hoặc -1
    }

    [Table("TheoDoi")]
    public class TheoDoi
    {
        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        public DateTime NgayTheoDoi { get; set; } = DateTime.UtcNow;
    }

    [Table("ThongBao")]
    public class ThongBao
    {
        [Key]
        public int MaThongBao { get; set; }
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        [Required, MaxLength(200)]
        public string TieuDe { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? LinkLienKet { get; set; }
        public bool DaDoc { get; set; } = false;
        public DateTime NgayGui { get; set; } = DateTime.UtcNow;
    }

    [Table("BaoCaoViPham")]
    public class BaoCaoViPham
    {
        [Key]
        public int MaBaoCao { get; set; }
        public int MaNguoiDungBaoCao { get; set; }
        public virtual NguoiDung? NguoiDungBaoCao { get; set; }

        [Required, MaxLength(50)]
        public string LoaiDoiTuong { get; set; } = "BaiDang"; // BaiDang, BinhLuan, NguoiDung
        public int MaDoiTuong { get; set; }
        [Required, MaxLength(500)]
        public string LyDo { get; set; } = string.Empty;
        public bool DaXuLy { get; set; } = false;
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
    }

    [Table("CauHinhHeThong")]
    public class CauHinhHeThong
    {
        [Key]
        public int MaCauHinh { get; set; }
        [Required, MaxLength(100)]
        public string Khoa { get; set; } = string.Empty;
        [Required]
        public string GiaTri { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? MoTa { get; set; }
    }

    [Table("BaoCaoDoanhThuAdmin")]
    public class BaoCaoDoanhThuAdmin
    {
        [Key]
        public int MaBaoCao { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongDoanhThu { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal DoanhThuSan { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal DoanhThuGiaoVien { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
    }

    [Table("BaoCaoDoanhThuGiaoVien")]
    public class BaoCaoDoanhThuGiaoVien
    {
        [Key]
        public int MaBaoCao { get; set; }
        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        public int Thang { get; set; }
        public int Nam { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongThuNhap { get; set; }

        public int SoBuoiDay { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
    }
}

