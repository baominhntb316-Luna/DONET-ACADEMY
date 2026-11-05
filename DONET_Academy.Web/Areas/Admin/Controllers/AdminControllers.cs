using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DONET_Academy.Infrastructure.Data;
using DONET_Academy.Core.Entities;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var totalUsers = await _db.TaiKhoans.CountAsync();
            var totalStudents = await _db.HoSoHocSinhs.CountAsync();
            var totalTeachers = await _db.HoSoGiaoViens.CountAsync();
            var reports = await _db.BaoCaoDoanhThuAdmins.ToListAsync();

            ViewBag.TotalUsers = totalUsers;
            ViewBag.TotalStudents = totalStudents;
            ViewBag.TotalTeachers = totalTeachers;
            ViewBag.Reports = reports;
            return View();
        }
    }

    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var accounts = await _db.TaiKhoans
                .Include(t => t.NguoiDung)
                .Include(t => t.TaiKhoan_VaiTros)
                    .ThenInclude(tv => tv.VaiTro)
                .ToListAsync();

            return View(accounts);
        }
    }

    [Area("Admin")]
    public class TeacherVerificationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherVerificationsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var teachers = await _db.HoSoGiaoViens
                .Include(g => g.NguoiDung)
                .Include(g => g.GiaoVien_MonHocs)
                    .ThenInclude(m => m.MonHoc)
                .ToListAsync();

            return View(teachers);
        }
    }

    [Area("Admin")]
    public class PayoutsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PayoutsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var payouts = await _db.LenhRutTiens
                .Include(l => l.HoSoGiaoVien)
                    .ThenInclude(g => g!.NguoiDung)
                .Include(l => l.TaiKhoanNhanTien)
                .ToListAsync();

            return View(payouts);
        }
    }

    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SettingsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var commissions = await _db.ChinhSachHoaHongs.ToListAsync();
            var cancellation = await _db.ChinhSachHuys.FirstOrDefaultAsync();
            var levels = await _db.CapDos.ToListAsync();
            var reports = await _db.BaoCaoViPhams.Include(b => b.NguoiDungBaoCao).ToListAsync();

            ViewBag.Commissions = commissions;
            ViewBag.Cancellation = cancellation;
            ViewBag.Levels = levels;
            ViewBag.Reports = reports;
            return View();
        }
    }
}

