using Microsoft.AspNetCore.Mvc;

namespace DONET_Academy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            // Nếu phiên làm việc đã xác thực Admin, chuyển thẳng vào Dashboard
            if (HttpContext.Session?.GetString("AdminAuth") == "true")
            {
                return Redirect("/Admin/Dashboard");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, string? returnUrl = null)
        {
            // Khung xác thực Admin sẵn sàng kết nối Identity / SQL Server
            // Trong chế độ Demo: Xác thực thành công và lưu cờ phiên làm việc
            HttpContext.Session?.SetString("AdminAuth", "true");
            
            // Nếu có returnUrl hợp lệ (và khác cổng /Admin) thì chuyển tới đó
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) && !returnUrl.Equals("/Admin", StringComparison.OrdinalIgnoreCase))
            {
                return Redirect(returnUrl);
            }

            // Chuyển hướng tường minh vào trang Tổng Quan Quản Trị Hệ Thống
            return Redirect("/Admin/Dashboard");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session?.Remove("AdminAuth");
            return Redirect("/Admin");
        }
    }
}
