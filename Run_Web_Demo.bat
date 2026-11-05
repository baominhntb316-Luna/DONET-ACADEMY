@echo off
chcp 65001 > nul
title DONET ACADEMY - Khởi Chạy Web Demo (In-Memory Database)
cls
echo ===============================================================================
echo                DONET ACADEMY — NỀN TẢNG HỌC TẬP TRỰC TUYẾN THPT
echo      Chế độ Demo In-Memory: Sẵn sàng 100%% dữ liệu mẫu, không cần cài Database
echo ===============================================================================
echo.

echo [1/3] Đang kiểm tra môi trường .NET SDK trên máy...
dotnet --version > nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo [LỖI] Máy tính của bạn chưa cài đặt .NET SDK!
    echo.
    echo Để chạy web, bạn chỉ cần tải và cài đặt .NET SDK (miễn phí từ Microsoft) tại:
    echo     https://dotnet.microsoft.com/download
    echo.
    pause
    exit /b
)

echo [2/3] Môi trường .NET hợp lệ. Đang tự động mở trình duyệt web...
timeout /t 2 /nobreak > nul
start "" "http://localhost:5128"

echo [3/3] Đang khởi động máy chủ Web DONET Academy...
echo.
echo -------------------------------------------------------------------------------
echo    Trang chủ Học sinh:       http://localhost:5128
echo    Cổng Quản Trị (Admin):    http://localhost:5128/Admin
echo.
echo    Mẹo: Giữ cửa sổ này mở để duyệt web. Khi muốn dừng, hãy đóng cửa sổ này.
echo -------------------------------------------------------------------------------
echo.
dotnet run --project "DONET_Academy.Web\DONET_Academy.Web.csproj"
pause

