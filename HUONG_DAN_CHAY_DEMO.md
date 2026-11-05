# HƯỚNG DẪN CHẠY DEMO WEB DONET ACADEMY (KHÔNG CẦN DATABASE)

Dự án **DONET ACADEMY** được xây dựng trên nền tảng **ASP.NET Core MVC (.NET 10)** với kiến trúc phân tầng kết hợp **EF Core In-Memory Database**. 

> **Các thành viên trong nhóm** nhận file mã nguồn là có thể chạy ngay lập tức để demo toàn bộ chức năng, **hoàn toàn KHÔNG cần cài đặt SQL Server, không cần cấu hình chuỗi kết nối**. Toàn bộ dữ liệu mẫu (học sinh, giáo viên, khóa học, đề thi, ví tiền) được hệ thống tự động khởi tạo trong bộ nhớ RAM khi bật web.

---

## 1. Yêu cầu duy nhất trên máy tính

* Cài đặt **.NET SDK** (khuyên dùng .NET 10 hoặc .NET 8 trở lên) từ Microsoft (miễn phí):
  👉 Tải tại: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

---

## 2. Ba (03) cách mở Web cực kỳ đơn giản

### 🌟 Cách 1: Dành cho tất cả thành viên — Nhấp đúp chuột vào file `.bat` (Khuyên dùng)
1. Trong thư mục dự án, tìm file: **`Run_Web_Demo.bat`**
2. **Nhấp đúp chuột (Double click)** vào file này.
3. Cửa sổ dòng lệnh sẽ tự động kiểm tra .NET, khởi động máy chủ và **tự động mở trình duyệt Chrome/Edge** vào thẳng địa chỉ: `http://localhost:5128`.
4. Khi muốn tắt web: chỉ việc đóng cửa sổ dòng lệnh màu đen lại là xong.

---

### 💻 Cách 2: Chạy bằng Terminal / PowerShell (Dành cho Developer)
1. Mở cửa sổ Terminal (PowerShell hoặc Command Prompt) tại thư mục dự án.
2. Gõ lệnh:
   ```bash
   dotnet run --project DONET_Academy.Web
   ```
3. Sau 3 giây, mở trình duyệt web bất kỳ và truy cập: **`http://localhost:5128`**

---

### 🚀 Cách 3: Chạy trực tiếp trong Antigravity IDE / VS Code / Visual Studio
* **Trong Antigravity IDE hoặc Visual Studio Code:**
  1. Mở thư mục dự án trong IDE.
  2. Bấm phím **F5** (hoặc chọn menu `Run` $\to$ `Start Debugging` / `Run Without Debugging Ctrl+F5`).
  3. Chọn cấu hình: **`Chạy Web DONET Academy (.NET Core)`**. IDE sẽ tự động build và mở web.
* **Trong Visual Studio 2022/2026:**
  1. Nhấp đúp mở file giải pháp `DONET_Academy.slnx` (hoặc `.sln`).
  2. Chọn project khởi động là `DONET_Academy.Web`.
  3. Bấm nút **Run (tam giác màu xanh / F5)** để duyệt web.

---

## 3. Các địa chỉ Demo chính trong hệ thống

* **Trang chủ giới thiệu:** `http://localhost:5128/`
* **Phân hệ Học sinh THPT:** `http://localhost:5128/Student/Dashboard`
  * Ví tiền & Nạp thẻ VietQR: `http://localhost:5128/Student/Wallet`
  * Khóa học: `http://localhost:5128/Student/Courses`
  * Phòng thi & Đề thi: `http://localhost:5128/Student/Exams`
  * AI Tutor: `http://localhost:5128/Student/AiTutor`
* **Phân hệ Giáo viên / Gia sư:** `http://localhost:5128/Teacher/Dashboard`
  * Ví giáo viên & Rút tiền: `http://localhost:5128/Teacher/Wallet`
  * Quản lý lịch dạy: `http://localhost:5128/Teacher/Schedule`
* **Cổng Quản trị Admin bí mật:** `http://localhost:5128/Admin` (Chỉ người có liên kết này mới truy cập được giao diện đăng nhập Admin).

---

## 4. Cơ chế Nhận diện Database Tự động (Auto-Detect & Graceful Fallback)

Hệ thống được tích hợp sẵn cầu nối kép (Dual-Mode Bridge) cực kỳ linh hoạt:
* **Khi máy có SQL Server đang chạy:** Web tự động phát hiện, kết nối trực tiếp vào SQL Server thật, khởi tạo database và lưu trữ dữ liệu bền vững (Hiển thị thông báo màu xanh lá trên Console).
* **Khi máy KHÔNG có SQL Server (hoặc chưa bật dịch vụ):** Web tự động chuyển sang chế độ Demo In-Memory, nạp 100% dữ liệu giả lập vào RAM để duyệt web bình thường mà không bị crash lỗi (Hiển thị thông báo màu vàng trên Console).
* **Tùy chỉnh chế độ trong `appsettings.json`:**
  * `"Mode": "Auto"` (Mặc định: Tự nhận diện và chuyển đổi an toàn).
  * `"Mode": "SqlServer"` (Bắt buộc dùng SQL Server thật).
  * `"Mode": "InMemoryDemo"` (Bắt buộc dùng dữ liệu mẫu trong RAM).


