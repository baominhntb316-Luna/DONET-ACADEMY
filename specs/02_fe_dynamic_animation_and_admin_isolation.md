# SPEC-KIT: NÂNG CẤP GIAO DIỆN DYNAMIC, HỆ THỐNG ANIMATION SKILLS & TÁCH BIỆT ADMIN TRONG DONET ACADEMY

## 1. Hiến pháp kỹ thuật (Constitution)
- **Kiến trúc**: ASP.NET Core MVC Layered Monolith (.NET 10), EF Core Code First, Dual-Mode Bridge (InMemoryDemo / SqlServer).
- **Hệ màu chuẩn**: Vàng Hổ Phách (`#FCB712` -> `#FA7E0A`), Nền Trắng Be (`#FAF8F5`), Bề mặt thẻ Trắng (`#FFFFFF`), Viền ấm (`#E6DDCF`), Chữ Đen Than (`#1C1917`).
- **Typography**: 100% Font Arial (`Arial, "Helvetica Neue", Helvetica, sans-serif`), nét dày đều, chuẩn Unicode tiếng Việt.
- **Micro-interactions (Emil Kowalski & Apple Design)**:
  - Spring-like easing: `cubic-bezier(0.16, 1, 0.3, 1)` cho mọi chuyển động.
  - Phản hồi lực nhấn: `:active { transform: scale(0.97); }` thời lượng 100ms.
  - Hover glow & elevation không vượt quá 250ms.
  - Hỗ trợ đầy đủ `@media (prefers-reduced-motion: reduce)`.
- **Bảo mật & Trải nghiệm**:
  - Tuyệt đối loại bỏ mọi dấu vết đồ án, UML, hay bài tập kỹ thuật trên UI khách hàng.
  - Tách biệt 100% không gian User (Học Sinh & Giáo Viên) và Quản Trị Viên (Admin).

---

## 2. Mô Tả Yêu Cầu Chức Năng (Specify)

### 2.1 Loại bỏ hoàn toàn thông tin "Đồ án / UML"
- Toàn bộ chân trang (Footer), Header và Meta thông tin thay thế bằng thông điệp thương hiệu chuyên nghiệp: "DONET ACADEMY — Nền Tảng Học Tập Trực Tuyến Đa Môn Chuẩn THPT".

### 2.2 Tách biệt 2 không gian trải nghiệm (User Layout vs Admin Layout)
- **User Portal (`_Layout.cshtml`)**:
  - Không có bất kỳ liên kết, nút bấm hay đề mục nào dẫn sang Admin.
  - Role Switcher chỉ cho phép chuyển đổi mượt mà giữa **Học Sinh THPT** và **Giáo Viên**.
  - Tích hợp thanh trượt chỉ báo (Sliding Indicator) có hiệu ứng chuyển màu và lướt mượt mà giữa 2 tab.
- **Admin Portal (`/admin` & `_AdminLayout.cshtml`)**:
  - Truy cập riêng biệt qua URL `/admin` hoặc `/Admin/Dashboard`.
  - Màn hình Đăng nhập Quản Trị (`/Admin/Account/Login`): Thiết kế bảo mật, chuyên nghiệp, tông màu Slate-Gold sang trọng, hiệu ứng dynamic, nút "Đăng Nhập Quản Trị" chuyển thẳng vào Dashboard.
  - Layout Quản trị độc lập: Sidebar chuyên dụng, thanh trạng thái bảo mật, thông báo hệ thống và nút thoát trang quản trị.

### 2.3 Cụm Đăng Nhập / Đăng Ký ẩn trong Linh vật Bé Chim (Góc phải Header)
- **Trạng thái thường**: Bé chim Hoàng Anh đứng ở góc phải, hiển thị bong bóng thoại nhỏ nhắn nhắc nhở tương tác ("Chào bạn! Đăng nhập để cùng tớ học nhé ✨").
- **Trạng thái Hover**: Bé chim lướt sang bên trái mượt mà (`translate`), để lộ cụm điều khiển Đăng Nhập / Đăng Ký dạng Segmented Switch.
- **Trạng thái Click**: Kích hoạt Modal Popup Đăng Nhập & Đăng Ký toàn diện:
  - Có tab chọn: **Dành cho Học Sinh** vs **Dành cho Giảng Viên**.
  - Form Đăng ký thu thập đầy đủ các trường dữ liệu theo UML:
    + *Học sinh*: Họ và tên, Email, Số điện thoại, Khối lớp (10, 11, 12), Tổ hợp môn quan tâm, Mật khẩu, Xác nhận mật khẩu.
    + *Giảng viên*: Họ và tên, Email, Số điện thoại, Môn giảng dạy chính, Bằng cấp/Đơn vị công tác, Link CV/Chứng chỉ nghiệp vụ, Giới thiệu ngắn, Mật khẩu.

### 2.4 Hệ thống Animation Dynamic toàn diện (Emil Kowalski + Apple Design)
- **Thanh Menu Đề Mục (Nav Links)**:
  - Khi hover: Hiện ô bóng mờ màu vàng cam ấm dịu (`rgba(252, 183, 18, 0.15)`), bo góc mềm, scale nhẹ 1.02.
  - Khi active: Nền gradient Vàng Hổ Phách (`#FCB712` -> `#FA7E0A`), chữ nổi bật, bóng đổ mềm xác định vị trí tức thì.
