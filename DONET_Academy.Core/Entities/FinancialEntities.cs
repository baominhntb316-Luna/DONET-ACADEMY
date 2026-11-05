using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Core.Entities
{
    [Table("ViTien")]
    public class ViTien
    {
        [Key]
        public int MaViTien { get; set; }
        public int MaNguoiDung { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoDuKhaDung { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoDuDongBang { get; set; } = 0;

        public DateTime NgayCapNhat { get; set; } = DateTime.UtcNow;

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public virtual ICollection<GiaoDichVi> GiaoDichVis { get; set; } = new List<GiaoDichVi>();
        public virtual ICollection<GiaoDichThanhToan> GiaoDichThanhToans { get; set; } = new List<GiaoDichThanhToan>();
    }

    [Table("GiaoDichVi")]
    public class GiaoDichVi
    {
        [Key]
        public int MaGiaoDichVi { get; set; }
        public int MaViTien { get; set; }
        public virtual ViTien? ViTien { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTien { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoDuTruoc { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoDuSau { get; set; }

        public LoaiGiaoDichVi LoaiGiaoDich { get; set; }
        [MaxLength(250)]
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
        public TrangThaiGiaoDich TrangThai { get; set; } = TrangThaiGiaoDich.ThanhCong;

        public virtual ICollection<HoanTien> HoanTiens { get; set; } = new List<HoanTien>();
    }

    [Table("GiaoDichThanhToan")]
    public class GiaoDichThanhToan
    {
        [Key]
        public int MaGiaoDichThanhToan { get; set; }
        public int MaViTien { get; set; }
        public virtual ViTien? ViTien { get; set; }

        [MaxLength(100)]
        public string MaGiaoDichNgoai { get; set; } = string.Empty; // VNPAY, MoMo, VietQR
        [MaxLength(50)]
        public string PhuongThuc { get; set; } = "VietQR";

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTien { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.UtcNow;
        public TrangThaiGiaoDich TrangThai { get; set; } = TrangThaiGiaoDich.ThanhCong;
    }

    [Table("KhoanTamGiu")]
    public class KhoanTamGiu
    {
        [Key]
        public int MaKhoanTamGiu { get; set; }
        public int MaDatLich { get; set; }
        public virtual DatLich? DatLich { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTien { get; set; }
        public DateTime NgayGiu { get; set; } = DateTime.UtcNow;
        public bool DaGiaiPhong { get; set; } = false;

        public virtual PhanChiaDoanhThu? PhanChiaDoanhThu { get; set; }
    }

    [Table("ChinhSachHoaHong")]
    public class ChinhSachHoaHong
    {
        [Key]
        public int MaChinhSachHoaHong { get; set; }
        [Required, MaxLength(100)]
        public string TenChinhSach { get; set; } = "Hoa hồng tiêu chuẩn sàn 15%";
        public double TiLeSanNhan { get; set; } = 0.15; // 15%
        public DateTime NgayApDung { get; set; } = DateTime.UtcNow;
        public bool HieuLuc { get; set; } = true;

        public virtual ICollection<PhanChiaDoanhThu> PhanChiaDoanhThus { get; set; } = new List<PhanChiaDoanhThu>();
    }

    [Table("PhanChiaDoanhThu")]
    public class PhanChiaDoanhThu
    {
        [Key]
        public int MaPhanChia { get; set; }
        public int MaKhoanTamGiu { get; set; }
        public virtual KhoanTamGiu? KhoanTamGiu { get; set; }

        public int? MaChinhSachHoaHong { get; set; }
        public virtual ChinhSachHoaHong? ChinhSachHoaHong { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongTien { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal TienGiaoVienNhan { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal TienSanNhan { get; set; }

        public double TiLeHoaHong { get; set; } = 0.15;
        public DateTime NgayQuyetToan { get; set; } = DateTime.UtcNow;
    }

    [Table("LenhRutTien")]
    public class LenhRutTien
    {
        [Key]
        public int MaLenhRut { get; set; }
        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        public int MaTaiKhoanNhanTien { get; set; }
        public virtual TaiKhoanNhanTien? TaiKhoanNhanTien { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTien { get; set; }
        public DateTime NgayYeuCau { get; set; } = DateTime.UtcNow;
        public DateTime? NgayXuLy { get; set; }
        public TrangThaiLenhRut TrangThai { get; set; } = TrangThaiLenhRut.ChoDuyet;
        [MaxLength(250)]
        public string? GhiChu { get; set; }
    }
}

