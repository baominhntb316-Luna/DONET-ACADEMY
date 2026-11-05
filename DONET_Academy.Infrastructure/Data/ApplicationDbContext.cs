using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DONET_Academy.Core.Entities;

namespace DONET_Academy.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // 55 DbSets
        public DbSet<TaiKhoan> TaiKhoans => Set<TaiKhoan>();
        public DbSet<VaiTro> VaiTros => Set<VaiTro>();
        public DbSet<TaiKhoan_VaiTro> TaiKhoan_VaiTros => Set<TaiKhoan_VaiTro>();
        public DbSet<NguoiDung> NguoiDungs => Set<NguoiDung>();
        public DbSet<HoSoHocSinh> HoSoHocSinhs => Set<HoSoHocSinh>();
        public DbSet<HoSoGiaoVien> HoSoGiaoViens => Set<HoSoGiaoVien>();
        public DbSet<GiaoVien_MonHoc> GiaoVien_MonHocs => Set<GiaoVien_MonHoc>();
        public DbSet<TaiKhoanNhanTien> TaiKhoanNhanTiens => Set<TaiKhoanNhanTien>();

        public DbSet<KhoiLop> KhoiLops => Set<KhoiLop>();
        public DbSet<MonHoc> MonHocs => Set<MonHoc>();
        public DbSet<ToHopMon> ToHopMons => Set<ToHopMon>();
        public DbSet<ToHop_MonHoc> ToHop_MonHocs => Set<ToHop_MonHoc>();
        public DbSet<HocSinh_ToHop> HocSinh_ToHops => Set<HocSinh_ToHop>();
        public DbSet<KhoaHocTriThuc> KhoaHocTriThucs => Set<KhoaHocTriThuc>();
        public DbSet<ChuongHoc> ChuongHocs => Set<ChuongHoc>();
        public DbSet<BaiHoc> BaiHocs => Set<BaiHoc>();
        public DbSet<DangKyKhoaHoc> DangKyKhoaHocs => Set<DangKyKhoaHoc>();
        public DbSet<TienDoBaiHoc> TienDoBaiHocs => Set<TienDoBaiHoc>();

        public DbSet<LichRanhGiaoVien> LichRanhGiaoViens => Set<LichRanhGiaoVien>();
        public DbSet<ChinhSachHuy> ChinhSachHuys => Set<ChinhSachHuy>();
        public DbSet<DatLich> DatLichs => Set<DatLich>();
        public DbSet<PhienHoc1V1> PhienHoc1V1s => Set<PhienHoc1V1>();
        public DbSet<YeuCauHuyBuoi> YeuCauHuyBuois => Set<YeuCauHuyBuoi>();
        public DbSet<HoanTien> HoanTiens => Set<HoanTien>();
        public DbSet<DanhGia> DanhGias => Set<DanhGia>();

        public DbSet<ViTien> ViTiens => Set<ViTien>();
        public DbSet<GiaoDichVi> GiaoDichVis => Set<GiaoDichVi>();
        public DbSet<GiaoDichThanhToan> GiaoDichThanhToans => Set<GiaoDichThanhToan>();
        public DbSet<KhoanTamGiu> KhoanTamGius => Set<KhoanTamGiu>();
        public DbSet<ChinhSachHoaHong> ChinhSachHoaHongs => Set<ChinhSachHoaHong>();
        public DbSet<PhanChiaDoanhThu> PhanChiaDoanhThus => Set<PhanChiaDoanhThu>();
        public DbSet<LenhRutTien> LenhRutTiens => Set<LenhRutTien>();

        public DbSet<BoDe> BoDes => Set<BoDe>();
        public DbSet<ChiTietDe> ChiTietDes => Set<ChiTietDe>();
        public DbSet<CauHoi> CauHois => Set<CauHoi>();
        public DbSet<DapAn> DapAns => Set<DapAn>();
        public DbSet<BaiLam> BaiLams => Set<BaiLam>();
        public DbSet<ChiTietBaiLam> ChiTietBaiLams => Set<ChiTietBaiLam>();
        public DbSet<BaiTapGiao> BaiTapGiaos => Set<BaiTapGiao>();
        public DbSet<NopBaiTap> NopBaiTaps => Set<NopBaiTap>();

        public DbSet<MauNhiemVu> MauNhiemVus => Set<MauNhiemVu>();
        public DbSet<NhiemVuNgay> NhiemVuNgays => Set<NhiemVuNgay>();
        public DbSet<TienDoNhiemVu> TienDoNhiemVus => Set<TienDoNhiemVu>();
        public DbSet<CapDo> CapDos => Set<CapDo>();
        public DbSet<QuotaAI> QuotaAIs => Set<QuotaAI>();
        public DbSet<GoiPremium> GoiPremiums => Set<GoiPremium>();
        public DbSet<BaiDang> BaiDangs => Set<BaiDang>();
        public DbSet<BinhLuan> BinhLuans => Set<BinhLuan>();
        public DbSet<Vote> Votes => Set<Vote>();
        public DbSet<TheoDoi> TheoDois => Set<TheoDoi>();
        public DbSet<ThongBao> ThongBaos => Set<ThongBao>();
        public DbSet<BaoCaoViPham> BaoCaoViPhams => Set<BaoCaoViPham>();
        public DbSet<CauHinhHeThong> CauHinhHeThongs => Set<CauHinhHeThong>();
        public DbSet<BaoCaoDoanhThuAdmin> BaoCaoDoanhThuAdmins => Set<BaoCaoDoanhThuAdmin>();
        public DbSet<BaoCaoDoanhThuGiaoVien> BaoCaoDoanhThuGiaoViens => Set<BaoCaoDoanhThuGiaoVien>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Compound Keys
            builder.Entity<TaiKhoan_VaiTro>().HasKey(x => new { x.MaTaiKhoan, x.MaVaiTro });
            builder.Entity<ToHop_MonHoc>().HasKey(x => new { x.MaToHopMon, x.MaMonHoc });
            builder.Entity<HocSinh_ToHop>().HasKey(x => new { x.MaHoSoHocSinh, x.MaToHopMon });
            builder.Entity<GiaoVien_MonHoc>().HasKey(x => new { x.MaHoSoGiaoVien, x.MaMonHoc });
            builder.Entity<Vote>().HasKey(x => new { x.MaBaiDang, x.MaNguoiDung });
            builder.Entity<TheoDoi>().HasKey(x => new { x.MaHoSoHocSinh, x.MaHoSoGiaoVien });

            // Explicit 1-to-1 Relationships
            builder.Entity<TaiKhoan>()
                .HasOne(t => t.NguoiDung)
                .WithOne(n => n.TaiKhoan)
                .HasForeignKey<NguoiDung>(n => n.MaTaiKhoan);

            builder.Entity<NguoiDung>()
                .HasOne(n => n.HoSoHocSinh)
                .WithOne(h => h.NguoiDung)
                .HasForeignKey<HoSoHocSinh>(h => h.MaNguoiDung);

            builder.Entity<NguoiDung>()
                .HasOne(n => n.HoSoGiaoVien)
                .WithOne(g => g.NguoiDung)
                .HasForeignKey<HoSoGiaoVien>(g => g.MaNguoiDung);

            builder.Entity<NguoiDung>()
                .HasOne(n => n.ViTien)
                .WithOne(v => v.NguoiDung)
                .HasForeignKey<ViTien>(v => v.MaNguoiDung);

            builder.Entity<HoSoHocSinh>()
                .HasOne(h => h.QuotaAI)
                .WithOne(q => q.HoSoHocSinh)
                .HasForeignKey<QuotaAI>(q => q.MaHoSoHocSinh);

            builder.Entity<DatLich>()
                .HasOne(d => d.PhienHoc1V1)
                .WithOne(p => p.DatLich)
                .HasForeignKey<PhienHoc1V1>(p => p.MaDatLich);

            builder.Entity<DatLich>()
                .HasOne(d => d.KhoanTamGiu)
                .WithOne(k => k.DatLich)
                .HasForeignKey<KhoanTamGiu>(k => k.MaDatLich);

            builder.Entity<DatLich>()
                .HasOne(d => d.YeuCauHuyBuoi)
                .WithOne(y => y.DatLich)
                .HasForeignKey<YeuCauHuyBuoi>(y => y.MaDatLich);

            builder.Entity<DatLich>()
                .HasOne(d => d.DanhGia)
                .WithOne(dg => dg.DatLich)
                .HasForeignKey<DanhGia>(dg => dg.MaDatLich);

            builder.Entity<YeuCauHuyBuoi>()
                .HasOne(y => y.HoanTien)
                .WithOne(h => h.YeuCauHuyBuoi)
                .HasForeignKey<HoanTien>(h => h.MaYeuCauHuy);

            builder.Entity<KhoanTamGiu>()
                .HasOne(k => k.PhanChiaDoanhThu)
                .WithOne(p => p.KhoanTamGiu)
                .HasForeignKey<PhanChiaDoanhThu>(p => p.MaKhoanTamGiu);

            // Optimistic Concurrency with RowVersion
            builder.Entity<ViTien>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<LichRanhGiaoVien>().Property(p => p.RowVersion).IsRowVersion();

            // Currency Decimal Precision (18, 0)
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(0);
            }
        }
    }
}
