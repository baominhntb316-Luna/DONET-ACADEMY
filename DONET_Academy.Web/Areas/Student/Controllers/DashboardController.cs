using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DONET_Academy.Infrastructure.Data;

namespace DONET_Academy.Web.Areas.Student.Controllers
{
    [Area("Student")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var student = await _db.HoSoHocSinhs
                .Include(h => h.NguoiDung)
                .Include(h => h.KhoiLop)
                .Include(h => h.CapDo)
                .Include(h => h.QuotaAI)
                .FirstOrDefaultAsync();

            var courses = await _db.KhoaHocTriThucs
                .Include(k => k.MonHoc)
                .Take(2)
                .ToListAsync();

            var missions = await _db.TienDoNhiemVus
                .Include(t => t.NhiemVuNgay)
                    .ThenInclude(n => n!.MauNhiemVu)
                .ToListAsync();

            var upcomingBookings = await _db.DatLichs
                .Include(d => d.LichRanhGiaoVien)
                    .ThenInclude(l => l!.MonHoc)
                .Include(d => d.LichRanhGiaoVien)
                    .ThenInclude(l => l!.HoSoGiaoVien)
                        .ThenInclude(g => g!.NguoiDung)
                .Include(d => d.PhienHoc1V1)
                .ToListAsync();

            var wallet = await _db.ViTiens.FirstOrDefaultAsync(v => v.MaNguoiDung == student!.MaNguoiDung);

            ViewBag.Student = student;
            ViewBag.Courses = courses;
            ViewBag.Missions = missions;
            ViewBag.UpcomingBookings = upcomingBookings;
            ViewBag.Wallet = wallet;

            return View();
        }
    }
}

