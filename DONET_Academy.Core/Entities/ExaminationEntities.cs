using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Core.Entities
{
    [Table("BoDe")]
    public class BoDe
    {
        [Key]
        public int MaBoDe { get; set; }
        [Required, MaxLength(200)]
        public string TieuDe { get; set; } = string.Empty;
        public int MaMonHoc { get; set; }
        public virtual MonHoc? MonHoc { get; set; }

        public int ThoiGianLamBaiPhut { get; set; } = 45;
        public int SoCauHoi { get; set; } = 40;
        public double DiemToiDa { get; set; } = 10.0;
        public bool DaXuatBan { get; set; } = true;
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ChiTietDe> ChiTietDes { get; set; } = new List<ChiTietDe>();
        public virtual ICollection<BaiLam> BaiLams { get; set; } = new List<BaiLam>();
        public virtual ICollection<BaiTapGiao> BaiTapGiaos { get; set; } = new List<BaiTapGiao>();
    }

    [Table("ChiTietDe")]
    public class ChiTietDe
    {
        [Key]
        public int MaChiTietDe { get; set; }
        public int MaBoDe { get; set; }
        public virtual BoDe? BoDe { get; set; }

        public int MaCauHoi { get; set; }
        public virtual CauHoi? CauHoi { get; set; }

        public int ThuTu { get; set; } = 1;
        public double DiemCau { get; set; } = 0.25;
    }

    [Table("CauHoi")]
    public class CauHoi
    {
        [Key]
        public int MaCauHoi { get; set; }
        [Required]
        public string NoiDung { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? HinhAnh { get; set; }
        public MucDoCauHoi MucDo { get; set; } = MucDoCauHoi.ThongHieu;
        public string? GiaiThichChiTiet { get; set; }

        public virtual ICollection<DapAn> DapAns { get; set; } = new List<DapAn>();
        public virtual ICollection<ChiTietDe> ChiTietDes { get; set; } = new List<ChiTietDe>();
        public virtual ICollection<ChiTietBaiLam> ChiTietBaiLams { get; set; } = new List<ChiTietBaiLam>();
    }

    [Table("DapAn")]
    public class DapAn
    {
        [Key]
        public int MaDapAn { get; set; }
        public int MaCauHoi { get; set; }
        public virtual CauHoi? CauHoi { get; set; }

        [Required]
        public string NoiDung { get; set; } = string.Empty;
        public bool LaDapAnDung { get; set; } = false;
        public int ThuTu { get; set; } = 1; // A, B, C, D
    }

    [Table("BaiLam")]
    public class BaiLam
    {
        [Key]
        public int MaBaiLam { get; set; }
        public int MaBoDe { get; set; }
        public virtual BoDe? BoDe { get; set; }

        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public DateTime ThoiGianBatDau { get; set; } = DateTime.UtcNow;
        public DateTime? ThoiGianNop { get; set; }
        public double TongDiem { get; set; } = 0;
        public int SoCauDung { get; set; } = 0;
        public bool DaNop { get; set; } = false;

        public virtual ICollection<ChiTietBaiLam> ChiTietBaiLams { get; set; } = new List<ChiTietBaiLam>();
        public virtual ICollection<NopBaiTap> NopBaiTaps { get; set; } = new List<NopBaiTap>();
    }

    [Table("ChiTietBaiLam")]
    public class ChiTietBaiLam
    {
        [Key]
        public int MaChiTietBaiLam { get; set; }
        public int MaBaiLam { get; set; }
        public virtual BaiLam? BaiLam { get; set; }

        public int MaCauHoi { get; set; }
        public virtual CauHoi? CauHoi { get; set; }

        public int? MaDapAnChon { get; set; }
        public virtual DapAn? DapAnChon { get; set; }

        public bool DungSai { get; set; } = false;
        public double DiemDatDuoc { get; set; } = 0;
    }

    [Table("BaiTapGiao")]
    public class BaiTapGiao
    {
        [Key]
        public int MaBaiTapGiao { get; set; }
        public int MaBoDe { get; set; }
        public virtual BoDe? BoDe { get; set; }

        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        public int MaMonHoc { get; set; }
        public virtual MonHoc? MonHoc { get; set; }

        [Required, MaxLength(200)]
        public string TieuDe { get; set; } = string.Empty;
        public DateTime HanNop { get; set; }
        public string? GhiChu { get; set; }

        public virtual ICollection<NopBaiTap> NopBaiTaps { get; set; } = new List<NopBaiTap>();
    }

    [Table("NopBaiTap")]
    public class NopBaiTap
    {
        [Key]
        public int MaNopBaiTap { get; set; }
        public int MaBaiTapGiao { get; set; }
        public virtual BaiTapGiao? BaiTapGiao { get; set; }

        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int? MaBaiLam { get; set; }
        public virtual BaiLam? BaiLam { get; set; }

        public DateTime NgayNop { get; set; } = DateTime.UtcNow;
        public double? DiemSo { get; set; }
        [MaxLength(500)]
        public string? NhanXetGiaoVien { get; set; }
    }
}

