using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Core.Entities
{
    [Table("LichRanhGiaoVien")]
    public class LichRanhGiaoVien
    {
        [Key]
        public int MaLichRanh { get; set; }
        public int MaHoSoGiaoVien { get; set; }
        public virtual HoSoGiaoVien? HoSoGiaoVien { get; set; }

        public int MaMonHoc { get; set; }
        public virtual MonHoc? MonHoc { get; set; }

        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaTien { get; set; } = 150000;

        public TrangThaiLichRanh TrangThai { get; set; } = TrangThaiLichRanh.Trong;

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public virtual ICollection<DatLich> DatLichs { get; set; } = new List<DatLich>();
    }

    [Table("ChinhSachHuy")]
    public class ChinhSachHuy
    {
        [Key]
        public int MaChinhSachHuy { get; set; }
        [Required, MaxLength(100)]
        public string TenChinhSach { get; set; } = "Hủy trước 48 giờ hoàn 100%";
        public int SoGioTruocBuoiHoc { get; set; } = 48;
        public double TiLeHoanTien { get; set; } = 1.0; // 100%
        [MaxLength(250)]
        public string? MoTa { get; set; }

        public virtual ICollection<DatLich> DatLichs { get; set; } = new List<DatLich>();
    }

    [Table("DatLich")]
    public class DatLich
    {
        [Key]
        public int MaDatLich { get; set; }
        public int MaHoSoHocSinh { get; set; }
        public virtual HoSoHocSinh? HoSoHocSinh { get; set; }

        public int MaLichRanh { get; set; }
        public virtual LichRanhGiaoVien? LichRanhGiaoVien { get; set; }

        public int? MaChinhSachHuy { get; set; }
        public virtual ChinhSachHuy? ChinhSachHuy { get; set; }

        public DateTime ThoiGianDat { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaTien { get; set; }

        public TrangThaiDatLich TrangThai { get; set; } = TrangThaiDatLich.DaDat;

        public virtual PhienHoc1V1? PhienHoc1V1 { get; set; }
        public virtual KhoanTamGiu? KhoanTamGiu { get; set; }
        public virtual YeuCauHuyBuoi? YeuCauHuyBuoi { get; set; }
        public virtual DanhGia? DanhGia { get; set; }
    }

    [Table("PhienHoc1V1")]
    public class PhienHoc1V1
    {
        [Key]
        public int MaPhienHoc { get; set; }
        public int MaDatLich { get; set; }
        public virtual DatLich? DatLich { get; set; }

        [MaxLength(500)]
        public string LinkPhongHoc { get; set; } = "https://meet.donet.academy/room-101";
        public DateTime? ThoiGianVaoThucTe { get; set; }
        public DateTime? KetThucThucTe { get; set; }
        public bool DaHoanThanhNghiemThu { get; set; } = false;
        [MaxLength(500)]
        public string? GhiChuBuoiHoc { get; set; }
    }

    [Table("YeuCauHuyBuoi")]
    public class YeuCauHuyBuoi
    {
        [Key]
        public int MaYeuCauHuy { get; set; }
        public int MaDatLich { get; set; }
        public virtual DatLich? DatLich { get; set; }

        public int MaNguoiDungHuy { get; set; }
        public DateTime ThoiGianHuy { get; set; } = DateTime.UtcNow;
        [MaxLength(500)]
        public string? LyDoHuy { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTienDuocHoan { get; set; } = 0;
        public bool DaDuyet { get; set; } = true;

        public virtual HoanTien? HoanTien { get; set; }
    }

    [Table("HoanTien")]
    public class HoanTien
    {
        [Key]
        public int MaHoanTien { get; set; }
        public int MaYeuCauHuy { get; set; }
        public virtual YeuCauHuyBuoi? YeuCauHuyBuoi { get; set; }

        public int? MaGiaoDichVi { get; set; }
        public virtual GiaoDichVi? GiaoDichVi { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal SoTienHoan { get; set; }
        public DateTime NgayHoanTien { get; set; } = DateTime.UtcNow;
        public bool TrangThai { get; set; } = true;
    }

    [Table("DanhGia")]
    public class DanhGia
    {
        [Key]
        public int MaDanhGia { get; set; }
        public int MaDatLich { get; set; }
        public virtual DatLich? DatLich { get; set; }

        [Range(1, 5)]
        public int SoSao { get; set; } = 5;
        [MaxLength(1000)]
        public string? BinhLuan { get; set; }
        public DateTime NgayDanhGia { get; set; } = DateTime.UtcNow;
    }
}

