# Chương Trình Tính Toán Lộ Trình Sử Dụng API GraphHopper

## 1. Giới Thiệu
Chương trình này sử dụng [GraphHopper API](https://www.graphhopper.com/) để tính toán lộ trình giữa hai địa điểm dựa trên thông tin địa chỉ do người dùng nhập. Kết quả trả về bao gồm tuyến đường và khoảng cách giữa hai điểm trên bản đồ, được hiển thị bằng GMapControl.

## 2. Yêu Cầu Cài Đặt
Để sử dụng chương trình, bạn cần cài đặt các thư viện sau thông qua **NuGet Package Manager** trong Visual Studio:
- **GMap.NET**: Để hiển thị bản đồ.
- **GraphHopper API**: Để tính toán lộ trình giữa các điểm.
- **Newtonsoft.Json**: Để xử lý JSON trả về từ API.
- **HttpClient**: Để gửi yêu cầu API thông qua HTTP.

## 3. Cách Cấu Hình GraphHopper API

### Bước 1: Đăng Ký API Key
- Đăng ký một tài khoản tại [GraphHopper](https://www.graphhopper.com/) và tạo API Key.
- Thêm API Key vào chương trình của bạn tại dòng khai báo key trong hàm gọi API.

### Bước 2: Gọi API Để Tính Toán Lộ Trình
Khi người dùng nhấn nút "Tính Toán", chương trình sẽ gọi API của GraphHopper để lấy thông tin lộ trình giữa điểm bắt đầu và kết thúc. Thông tin này bao gồm:
- Tọa độ các điểm trong tuyến đường.
- Khoảng cách giữa hai điểm.

### Bước 3: Hiển Thị Lộ Trình Lên Bản Đồ
Sau khi nhận được dữ liệu lộ trình từ API, chương trình sẽ vẽ tuyến đường lên bản đồ sử dụng GMapControl, đồng thời hiển thị khoảng cách trên giao diện.

## 4. Hướng Dẫn Sử Dụng

1. Nhập tọa độ (hoặc địa chỉ) của điểm bắt đầu và điểm kết thúc vào hai ô TextBox.
2. Nhấn nút "Tính Toán" để tính toán và hiển thị lộ trình trên bản đồ.
3. Khoảng cách giữa hai điểm sẽ được hiển thị trên Label.

## 5. Cấu Trúc Chương Trình
- **GetRouteFromGraphHopper**: Hàm gọi API của GraphHopper để lấy dữ liệu lộ trình.
- **DrawRoute**: Hàm vẽ lộ trình lên bản đồ bằng GMapControl.
- **HttpClient**: Được sử dụng để gửi yêu cầu GET tới API và nhận phản hồi JSON.
- **Newtonsoft.Json**: Dùng để parse dữ liệu JSON trả về từ API.

## 6. Kết Luận
Chương trình cho phép bạn tính toán lộ trình giữa hai địa điểm một cách nhanh chóng và dễ dàng nhờ vào GraphHopper API. Việc hiển thị lộ trình và khoảng cách trên bản đồ giúp bạn có cái nhìn trực quan hơn về chuyến đi của mình.

## 7. Liên Hệ
Nếu có thắc mắc hoặc gặp lỗi, vui lòng liên hệ [thanhtinh.yarushi@gmail.com].