- **Ticker / Banner Tin Tức Động**:
  - Dải thông báo trượt động (Announcement Ticker) tự động luân chuyển tin tức, kỳ thi THPT và sự kiện gia sư 1-1 nổi bật.
- **Linh Vật Bé Chim Hoàng Anh Siêu Sinh Động**:
  - *3 trạng thái rảnh rỗi (Idle)*: Nháy mắt & nghiêng đầu; Nhún nhảy theo nhịp; Lượn nhẹ bồng bềnh.
  - *2 trạng thái Hover ngẫu nhiên*: Vẫy cánh chào tươi tắn hoặc Ngại ngùng cúi đầu.
  - *Trạng thái Click*: Vỗ cánh mở rộng + hiệu ứng zoom out mượt mà đưa người dùng đến trang Gia sư AI Tutor (`/Student/AiTutor`).
- **Hiệu ứng chuyển trang & Modal phong cách Apple**:
  - Chuyển trang mượt mà (Fade + subtle lift).
  - Modal mở ra: Scale từ 0.95 -> 1.0 với `cubic-bezier(0.16, 1, 0.3, 1)`.

---

## 3. Kế hoạch triển khai (Plan)

### File Giao diện & Mã nguồn cần cập nhật:
1. `DONET_Academy.Web/Views/Shared/_Layout.cshtml`: Cập nhật footer, thanh Role Switcher trượt 2 vai trò (Học sinh - Giáo viên), gắn cụm Linh vật ẩn Auth, thanh Nav Link có glow/active pill.
2. `DONET_Academy.Web/Areas/Admin/Views/Shared/_AdminLayout.cshtml`: Xây dựng Layout Quản Trị độc lập mới hoàn toàn.
3. `DONET_Academy.Web/Areas/Admin/Controllers/AccountController.cs`: Controller đăng nhập riêng cho Admin.
4. `DONET_Academy.Web/Areas/Admin/Views/Account/Login.cshtml`: Giao diện đăng nhập Admin riêng biệt, bảo mật, dynamic.
5. `DONET_Academy.Web/wwwroot/css/animations.css`: Bổ sung toàn bộ keyframe chuyển động: sliding segmented indicator, mascot idle states, waving/nodding, banner ticker, modal transitions, nav item glow.
6. `DONET_Academy.Web/wwwroot/js/site.js`: Bổ sung logic sliding indicator, random mascot hover interaction, click zoom transition, và xử lý modal Auth 2 đối tượng (Học sinh & Giảng viên).
7. `DONET_Academy.Web/Views/Shared/_AuthModal.cshtml`: Partial View Modal Đăng nhập / Đăng ký chi tiết đầy đủ trường thông tin UML.
8. `DONET_Academy.Web/Views/Home/Index.cshtml`: Tích hợp dải ticker thông báo động và tinh chỉnh hero banner.

---

## 4. Danh mục công việc chi tiết (Tasks)
- [ ] **Task 1: Dọn sạch nội dung Footer**: Xóa bỏ các dòng chữ đồ án/UML, thay bằng bản quyền và định vị sản phẩm chính thức.
- [ ] **Task 2: Phân tách Layout Admin & Trang Đăng Nhập Quản Trị**:
  - Tạo `_AdminLayout.cshtml` riêng cho `/Admin`.
  - Tạo trang `/Admin/Account/Login` với thiết kế bảo mật, tông màu slate-gold và hiệu ứng dynamic.
  - Bỏ nút Admin khỏi `_Layout.cshtml` của người dùng.
- [ ] **Task 3: Nâng cấp Role Switcher & Nav Menu Links**:
  - Tạo thanh trượt chỉ báo (Sliding Indicator Pill) chuyển đổi mượt mà giữa Học Sinh & Giáo Viên.
  - Thêm hiệu ứng glow hổ phách khi hover và gradient active pill khi đang ở đề mục đó.
- [ ] **Task 4: Tạo cụm Linh Vật giấu Auth & Modal Đăng nhập/Đăng ký chi tiết**:
  - Xây dựng cụm Header góc phải: Bé chim kèm bong bóng thoại $\to$ rê chuột trượt sang trái lộ nút switch Đăng nhập / Đăng ký.
  - Viết Partial View `_AuthModal.cshtml` với đầy đủ trường thông tin học sinh và giáo viên theo chuẩn UML.
- [ ] **Task 5: Xây dựng hệ thống Animation Linh vật Bé Chim & Ticker Động**:
  - 3 trạng thái rảnh rỗi (idle cycle), 2 biểu cảm hover ngẫu nhiên, hiệu ứng click zoom out chuyển trang AI Tutor.
  - Dynamic announcement ticker trên trang chủ.
- [ ] **Task 6: Tối ưu chuyển trang & hiệu ứng nút bấm Apple-style**:
  - Thêm hiệu ứng page-transition mượt mà và nút bấm đàn hồi xúc giác.
- [ ] **Task 7: Build & Smoke Test**:
  - Kiểm tra build thành công 0 lỗi và chạy test tất cả các route.

