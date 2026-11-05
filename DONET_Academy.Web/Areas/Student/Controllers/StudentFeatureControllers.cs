using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DONET_Academy.Infrastructure.Data;
using DONET_Academy.Core.Entities;
using DONET_Academy.Core.Enums;

namespace DONET_Academy.Web.Areas.Student.Controllers
{
    [Area("Student")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CoursesController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index(int? monHocId)
        {
            var subjects = await _db.MonHocs.ToListAsync();
            var query = _db.KhoaHocTriThucs
                .Include(k => k.MonHoc)
                .Include(k => k.KhoiLop)
                .Include(k => k.ChuongHocs)
                    .ThenInclude(c => c.BaiHocs)
                .AsQueryable();

            if (monHocId.HasValue)
                query = query.Where(k => k.MaMonHoc == monHocId.Value);

            ViewBag.Subjects = subjects;
            ViewBag.SelectedSubjectId = monHocId;
            return View(await query.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _db.KhoaHocTriThucs
                .Include(k => k.MonHoc)
                .Include(k => k.KhoiLop)
                .Include(k => k.ChuongHocs.OrderBy(c => c.ThuTu))
                    .ThenInclude(c => c.BaiHocs.OrderBy(b => b.ThuTu))
                .FirstOrDefaultAsync(k => k.MaKhoaHoc == id);

            if (course == null) return NotFound();
            return View(course);
        }

        public async Task<IActionResult> Learn(int id)
        {
            var lesson = await _db.BaiHocs
                .Include(b => b.ChuongHoc)
                    .ThenInclude(c => c!.KhoaHoc)
                .FirstOrDefaultAsync(b => b.MaBaiHoc == id);

            if (lesson == null) return NotFound();
            return View(lesson);
        }
    }

    [Area("Student")]
    public class ExamsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExamsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var exams = await _db.BoDes.Include(b => b.MonHoc).ToListAsync();
            return View(exams);
        }

        public async Task<IActionResult> Take(int id)
        {
            var exam = await _db.BoDes
                .Include(b => b.MonHoc)
                .Include(b => b.ChiTietDes)
                    .ThenInclude(c => c.CauHoi)
                        .ThenInclude(q => q!.DapAns)
                .FirstOrDefaultAsync(b => b.MaBoDe == id);

            if (exam == null) return NotFound();
            return View(exam);
        }

        [HttpPost]
        public IActionResult Submit(int examId)
        {
            return RedirectToAction("Result", new { id = examId });
        }

        public async Task<IActionResult> Result(int id)
        {
            var exam = await _db.BoDes.Include(b => b.MonHoc).FirstOrDefaultAsync(b => b.MaBoDe == id);
            return View(exam);
        }
    }

    [Area("Student")]
    public class TutorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TutorsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var tutors = await _db.HoSoGiaoViens
                .Include(g => g.NguoiDung)
                .Include(g => g.GiaoVien_MonHocs)
                    .ThenInclude(gm => gm.MonHoc)
                .Include(g => g.LichRanhGiaoViens)
                .Where(g => g.TrangThaiDuyet == TrangThaiHoSoGiaoVien.DaDuyet)
                .ToListAsync();

            return View(tutors);
        }

        public async Task<IActionResult> Book(int id)
        {
            var slot = await _db.LichRanhGiaoViens
                .Include(s => s.MonHoc)
                .Include(s => s.HoSoGiaoVien)
                    .ThenInclude(g => g!.NguoiDung)
                .FirstOrDefaultAsync(s => s.MaLichRanh == id);

            if (slot == null) return NotFound();
            return View(slot);
        }
    }

    [Area("Student")]
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AssignmentsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var assignments = await _db.BaiTapGiaos
                .Include(b => b.MonHoc)
                .Include(b => b.HoSoGiaoVien)
                    .ThenInclude(g => g!.NguoiDung)
                .Include(b => b.NopBaiTaps)
                .ToListAsync();

            return View(assignments);
        }
    }

    [Area("Student")]
    public class WalletController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WalletController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var wallet = await _db.ViTiens
                .Include(v => v.GiaoDichVis)
                .Include(v => v.GiaoDichThanhToans)
                .FirstOrDefaultAsync();

            var escrow = await _db.KhoanTamGius
                .Include(k => k.DatLich)
                    .ThenInclude(d => d!.LichRanhGiaoVien)
                        .ThenInclude(l => l!.MonHoc)
                .ToListAsync();

            ViewBag.Escrow = escrow;
            return View(wallet);
        }
    }

    [Area("Student")]
    public class MissionsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MissionsController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var missions = await _db.TienDoNhiemVus
                .Include(t => t.NhiemVuNgay)
                    .ThenInclude(n => n!.MauNhiemVu)
                .ToListAsync();

            var student = await _db.HoSoHocSinhs
                .Include(h => h.CapDo)
                .FirstOrDefaultAsync();

            ViewBag.Student = student;
            return View(missions);
        }
    }

    [Area("Student")]
    public class AiTutorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AiTutorController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var quota = await _db.QuotaAIs.FirstOrDefaultAsync();
            return View(quota);
        }
    }

    [Area("Student")]
    public class CommunityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CommunityController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var posts = await _db.BaiDangs
                .Include(b => b.NguoiDung)
                .Include(b => b.BinhLuans)
                    .ThenInclude(c => c.NguoiDung)
                .Include(b => b.Votes)
                .ToListAsync();

            return View(posts);
        }
    }
}

