# BỘ QUY TẮC LÀM VIỆC DỰ ÁN DONET ACADEMY

## A. Đọc lại quy tắc và ngữ cảnh

1. Trước mỗi nhiệm vụ, đọc lại file quy tắc này và các ghi chú quy tắc cũ đã lưu trong dự án.
2. Không bỏ qua quy tắc cũ, kể cả với nhiệm vụ nhỏ. Nếu yêu cầu mới mâu thuẫn với quy tắc cũ, hỏi lại người dùng trước khi làm.
3. Khi người dùng đưa ra quy tắc mới có tính lâu dài, thêm vào file quy tắc với số thứ tự tiếp theo. Không ghi đè quy tắc cũ trừ khi được yêu cầu.

## B. Cấu trúc và quy ước code

4. Trước khi tạo hoặc sửa code, khảo sát cấu trúc hiện có: file `.sln`, các project, namespace, cách đặt tên file và các tầng (Controllers, Services, Repositories, Models, DTOs...).
5. Giữ nguyên kiến trúc (quy ước đặt tên, cách dùng DI, async/await, ORM,...) và phong cách format đang có (mới nhất) trong bộ não của bạn (cập nhật theo kiến trúc phân tầng Layered Monolith / MVC đề xuất, EF Core Code First, SQL Server, Identity int, 55 thực thể UML). Không tự đổi kiến trúc hay thêm thư viện mới khi chưa được phép.
6. Không tạo file hay thư mục mới ngoài cấu trúc hiện có (trong bộ não bạn), trừ khi thật sự cần và phải nêu rõ lý do.
7. Chỉ sửa những file liên quan trực tiếp đến nhiệm vụ. Không refactor, đổi format hay xóa code không liên quan.
8. Không tự chạy migration, xóa dữ liệu hay sửa cấu hình môi trường (`appsettings`, connection string) khi chưa được yêu cầu.

## C. Thiết kế UI Frontend

9. Ưu tiên tối giản và cá tính rõ ràng: bố cục gọn, khoảng trắng hợp lý, có animation (nhẹ nhàng, có mục đích) cho giao diện khi người dùng tương tác.
10. Không thêm icon nếu người dùng không yêu cầu. Khi thật sự cần icon để truyền đạt ý nghĩa (ví dụ nút đóng), chỉ dùng bộ icon đã có sẵn trong dự án.
11. Không dùng emoji làm icon trong giao diện.
12. Tái sử dụng component, màu sắc, font và spacing đã quy chuẩn:
    - **Màu chủ đạo:** Vàng Hổ Phách (`#FCB712` / `#F9BC0C`) chuyển sắc mềm mại sang Cam Vàng (`#FA7E0A`).
    - **Nền & Bề mặt:** Trắng Be dịu mắt (`#FAF8F5`) cho toàn trang, thẻ card nền Trắng (`#FFFFFF`), viền ấm (`#E6DDCF`).
    - **Màu chữ:** Đen than / xám đậm trung tính (`#1C1917` / `#262626`).
    - **Font chữ (Typography):** Font chữ tối giản **Arial** (`Arial, "Helvetica Neue", Helvetica, sans-serif`). Đảm bảo độ dày nét (weight) đồng đều 100%, không bị lỗi nét đậm nét nhạt, chuẩn Unicode tiếng Việt tuyệt đối, tối ưu tốc độ tải trang tức thì.
    - **Bộ nhận diện thương hiệu:**
      + Logo DA chính thức chuyển sắc Vàng Hổ Phách (giữ nguyên hình học: biểu tượng ribbon D mũi tên ngôi sao bên trái, cụm chữ `DONET ACADEMY` canh hàng chân bên phải).
      + Linh vật: Bé Chim Hoàng Anh Chibi Anime tối giản, mập mạp và dễ thương.
    - Không tự ý tạo thêm hệ thống style song song. Bố cục và bài trí màn hình sẽ được thiết kế linh hoạt, bám sát logic chức năng 55 thực thể UML qua từng giai đoạn và chưa khóa cố định tại đây.
13. Giao diện có dữ liệu động phải có trạng thái loading, rỗng và lỗi, đồng thời đảm bảo responsive cơ bản.

## D. File tạm và công cụ phụ trợ (Đã cập nhật theo Prompt Đối Chiếu)

