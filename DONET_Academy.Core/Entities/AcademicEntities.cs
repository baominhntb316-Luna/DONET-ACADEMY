using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DONET_Academy.Core.Entities
{
    [Table("KhoiLop")]
    public class KhoiLop
    {
        [Key]
        public int MaKhoiLop { get; set; }
        [Required, MaxLength(50)]
        public string TenKhoi { get; set; } = string.Empty;
        public int ThuTu { get; set; } = 10;

        public virtual ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();
        public virtual ICollection<HoSoHocSinh> HoSoHocSinhs { get; set; } = new List<HoSoHocSinh>();
        public virtual ICollection<KhoaHocTriThuc> KhoaHocTriThucs { get; set; } = new List<KhoaHocTriThuc>();
    }

    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public int MaMonHoc { get; set; }
        [Required, MaxLength(100)]
        public string TenMonHoc { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? MoTa { get; set; }
        public int? MaKhoiLop { get; set; }
        public virtual KhoiLop? KhoiLop { get; set; }
        [MaxLength(100)]
        public string? IconName { get; set; }

        public virtual ICollection<ToHop_MonHoc> ToHop_MonHocs { get; set; } = new List<ToHop_MonHoc>();
        public virtual ICollection<GiaoVien_MonHoc> GiaoVien_MonHocs { get; set; } = new List<GiaoVien_MonHoc>();
        public virtual ICollection<KhoaHocTriThuc> KhoaHocTriThucs { get; set; } = new List<KhoaHocTriThuc>();
        public virtual ICollection<LichRanhGiaoVien> LichRanhGiaoViens { get; set; } = new List<LichRanhGiaoVien>();
        public virtual ICollection<BoDe> BoDes { get; set; } = new List<BoDe>();
        public virtual ICollection<BaiTapGiao> BaiTapGiaos { get; set; } = new List<BaiTapGiao>();
    }

    [Table("ToHopMon")]
    public class ToHopMon
    {
        [Key]
        public int MaToHopMon { get; set; }
        [Required, MaxLength(50)]
        public string TenToHop { get; set; } = string.Empty; // A00, B00, C00, D01...
        [MaxLength(250)]
        public string? MoTa { get; set; }

        public virtual ICollection<ToHop_MonHoc> ToHop_MonHocs { get; set; } = new List<ToHop_MonHoc>();
        public virtual ICollection<HocSinh_ToHop> HocSinh_ToHops { get; set; } = new List<HocSinh_ToHop>();
    }

    [Table("ToHop_MonHoc")]
    public class ToHop_MonHoc
    {
        public int MaToHopMon { get; set; }
        public virtual ToHopMon? ToHopMon { get; set; }

        public int MaMonHoc { get; set; }
        public virtual MonHoc? MonHoc { get; set; }
    }

    [Table("HocSinh_ToHop")]
    public class HocSinh_ToHop
    {
        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int MaToHopMon { get; set; }
        public virtual ToHopMon? ToHopMon { get; set; }

        public DateTime NgayChon { get; set; } = DateTime.UtcNow;
    }

    [Table("KhoaHocTriThuc")]
    public class KhoaHocTriThuc
    {
        [Key]
        public int MaKhoaHoc { get; set; }
        [Required, MaxLength(200)]
        public string TenKhoaHoc { get; set; } = string.Empty;
        public string? MoTa { get; set; }

        public int MaMonHoc { get; set; }
        public virtual MonHoc? MonHoc { get; set; }

        public int? MaKhoiLop { get; set; }
        public virtual KhoiLop? KhoiLop { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaTien { get; set; } = 0;
        [MaxLength(500)]
        public string? HinhAnh { get; set; }
        public bool DaPhatHanh { get; set; } = true;
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ChuongHoc> ChuongHocs { get; set; } = new List<ChuongHoc>();
        public virtual ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; } = new List<DangKyKhoaHoc>();
    }

    [Table("ChuongHoc")]
    public class ChuongHoc
    {
        [Key]
        public int MaChuongHoc { get; set; }
        public int MaKhoaHoc { get; set; }
        public virtual KhoaHocTriThuc? KhoaHoc { get; set; }

        [Required, MaxLength(200)]
        public string TenChuong { get; set; } = string.Empty;
        public int ThuTu { get; set; } = 1;

        public virtual ICollection<BaiHoc> BaiHocs { get; set; } = new List<BaiHoc>();
    }

    [Table("BaiHoc")]
    public class BaiHoc
    {
        [Key]
        public int MaBaiHoc { get; set; }
        public int MaChuongHoc { get; set; }
        public virtual ChuongHoc? ChuongHoc { get; set; }

        [Required, MaxLength(200)]
        public string TieuDe { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? VideoUrl { get; set; }
        public string? NoiDung { get; set; }
        public int ThoiLuongPhut { get; set; } = 15;
        public int ThuTu { get; set; } = 1;
        public bool MienPhiXemTruoc { get; set; } = false;

        public virtual ICollection<TienDoBaiHoc> TienDoBaiHocs { get; set; } = new List<TienDoBaiHoc>();
    }

    [Table("DangKyKhoaHoc")]
    public class DangKyKhoaHoc
    {
        [Key]
        public int MaDangKy { get; set; }
        public int MaKhoaHoc { get; set; }
        public virtual KhoaHocTriThuc? KhoaHoc { get; set; }

        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public DateTime NgayDangKy { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTienThanhToan { get; set; } = 0;
        public bool TrangThai { get; set; } = true;
    }

    [Table("TienDoBaiHoc")]
    public class TienDoBaiHoc
    {
        [Key]
        public int MaTienDo { get; set; }
        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int MaBaiHoc { get; set; }
        public virtual BaiHoc? BaiHoc { get; set; }

        public bool DaHoanThanh { get; set; } = false;
        public int ThoiGianHocGiay { get; set; } = 0;
        public DateTime NgayCapNhat { get; set; } = DateTime.UtcNow;
    }
}

