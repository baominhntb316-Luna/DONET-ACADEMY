using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using DONET_Academy.Core.Entities;
using DONET_Academy.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Dual-Mode Database Bridge with Auto-Detect & Graceful Fallback
var dbMode = builder.Configuration.GetValue<string>("DatabaseProvider:Mode") ?? "Auto";
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

bool useSqlServer = false;

if (dbMode.Equals("SqlServer", StringComparison.OrdinalIgnoreCase))
{
    // Bắt buộc dùng SQL Server
    useSqlServer = true;
}
else if (dbMode.Equals("InMemoryDemo", StringComparison.OrdinalIgnoreCase))
{
    // Bắt buộc dùng In-Memory Demo
    useSqlServer = false;
}
else // "Auto" (Mặc định: Tự động nhận diện)
{
    if (!string.IsNullOrWhiteSpace(connectionString))
    {
        try
        {
            var connBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                ConnectTimeout = 2 // Thử kết nối trong 2 giây để không làm chậm lúc mở web
            };
            using var testConn = new SqlConnection(connBuilder.ConnectionString);
            testConn.Open();
            useSqlServer = true;
        }
        catch
        {
            useSqlServer = false;
        }
    }
}

if (useSqlServer)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    // Chế độ In-Memory Demo: Chạy tức thì không cần cài DB ngoài
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("DONET_Academy_DemoDb"));
}

// 2. Identity Configuration
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// 3. MVC with Areas & Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 4. Seed Demo Data on Startup & Log Connection Status
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (useSqlServer)
    {
        try
        {
            db.Database.EnsureCreated();
            DemoDataSeeder.Seed(db);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" [DONET ACADEMY] ĐÃ KẾT NỐI SQL SERVER THÀNH CÔNG!");
            Console.WriteLine(" [Cơ sở dữ liệu] Hệ thống 55 thực thể UML đang lưu trữ trực tiếp vào SQL Server.");
            Console.WriteLine("================================================================================");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("================================================================================");
            Console.WriteLine($" [DONET ACADEMY - CẢNH BÁO] Không thể khởi tạo database trên SQL Server: {ex.Message}");
            Console.WriteLine("================================================================================");
            Console.ResetColor();
        }
    }
    else
    {
        DemoDataSeeder.Seed(db);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("================================================================================");
        Console.WriteLine(" [DONET ACADEMY] CHẾ ĐỘ DEMO IN-MEMORY (RAM) ĐANG HOẠT ĐỘNG");
        Console.WriteLine(" [Thông báo] Không tìm thấy kết nối SQL Server (hoặc cấu hình chế độ Demo).");
        Console.WriteLine(" [Trạng thái] Tự động nạp 100% dữ liệu mẫu để bạn và nhóm chạy demo an toàn.");
        Console.WriteLine("================================================================================");
        Console.ResetColor();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// Route riêng biệt cho Cổng Quản Trị: Khi gõ /Admin sẽ chuyển vào trang Đăng Nhập Quản Trị
app.MapAreaControllerRoute(
    name: "admin_root",
    areaName: "Admin",
    pattern: "Admin",
    defaults: new { controller = "Account", action = "Login" });

// Route for Areas: Student, Teacher, Admin
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

// Default Public Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