14. Mọi file công cụ do AI tự sinh để hỗ trợ thực thi nhiệm vụ, không phải file của dự án (script kiểm tra, file JSON thử nghiệm, script sinh dữ liệu, file log tạm...), phải được tạo trong thư mục: `"D:\CODE programe\DOTNET Pj\Temp_bin"`
15. Không tạo hoặc lưu file tạm, cache, log, output hay ảnh chụp trên ổ C. Ngoại lệ duy nhất là thư mục skill toàn hệ thống nêu ở mục G. Trước khi ghi file, kiểm tra đường dẫn. Nếu không nằm trên D trong `D:\CODE programe\` thì dừng lại và sửa.
16. Khi chạy lệnh có thể sinh file (như `dotnet new`, build output, npm cache), cấu hình đường dẫn đầu ra về `Temp_bin` hoặc thư mục cache trên D nếu công cụ cho phép. Nếu không thể, báo rõ cho người dùng.
17. Đường dẫn có khoảng trắng phải đặt trong dấu ngoặc kép khi chạy lệnh, ví dụ `"D:\CODE programe\DOTNET Pj\Temp_bin"`.
18. Sau khi hoàn thành nhiệm vụ, chỉ xóa file trong `D:\CODE programe\DOTNET Pj\Temp_bin` không còn cần thiết. Không xóa `D:\CODE programe\AI_Tools\`, thư mục skill toàn hệ thống, hay file đã liệt kê trong `installed.md`.
19. Không xóa file hay thư mục của chính dự án nằm ngoài `Temp_bin`. Không xóa file trong `Temp_bin` mà người dùng đang dùng nếu chưa hỏi.
20. Nếu nhiệm vụ bị gián đoạn giữa chừng, dọn file tạm ở lần làm việc tiếp theo hoặc báo cho người dùng biết những file còn tồn tại.

## E. Trao đổi và báo cáo

21. Với thay đổi lớn, tóm tắt kế hoạch ngắn gọn trước khi thực hiện.
22. Sau khi xong, báo cáo ngắn gọn: đã sửa những file nào, đã xóa những file tạm nào trong `Temp_bin`, và có điểm nào người dùng cần kiểm tra thủ công.
23. Không khẳng định build hay test thành công nếu chưa thực sự chạy. Nếu có lỗi hoặc chưa kiểm tra được, nói rõ.

## F. Quy chuẩn phối hợp bộ ba công cụ: Spec-Kit, Impeccable và Emil-Design-Eng

24. **Vai trò kỹ sư Frontend trong dự án DONET ACADEMY:**
    - Vị trí mã nguồn Frontend: nằm trong `DONET_Academy.Web/Views/` (Razor Views, Partial Views) và `DONET_Academy.Web/wwwroot/` (CSS, JavaScript modules, assets) thuộc thư mục dự án `"D:\CODE programe\DOTNET Pj\DONET_Academy_Project"`.
    - Nền tảng công nghệ: ASP.NET Core MVC (Razor Views + Partial Views + Bootstrap 5 + Modular JavaScript + SignalR).
    - Tuyệt đối lưu trữ mọi file dự án trong ổ D tại `"D:\CODE programe\DOTNET Pj\DONET_Academy_Project"`, không lưu vào ổ C.

25. **Nguồn tham chiếu đã cài đặt:**
    - `spec-kit` (`github/spec-kit`): Quản lý quy trình Spec-Driven Development qua thư mục `.specify/` và các lệnh quy trình `/speckit.*` (`specify-cli`).
    - `impeccable` (`pbakaus/impeccable`): Skill thẩm mỹ và chất lượng giao diện (`shape`, `critique`, `audit`, `polish`, `bolder`, `quieter`, `typeset`, `layout`, `distill`, `harden`...).
    - `emil-design-eng` (`emilkowalski/skills`): Skill chuyên sâu về vi chuyển động và hoạt ảnh (`animate`, `review-animations`, `choreograph`, `animation-performance`, `apple-design`, `break-ui`...).

26. **Thứ tự ưu tiên khi có mâu thuẫn:**
    1. Quy tắc dự án ([AGENTS.md](file:///d:/CODE%20programe/DOTNET%20Pj/DONET_Academy_Project/AGENTS.md) và constitution của spec-kit): Cao nhất.
    2. Spec, plan, tasks đã được người dùng duyệt.
    3. Kiến trúc, cấu trúc thư mục, design tokens và component đang có trong dự án.
    4. `impeccable`: Quyết định về bố cục, phân cấp thị giác, typography, màu sắc, khoảng cách.
    5. `emil-design-eng`: Quyết định về chuyển động, chỉ trong phạm vi impeccable và spec cho phép.

27. **Quy trình thực thi 4 bước:**
    - **Bước 1: Spec-Kit khóa hướng đi (Bắt buộc ở mọi khâu):**
      - 1.1 Constitution (`/speckit.constitution`): Bám sát [AGENTS.md](file:///d:/CODE%20programe/DOTNET%20Pj/DONET_Academy_Project/AGENTS.md), kiến trúc phân tầng MVC, quy tắc file tạm `Temp_bin`, quy chuẩn UI tối giản.
      - 1.2 Specify (`/speckit.specify`): Mô tả hành vi và kết quả mong muốn, chưa nêu giải pháp công nghệ.
      - 1.3 Clarify (`/speckit.clarify`): Liệt kê tối đa 5 điểm chưa rõ quan trọng nhất để hỏi người dùng. Không tự đoán.
      - 1.4 Plan (`/speckit.plan`): Liệt kê file FE sẽ sửa, component và token tái sử dụng. Không thêm thư viện mới.
      - 1.5 Tasks (`/speckit.tasks`): Sắp xếp tuần tự: (a) Layout & Component $\to$ (b) State & Dữ liệu (loading, empty, error) $\to$ (c) Thẩm mỹ theo Impeccable $\to$ (d) Chuyển động theo Emil $\to$ (e) Kiểm tra.
      - 1.6 **Dừng lại:** Trình bày spec, plan và tasks để người dùng duyệt trước khi viết code.
    - **Bước 2: Implement Frontend (Chỉ sau khi người dùng duyệt):**
      - 2.1 Thực hiện từng task theo `/speckit.implement`. Xong mỗi task báo cáo ngắn gọn.
      - 2.2 Thiết kế UI theo Impeccable.
      - 2.3 Chuyển động theo Emil-Design-Eng.
      - 2.4 Quản lý file tạm nghiêm ngặt trong `Temp_bin`.
    - **Bước 3: Kiểm tra và đối chiếu:**
      - 3.1 Đối chiếu code với spec, plan và constitution.
      - 3.2 Checklist UI: Đủ trạng thái loading, empty, error; responsive; reduced-motion; không layout thrash.
      - 3.3 Chạy build và test thật sự.
    - **Bước 4: Báo cáo:**
      - Liệt kê task hoàn thành, đường dẫn file đã sửa, báo cáo file `Temp_bin`.

28. **Ràng buộc chung bất biến:**
    - Không tự cài thư viện mới và không tự ý thay đổi kiến trúc.
    - Không bao giờ bỏ qua bước dừng lại chờ người dùng duyệt (1.6) trước khi viết code.
    - Khi không chắc chắn, hỏi người dùng, tuyệt đối không tự suy đoán.

## G. Cài đặt công cụ và skill toàn hệ thống (Đã chuẩn hóa theo Prompt 2)

29. Mọi repo, skill hay công cụ mà người dùng yêu cầu cài đều là cài toàn hệ thống. Đặt tại `C:\Users\baomi\.gemini\config\skills\<tên-skill>\`. Không copy vào dự án trừ khi người dùng nói rõ.

30. Quy trình cài đặt chuẩn 7 bước:
    a. Xác định nguồn và tên skill.
    b. Clone vào `D:\CODE programe\DOTNET Pj\Temp_bin\_src\` để đọc.
    c. Đọc SKILL.md và README, liệt kê phụ thuộc, lệnh cài và rủi ro (nếu có).
    d. Trình bày kế hoạch và chờ người dùng duyệt.
    e. Copy đúng phần skill cần thiết vào thư mục toàn hệ thống `C:\Users\baomi\.gemini\config\skills\<tên-skill>\`.
    f. Xóa bản clone trong `_src\`.
    g. Ghi một dòng vào `D:\CODE programe\AI_Tools\installed.md`: tên, nguồn, ngày cài, đường dẫn đích, phụ thuộc đã cài.

31. Phụ thuộc Python hoặc Node chỉ được cài vào môi trường riêng trong `D:\CODE programe\AI_Tools\envs\<tên-skill>\` (venv hoặc npm với `--prefix`). Đặt cache trên D khi công cụ cho phép (ví dụ `PIP_CACHE_DIR`, `npm_config_cache`, `UV_CACHE_DIR`).

32. Ngoại lệ ổ C chỉ gồm: thư mục skill toàn hệ thống và file cấu hình Antigravity khi người dùng yêu cầu. Ngoài ra vẫn cấm mọi ghi trên C.

33. Nếu tên skill trùng với skill đã có, hỏi người dùng trước khi ghi đè.

34. Khi người dùng yêu cầu gỡ một skill: xóa đúng thư mục đã ghi trong `installed.md`, cập nhật file đó, và báo cáo. Không xóa thứ khác.

35. Tách bạch hai loại:
    - Cấp hệ thống: skill `impeccable`, `ui-ux-pro-max`, `emil-design-eng`, công cụ CLI `spec-kit`.
    - Cấp dự án: thư mục `.specify/`, `specs/`, `AGENTS.md` (hoặc file quy tắc dự án). Đây là tài liệu của dự án nên luôn nằm trong thư mục DOTNET.

## H. Thiết kế sáng tạo, động và không xung đột (ui-ux-pro-max + impeccable + emil-design-eng)

36. **Mục tiêu thiết kế:**
    Giao diện phải có cá tính rõ ràng, chuyển động có chủ đích và tài nguyên thị giác được tự tạo, không gò bó quá mức tối giản đơn điệu nhưng phải nhất quán với dự án, không sao chép bố cục, màu thương hiệu, nhân vật, linh vật, hay chuyển động đặc trưng của sản phẩm nào khác (tham khảo ý tưởng, không sao chép).

37. **Quy trình chuỗi làm việc khi có sản phẩm/màn hình mới:**
    - 1. `spec-kit`: constitution, specify, clarify, plan, tasks $\to$ Dừng để người dùng duyệt.
    - 2. `ui-ux-pro-max`: tạo 2 đến 3 hướng thiết kế khác nhau (phong cách, bảng màu, cặp font, nhịp bố cục, ý tưởng hiệu ứng). Mỗi hướng phải có lý do gắn với mục đích màn hình. Không chọn hướng nào khi chưa so sánh. Không chạy ui-ux-pro-max ở bước code (chỉ dùng ở bước khám phá hướng thiết kế).
    - 3. `impeccable`: đánh giá các hướng, chọn một hướng hoặc kết hợp có chọn lọc, rồi viết "concept statement" một câu mô tả cảm giác giao diện muốn tạo (quyết định thẩm mỹ cuối cùng).
    - 4. Dừng để người dùng duyệt design direction (không quá 1 trang), lưu vào thư mục `specs/`.
    - 5. Implement layout và component theo spec.
    - 6. `impeccable`: thực hiện tinh chỉnh thẩm mỹ.
    - 7. `emil-design-eng`: thiết kế chuyển động có chủ đích.
    - 8. Kiểm tra và báo cáo đối chiếu.

38. **Quyền hạn khi xung đột:**
    - Phong cách, bố cục, màu, font: `impeccable` quyết định. `ui-ux-pro-max` chỉ đề xuất.
    - Icon, emoji: không dùng tùy tiện. Nếu cần icon truyền đạt chức năng, dùng bộ icon có sẵn trong dự án.
    - Gradient và hiệu ứng trang trí: chỉ dùng nếu `impeccable` chọn và có lý do gắn với bản sắc. Không dùng glassmorphism hay neumorphism bừa bãi.
    - Thư viện animation (Framer Motion, GSAP, Lottie, Rive...): không cài khi chưa được duyệt. Ưu tiên CSS và công cụ thuần có sẵn trong dự án.
    - Hai nguồn đề xuất giá trị khác nhau: lấy giá trị trong design tokens. Nếu chưa có thì tạo một lần duy nhất.
    - Không tự giải quyết được: dừng và hỏi người dùng.

39. **Sáng tạo có kiểm soát & Tài nguyên thị giác:**
    - Ưu tiên tự tạo bằng CSS và SVG thuần: hình khối, đường nét, texture nhẹ, hình học theo lưới, minh họa vẽ bằng path. Mỗi tài nguyên phải phục vụ nội dung hoặc tạo điểm nhấn.
    - Không tải asset từ nguồn ngoài khi chưa được duyệt.
    - Mỗi màn hình có tối đa một điểm nhấn thị giác chính.
    - Không dùng linh vật/nhân vật có tính thương hiệu của sản phẩm khác. Asset lưu đúng thư mục quy định.

40. **Hiệu ứng động có mục đích (Trả lời được: "giúp người dùng hiểu điều gì?"):**
    - Phản hồi nút & tương tác: hover, active (nhấn nhẹ scale 0.97 - 0.98), focus-visible rõ ràng.
    - Chuyển trang/màn: fade kết hợp dịch chuyển nhẹ 8-16px, thời lượng 200-300ms.
    - Mở/đóng: modal, dropdown dùng transform & opacity với transform-origin đúng điểm neo.
    - Loading: skeleton đúng hình dạng, shimmer nhẹ, không nhấp nháy.
    - Quy tắc kỹ thuật: Chỉ animate transform & opacity, không animate layout properties (width, height, top, left...). Bắt buộc có `@media (prefers-reduced-motion: reduce)`.
