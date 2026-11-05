using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DONET_Academy.Web.Models;
using DONET_Academy.Infrastructure.Data;

namespace DONET_Academy.Web.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var subjects = await _db.MonHocs.ToListAsync();
        var courses = await _db.KhoaHocTriThucs.Include(c => c.MonHoc).Take(3).ToListAsync();
        var teachers = await _db.HoSoGiaoViens.Include(g => g.NguoiDung).Include(g => g.GiaoVien_MonHocs).Take(2).ToListAsync();

        ViewBag.Subjects = subjects;
        ViewBag.Courses = courses;
        ViewBag.Teachers = teachers;
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public async Task<IActionResult> Pricing()
    {
        var packages = await _db.GoiPremiums.ToListAsync();
        return View(packages);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
