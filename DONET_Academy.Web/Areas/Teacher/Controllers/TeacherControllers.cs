using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DONET_Academy.Infrastructure.Data;
using DONET_Academy.Core.Entities;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Web.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var teacher = await _db.HoSoGiaoViens
                .Include(g => g.NguoiDung)
                .Include(g => g.GiaoVien_MonHocs)
                    .ThenInclude(m => m.MonHoc)
                .Include(g => g.BaoCaoDoanhThuGiaoViens)
                .FirstOrDefaultAsync();

            var slots = await _db.LichRanhGiaoViens
                .Include(s => s.MonHoc)
                .Where(s => s.MaHoSoGiaoVien == teacher!.MaHoSoGiaoVien)
                .ToListAsync();

            var wallet = await _db.ViTiens.FirstOrDefaultAsync(v => v.MaNguoiDung == teacher!.MaNguoiDung);

            ViewBag.Teacher = teacher;
            ViewBag.Slots = slots;
            ViewBag.Wallet = wallet;
            return View();
        }
    }

    [Area("Teacher")]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ScheduleController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var slots = await _db.LichRanhGiaoViens
                .Include(s => s.MonHoc)
                .Include(s => s.DatLichs)
                    .ThenInclude(d => d.HoSoHocSinh)
                        .ThenInclude(h => h!.NguoiDung)
                .ToListAsync();

            var subjects = await _db.MonHocs.ToListAsync();
            ViewBag.Subjects = subjects;
            return View(slots);
        }
    }

    [Area("Teacher")]
    public class ClassroomsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClassroomsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var sessions = await _db.PhienHoc1V1s
                .Include(p => p.DatLich)
                    .ThenInclude(d => d!.HoSoHocSinh)
                        .ThenInclude(h => h!.NguoiDung)
                .Include(p => p.DatLich)
                    .ThenInclude(d => d!.LichRanhGiaoVien)
                        .ThenInclude(l => l!.MonHoc)
                .ToListAsync();

            return View(sessions);
        }
    }

    [Area("Teacher")]
    public class ExamBankController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExamBankController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var exams = await _db.BoDes
                .Include(b => b.MonHoc)
                .Include(b => b.ChiTietDes)
                .ToListAsync();

            var questions = await _db.CauHois.Include(q => q.DapAns).ToListAsync();
            ViewBag.Questions = questions;
            return View(exams);
        }
    }

    [Area("Teacher")]
    public class GradingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GradingController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var assignments = await _db.BaiTapGiaos
                .Include(b => b.MonHoc)
                .Include(b => b.NopBaiTaps)
                    .ThenInclude(n => n.HoSoHocSinh)
                        .ThenInclude(h => h!.NguoiDung)
                .ToListAsync();

            return View(assignments);
        }
    }

    [Area("Teacher")]
    public class WalletController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WalletController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var teacher = await _db.HoSoGiaoViens.Include(g => g.TaiKhoanNhanTiens).FirstOrDefaultAsync();
            var wallet = await _db.ViTiens.FirstOrDefaultAsync(v => v.MaNguoiDung == teacher!.MaNguoiDung);

            var payouts = await _db.LenhRutTiens
                .Include(l => l.TaiKhoanNhanTien)
                .Where(l => l.MaHoSoGiaoVien == teacher!.MaHoSoGiaoVien)
                .ToListAsync();

            var splits = await _db.PhanChiaDoanhThus.ToListAsync();

            ViewBag.Teacher = teacher;
            ViewBag.Payouts = payouts;
            ViewBag.Splits = splits;
            return View(wallet);
        }
    }
}

