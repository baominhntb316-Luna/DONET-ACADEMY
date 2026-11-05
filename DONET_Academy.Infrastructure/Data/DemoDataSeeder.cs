using System;
using System.Collections.Generic;
using System.Linq;
using DONET_Academy.Core.Entities;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Infrastructure.Data
{
    public static class DemoDataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.KhoiLops.Any()) return; // Already seeded

            // 1. Khối lớp & Tổ hợp
            var k10 = new KhoiLop { TenKhoi = "Lớp 10", ThuTu = 10 };
            var k11 = new KhoiLop { TenKhoi = "Lớp 11", ThuTu = 11 };
            var k12 = new KhoiLop { TenKhoi = "Lớp 12", ThuTu = 12 };
            context.KhoiLops.AddRange(k10, k11, k12);
            context.SaveChanges();

            var mToan = new MonHoc { TenMonHoc = "Toán học", MoTa = "Đại số, Giải tích, Hình học Oxyz", KhoiLop = k12, IconName = "bi-calculator" };
            var mLi = new MonHoc { TenMonHoc = "Vật lí", MoTa = "Dao động cơ, Sóng cơ, Dòng điện xoay chiều", KhoiLop = k12, IconName = "bi-lightning-charge" };
            var mHoa = new MonHoc { TenMonHoc = "Hóa học", MoTa = "Este - Lipit, Amin, Polime, Kim loại", KhoiLop = k12, IconName = "bi-virus" };
            var mSinh = new MonHoc { TenMonHoc = "Sinh học", MoTa = "Di truyền học, Tiến hóa, Sinh thái học", KhoiLop = k12, IconName = "bi-dna" };
            var mAnh = new MonHoc { TenMonHoc = "Tiếng Anh", MoTa = "Ngữ pháp THPT, Từ vựng chuyên sâu", KhoiLop = k12, IconName = "bi-translate" };
            context.MonHocs.AddRange(mToan, mLi, mHoa, mSinh, mAnh);
            context.SaveChanges();

            var thA00 = new ToHopMon { TenToHop = "A00", MoTa = "Khối Tự nhiên (Toán - Lí - Hóa)" };
            var thB00 = new ToHopMon { TenToHop = "B00", MoTa = "Khối Y Dược (Toán - Hóa - Sinh)" };
            var thD01 = new ToHopMon { TenToHop = "D01", MoTa = "Khối Cơ bản (Toán - Văn - Anh)" };
            context.ToHopMons.AddRange(thA00, thB00, thD01);
            context.SaveChanges();

            context.ToHop_MonHocs.AddRange(
                new ToHop_MonHoc { MaToHopMon = thA00.MaToHopMon, MaMonHoc = mToan.MaMonHoc },
                new ToHop_MonHoc { MaToHopMon = thA00.MaToHopMon, MaMonHoc = mLi.MaMonHoc },
                new ToHop_MonHoc { MaToHopMon = thA00.MaToHopMon, MaMonHoc = mHoa.MaMonHoc }
            );

            // 2. Vai trò & Cấp độ
            var rHocSinh = new VaiTro { TenVaiTro = "HocSinh", MoTa = "Học sinh THPT" };
            var rGiaoVien = new VaiTro { TenVaiTro = "GiaoVien", MoTa = "Giáo viên / Gia sư 1-1" };
            var rAdmin = new VaiTro { TenVaiTro = "Admin", MoTa = "Quản trị viên toàn hệ thống" };
            context.VaiTros.AddRange(rHocSinh, rGiaoVien, rAdmin);

            var c1 = new CapDo { TenCapDo = "Tân Binh", DiemXPToiThieu = 0, IconHuyHieu = "seedling" };
            var c2 = new CapDo { TenCapDo = "Chiến Binh Sách", DiemXPToiThieu = 500, IconHuyHieu = "book" };
            var c3 = new CapDo { TenCapDo = "Đại Kiện Tướng", DiemXPToiThieu = 1200, IconHuyHieu = "award" };
            var c4 = new CapDo { TenCapDo = "Thủ Khoa DONET", DiemXPToiThieu = 3000, IconHuyHieu = "trophy" };
            context.CapDos.AddRange(c1, c2, c3, c4);

            var csHuy = new ChinhSachHuy { TenChinhSach = "Hủy trước 48 giờ hoàn 100%", SoGioTruocBuoiHoc = 48, TiLeHoanTien = 1.0, MoTa = "Hủy trước 48h hoàn trả 100% ví; sau 48h hoàn 0%." };
            var csHoaHong = new ChinhSachHoaHong { TenChinhSach = "Phí sàn tiêu chuẩn 15%", TiLeSanNhan = 0.15, HieuLuc = true };
            context.ChinhSachHuys.Add(csHuy);
            context.ChinhSachHoaHongs.Add(csHoaHong);
            context.SaveChanges();

            // 3. Tài khoản & Hồ sơ mẫu
            // 3.1. Học sinh mẫu
            var tkHS = new TaiKhoan { TenDangNhap = "student_an", Email = "an.student@donet.academy", MatKhauHash = "AQAAAAIAAYagAAAAE..." };
            context.TaiKhoans.Add(tkHS);
            context.SaveChanges();

            var ndHS = new NguoiDung { MaTaiKhoan = tkHS.MaTaiKhoan, HoTen = "Nguyễn Văn An", SoDienThoai = "0912345678", AnhDaiDien = "/images/mascot_oriole.png", GioiTinh = "Nam", DiaChi = "TP. Hồ Chí Minh" };
            context.NguoiDungs.Add(ndHS);
            context.SaveChanges();

            var viHS = new ViTien { MaNguoiDung = ndHS.MaNguoiDung, SoDuKhaDung = 850000, SoDuDongBang = 150000 };
            context.ViTiens.Add(viHS);

            var hsHS = new HoSoHocSinh { MaNguoiDung = ndHS.MaNguoiDung, KhoiLop = k12, DiemXP = 1450, CapDo = c3 };
            context.HoSoHocSinhs.Add(hsHS);
            context.SaveChanges();

            var quotaAI = new QuotaAI { MaHoSoHocSinh = hsHS.MaHoSoHocSinh, SoLuotToiDaNgay = 20, SoLuotDaDung = 4 };
            context.QuotaAIs.Add(quotaAI);

            context.TaiKhoan_VaiTros.Add(new TaiKhoan_VaiTro { MaTaiKhoan = tkHS.MaTaiKhoan, MaVaiTro = rHocSinh.MaVaiTro });

            // 3.2. Giáo viên mẫu
            var tkGV = new TaiKhoan { TenDangNhap = "teacher_binh", Email = "binh.teacher@donet.academy", MatKhauHash = "AQAAAAIAAYagAAAAE..." };
            context.TaiKhoans.Add(tkGV);
            context.SaveChanges();

            var ndGV = new NguoiDung { MaTaiKhoan = tkGV.MaTaiKhoan, HoTen = "ThS. Nguyễn Văn Bình", SoDienThoai = "0987654321", AnhDaiDien = "/images/avatar_teacher1.png", GioiTinh = "Nam", DiaChi = "Hà Nội" };
            context.NguoiDungs.Add(ndGV);
            context.SaveChanges();

            var viGV = new ViTien { MaNguoiDung = ndGV.MaNguoiDung, SoDuKhaDung = 18500000, SoDuDongBang = 0 };
            context.ViTiens.Add(viGV);

            var hsGV = new HoSoGiaoVien
            {
                MaNguoiDung = ndGV.MaNguoiDung,
                GioiThieu = "Thạc sĩ Sư phạm Toán ĐH Sư Phạm TP.HCM, 10 năm luyện thi THPT Quốc Gia với nhiều thủ khoa.",
                BangCapChungChi = "ThS Toán học & Chứng chỉ Nghiệp vụ Sư phạm Cao cấp",
                SoNamKinhNghiem = 10,
                DanhGiaTB = 4.9,
                TrangThaiDuyet = TrangThaiHoSoGiaoVien.DaDuyet
            };
            context.HoSoGiaoViens.Add(hsGV);
            context.SaveChanges();

            context.GiaoVien_MonHocs.Add(new GiaoVien_MonHoc { MaHoSoGiaoVien = hsGV.MaHoSoGiaoVien, MaMonHoc = mToan.MaMonHoc, GiaTienMoiGio = 180000 });
            context.TaiKhoanNhanTiens.Add(new TaiKhoanNhanTien { MaHoSoGiaoVien = hsGV.MaHoSoGiaoVien, TenNganHang = "Vietcombank", SoTaiKhoan = "0071000998877", TenChuTaiKhoan = "NGUYEN VAN BINH", ChiNhanh = "Bến Thành" });

            context.TaiKhoan_VaiTros.Add(new TaiKhoan_VaiTro { MaTaiKhoan = tkGV.MaTaiKhoan, MaVaiTro = rGiaoVien.MaVaiTro });

            // 3.3. Admin mẫu
            var tkAD = new TaiKhoan { TenDangNhap = "admin", Email = "admin@donet.academy", MatKhauHash = "AQAAAAIAAYagAAAAE..." };
            context.TaiKhoans.Add(tkAD);
            context.SaveChanges();

            var ndAD = new NguoiDung { MaTaiKhoan = tkAD.MaTaiKhoan, HoTen = "Tổ Quản trị DONET", SoDienThoai = "1900888999", AnhDaiDien = "/images/mascot_oriole.png" };
            context.NguoiDungs.Add(ndAD);
            context.SaveChanges();
            context.TaiKhoan_VaiTros.Add(new TaiKhoan_VaiTro { MaTaiKhoan = tkAD.MaTaiKhoan, MaVaiTro = rAdmin.MaVaiTro });

            // 4. Khóa học tri thức
            var kh1 = new KhoaHocTriThuc
            {
                TenKhoaHoc = "Chinh phục Hình học Không gian & Tọa độ Oxyz 12",
                MoTa = "Khóa học thực chiến toàn diện từ cơ bản đến vận dụng cao góc, khoảng cách, thể tích khối đa diện và phương trình mặt cầu.",
                KhoiLop = k12,
                MonHoc = mToan,
                GiaTien = 299000,
                HinhAnh = "/images/course_math12.jpg"
            };
            var kh2 = new KhoaHocTriThuc
            {
                TenKhoaHoc = "Bí kíp Este - Lipit & Các dạng bài trọng tâm Hóa 12",
                MoTa = "Phương pháp giải nhanh quy đổi Este, thủy phân Peptit và chuỗi phản ứng ăn chắc điểm 9+.",
                KhoiLop = k12,
                MonHoc = mHoa,
                GiaTien = 249000,
                HinhAnh = "/images/course_chem12.jpg"
            };
            context.KhoaHocTriThucs.AddRange(kh1, kh2);
            context.SaveChanges();

            var ch1 = new ChuongHoc { MaKhoaHoc = kh1.MaKhoaHoc, TenChuong = "Chương 1: Khối đa diện và Thể tích", ThuTu = 1 };
            var ch2 = new ChuongHoc { MaKhoaHoc = kh1.MaKhoaHoc, TenChuong = "Chương 2: Tọa độ trong không gian Oxyz", ThuTu = 2 };
            context.ChuongHocs.AddRange(ch1, ch2);
            context.SaveChanges();

            context.BaiHocs.AddRange(
                new BaiHoc { MaChuongHoc = ch1.MaChuongHoc, TieuDe = "Bài 1: Khái niệm về khối đa diện & tính chất", ThoiLuongPhut = 18, ThuTu = 1, MienPhiXemTruoc = true },
                new BaiHoc { MaChuongHoc = ch1.MaChuongHoc, TieuDe = "Bài 2: Kỹ thuật tính thể tích khối lăng trụ & chóp", ThoiLuongPhut = 25, ThuTu = 2, MienPhiXemTruoc = false },
                new BaiHoc { MaChuongHoc = ch2.MaChuongHoc, TieuDe = "Bài 1: Hệ trục tọa độ và tích có hướng", ThoiLuongPhut = 20, ThuTu = 1, MienPhiXemTruoc = true }
            );

            // 5. Lịch rảnh & Đặt lịch 1-1
            var today = DateTime.UtcNow.Date;
            var slot1 = new LichRanhGiaoVien
            {
                MaHoSoGiaoVien = hsGV.MaHoSoGiaoVien,
                MaMonHoc = mToan.MaMonHoc,
                ThoiGianBatDau = today.AddDays(1).AddHours(19),
                ThoiGianKetThuc = today.AddDays(1).AddHours(20).AddMinutes(30),
                GiaTien = 180000,
                TrangThai = TrangThaiLichRanh.DaDat
            };
            var slot2 = new LichRanhGiaoVien
            {
                MaHoSoGiaoVien = hsGV.MaHoSoGiaoVien,
                MaMonHoc = mToan.MaMonHoc,
                ThoiGianBatDau = today.AddDays(2).AddHours(20),
                ThoiGianKetThuc = today.AddDays(2).AddHours(21).AddMinutes(30),
                GiaTien = 180000,
                TrangThai = TrangThaiLichRanh.Trong
            };
            context.LichRanhGiaoViens.AddRange(slot1, slot2);
            context.SaveChanges();

            var datLich1 = new DatLich
            {
                MaHoSoHocSinh = hsHS.MaHoSoHocSinh,
                MaLichRanh = slot1.MaLichRanh,
                MaChinhSachHuy = csHuy.MaChinhSachHuy,
                GiaTien = 180000,
                TrangThai = TrangThaiDatLich.DaDat
            };
            context.DatLichs.Add(datLich1);
            context.SaveChanges();

            context.PhienHoc1V1s.Add(new PhienHoc1V1
            {
                MaDatLich = datLich1.MaDatLich,
                LinkPhongHoc = "https://meet.donet.academy/phien-101-toan12",
                DaHoanThanhNghiemThu = false,
                GhiChuBuoiHoc = "Luyện đề số 3 & Giải đáp thắc mắc câu 45-50"
            });

            context.KhoanTamGius.Add(new KhoanTamGiu
            {
                MaDatLich = datLich1.MaDatLich,
                SoTien = 180000,
                DaGiaiPhong = false
            });

            // 6. Đề thi & Khảo thí
            var boDe1 = new BoDe
            {
                TieuDe = "Đề Khảo Sát Chất Lượng Toán 12 - Chuẩn Cấu Trúc Bộ GD&ĐT 2026",
                MaMonHoc = mToan.MaMonHoc,
                ThoiGianLamBaiPhut = 90,
                SoCauHoi = 50,
                DiemToiDa = 10.0,
                DaXuatBan = true
            };
            context.BoDes.Add(boDe1);
            context.SaveChanges();

            var q1 = new CauHoi { NoiDung = "Cho hàm số y = f(x) có đạo hàm f'(x) = x(x - 1)^2 (x + 2). Số điểm cực trị của hàm số là:", MucDo = MucDoCauHoi.ThongHieu, GiaiThichChiTiet = "Nghiệm bội chẵn x = 1 không làm đổi dấu đạo hàm nên chỉ có 2 cực trị tại x = 0 và x = -2." };
            var q2 = new CauHoi { NoiDung = "Trong không gian Oxyz, mặt cầu (S): x^2 + y^2 + z^2 - 2x + 4y - 6z - 2 = 0 có bán kính R bằng:", MucDo = MucDoCauHoi.NhanBiet, GiaiThichChiTiet = "Tâm I(1, -2, 3), R = sqrt(1 + 4 + 9 - (-2)) = sqrt(16) = 4." };
            context.CauHois.AddRange(q1, q2);
            context.SaveChanges();

            context.ChiTietDes.AddRange(
                new ChiTietDe { MaBoDe = boDe1.MaBoDe, MaCauHoi = q1.MaCauHoi, ThuTu = 1, DiemCau = 0.2 },
                new ChiTietDe { MaBoDe = boDe1.MaBoDe, MaCauHoi = q2.MaCauHoi, ThuTu = 2, DiemCau = 0.2 }
            );

            context.DapAns.AddRange(
                new DapAn { MaCauHoi = q1.MaCauHoi, NoiDung = "A. 1", LaDapAnDung = false, ThuTu = 1 },
                new DapAn { MaCauHoi = q1.MaCauHoi, NoiDung = "B. 2", LaDapAnDung = true, ThuTu = 2 },
                new DapAn { MaCauHoi = q1.MaCauHoi, NoiDung = "C. 3", LaDapAnDung = false, ThuTu = 3 },
                new DapAn { MaCauHoi = q1.MaCauHoi, NoiDung = "D. 4", LaDapAnDung = false, ThuTu = 4 },
                new DapAn { MaCauHoi = q2.MaCauHoi, NoiDung = "A. R = 4", LaDapAnDung = true, ThuTu = 1 },
                new DapAn { MaCauHoi = q2.MaCauHoi, NoiDung = "B. R = 2", LaDapAnDung = false, ThuTu = 2 },
                new DapAn { MaCauHoi = q2.MaCauHoi, NoiDung = "C. R = 16", LaDapAnDung = false, ThuTu = 3 },
                new DapAn { MaCauHoi = q2.MaCauHoi, NoiDung = "D. R = sqrt(14)", LaDapAnDung = false, ThuTu = 4 }
            );

            // 7. Gamification & Nhiệm vụ
            var mnv1 = new MauNhiemVu { TenNhiemVu = "Học tập chăm chỉ", MoTa = "Xem ít nhất 1 video bài giảng bất kỳ", PhanThuongXP = 50, IconName = "play-circle" };
            var mnv2 = new MauNhiemVu { TenNhiemVu = "Chiến binh luyện đề", MoTa = "Làm hoàn thành 1 bài luyện thi trắc nghiệm", PhanThuongXP = 100, IconName = "pencil-square" };
            var mnv3 = new MauNhiemVu { TenNhiemVu = "Hỏi bài cùng AI", MoTa = "Đặt 1 câu hỏi thắc mắc cho Trợ lý AI Tutor", PhanThuongXP = 30, IconName = "robot" };
            context.MauNhiemVus.AddRange(mnv1, mnv2, mnv3);
            context.SaveChanges();

            var nvNgay1 = new NhiemVuNgay { MaMauNhiemVu = mnv1.MaMauNhiemVu, NgayApDung = today, SoLuongYeuCau = 1 };
            var nvNgay2 = new NhiemVuNgay { MaMauNhiemVu = mnv2.MaMauNhiemVu, NgayApDung = today, SoLuongYeuCau = 1 };
            context.NhiemVuNgays.AddRange(nvNgay1, nvNgay2);
            context.SaveChanges();

            context.TienDoNhiemVus.AddRange(
                new TienDoNhiemVu { MaHoSoHocSinh = hsHS.MaHoSoHocSinh, MaNhiemVuNgay = nvNgay1.MaNhiemVuNgay, TienDoHienTai = 1, DaHoanThanh = true, DaNhanThuong = true },
                new TienDoNhiemVu { MaHoSoHocSinh = hsHS.MaHoSoHocSinh, MaNhiemVuNgay = nvNgay2.MaNhiemVuNgay, TienDoHienTai = 0, DaHoanThanh = false, DaNhanThuong = false }
            );

            // 8. Diễn đàn & Cộng đồng
            var bd1 = new BaiDang
            {
                MaNguoiDung = ndHS.MaNguoiDung,
                TieuDe = "Cách bấm máy Casio tìm cực trị hàm số chứa dấu giá trị tuyệt đối?",
                NoiDung = "Chào mọi người, có bạn nào có mẹo bấm máy tính Casio 580VNX dạng bài f(|x|) nhanh không ạ? Cho mình xin công thức với!",
                LuotXem = 142
            };
            context.BaiDangs.Add(bd1);
            context.SaveChanges();

            context.BinhLuans.Add(new BinhLuan
            {
                MaBaiDang = bd1.MaBaiDang,
                MaNguoiDung = ndGV.MaNguoiDung,
                NoiDung = "Thầy khuyên em nên hiểu bản chất đồ thị đối xứng qua trục Oy trước, sau đó mới dùng phím Table (MODE 8) để quét bước nhảy 0.2 sẽ không bị sót điểm cực tiểu nhé!"
            });
            context.Votes.Add(new Vote { MaBaiDang = bd1.MaBaiDang, MaNguoiDung = ndGV.MaNguoiDung, DiemVote = 1 });

            // 9. Lệnh rút tiền & Báo cáo doanh thu
            context.LenhRutTiens.Add(new LenhRutTien
            {
                MaHoSoGiaoVien = hsGV.MaHoSoGiaoVien,
                MaTaiKhoanNhanTien = 1,
                SoTien = 5000000,
                TrangThai = TrangThaiLenhRut.ChoDuyet,
                GhiChu = "Rút tiền giảng dạy tuần 4 tháng 10"
            });

            context.BaoCaoDoanhThuAdmins.Add(new BaoCaoDoanhThuAdmin
            {
                Thang = 10,
                Nam = 2026,
                TongDoanhThu = 125000000,
                DoanhThuSan = 18750000,
                DoanhThuGiaoVien = 106250000
            });

            context.BaoCaoDoanhThuGiaoViens.Add(new BaoCaoDoanhThuGiaoVien
            {
                MaHoSoGiaoVien = hsGV.MaHoSoGiaoVien,
                Thang = 10,
                Nam = 2026,
                TongThuNhap = 18500000,
                SoBuoiDay = 24
            });

            context.SaveChanges();
        }
    }
}

