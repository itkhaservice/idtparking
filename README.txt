Hiện tại, đã hoàn thành xong phần mềm dành cho Kế toán quản lý dữ liệu hệ thống xe. 
Hãy lên ý tưởng để viết chương trình cài đặt tại máy tính bãi xe để kiểm soát xe ra vào - phần mềm dành cho Bảo vệ

Phần mềm này sẽ chung Solution, build cho máy server tên là IDTSERVER. Máy tính này sẽ kết nối với đầu đọc thẻ từ, barier, camera.

Thiết kế để phù hợp cho nhiều nhu cầu khác nhau như
- Hệ thống gồm 1 máy kiểm soát ra và vào chỉ dành cho xe máy (Tổng cộng 2 đầu đọc thẻ - 4 camera - 2 barrier) (1 làn ra + 1 làn vào)

Hệ thống có thể set camera dạng IP hoặc analog từ đầu ghi. 
Có các remote để mở/dừng/đóng cần barier. 
Phần mềm cũng có chức năng kích mở barier, ở mỗi barier đều có mắt cảm biến hạ cần chắn barier khi xe đi qua, dừng cần khi xe chưa qua hết. 
Phần mềm có thể tinh chỉnh thông số các cổng COM, USB để kết nối đến các thiết bị ngoại vi hỗ trợ hệ thống như camera ghi hình(qua đầu ghi/qua switch mạng), đầu đọc thẻ tầm gần(qua cổng COM).  

Phần mềm có thể co giãn ở nhiều kích thước màn hình khác nhau như 19, 21, 22, 24, 27inches. 
Màn hình hiển thị sẽ gồm các ô camera, vùng để thể hiện thông tin thể vãng lai, thẻ tháng, số tiền, thời gian ra và thời gian vào.

Bảo vệ chỉ được phép sử dụng màn hình chính để kiểm soát xe ra vào
IT có thể cấu hình phần mềm
Kế toán có thể đăng nhập để sử dụng như Phần mềm Kế toán quản lý dữ liệu hệ thống xe
Dùng chung SQL mô tả trong file .cs

Trên phần mềm Bảo vệ có thể sử dụng được các nút
Esc - Thoát chương trình (Có hỏi xác nhận lại)
F1 - Đăng nhập để sử dụng
F2 - Đăng xuất - Hiển thị thông tin giao ca 
F3 - Mở bảng cấu hình phần mềm để hoạt động
F4 - Đăng nhập vào Quản lý dữ liệu hệ thống xe (Như các chức năng của Kế toán)
F7 - Đổi làn ra/vào bên màn hình bên trái
F8 - Đổi làn ra/vào bên màn hình bên phải
F11- Reset chương trình
F12 - Thoát ra màn hình chính

Thông tin màn hình chính
   * Hàng 1 (Camera Live): 30%
   * Hàng 2 (Thông tin xe): 40%
   * Hàng 3 (Snapshots): 30%

Hàng 2 (Thông tin xe): 40% 
Ảnh vào - Ảnh ra: Là ảnh nhận diện biển số và đọc bằng AI, tỉ lệ chiều ngang - dọc theo hình camera live và camera chụp lại snapshots

Thông tin thẻ xe
SỐ THẺ:
LOẠI XE:
CHỦ XE:
BIỂN SỐ:
THỜI GIAN:
THỜI ĐIỂM VÀO:
THỜI ĐIÊM RA:
THANH TOÁN (PHÍ LƯỢT):
25.000 VNĐ
Được trải dài bên phải phần nhận diện biển số
2 thông tin quan trọng font chữ to hơn 1 xíu có màu sắc để nhận diện nhanh là 
CHỦ XE
BIỂN SỐ
ĐỊA CHỈ (bổ sung thêm)

Tính năng cho nút F2 Giao ca
--------------------------------------
 XÁC NHẬN BÀN GIAO CA
--------------------------------------
Ca: Ca ngày → Ca đêm
Thời gian: 06:00 - 18:00
Bàn giao: Nguyễn Văn A
Nhận ca: Trần Văn B
------------------------------
Xe vào: 120     
Xe ra: 110
Trong bãi: 10

Xe vãng lai: 110
	- Vãng lai ô tô: 10
	- Vãng lai xe máy: 50
Xe tháng: 150

Tổng tiền vãng lai: 2,500,000 VND
	- Vãng lai ô tô: 150,000 VND
	- Vãng lai xe máy: 200,000 VND

⚠ Cảnh báo:
- 2 Thẻ sai biển số (AI nhận diện)
- 5 Thẻ bị khóa (đã quẹt vào máy)
- 7 Thẻ bị hết hạn (đã quẹt vào máy)

--------------------------------------
      [Đồng ý]   [Hủy]

npx @google/gemini-cli

Sử dụng khoảng trắng giữa Section 2 và Section làm vùng hiển thị thông tin sau khi quẹt thẻ ở mỗi làn
Ví dụ
Vui lòng Đăng nhập phần mềm để sử dụng !
Thẻ chưa có dữ liệu vào. Vui lòng RA bãi !
Thẻ chưa có dữ liệu ra. Vui lòng VÀO bãi !
Thẻ bị khóa. Vui lòng liên hệ Ban quản lý để MỞ thẻ !
Thẻ hết hạn. Vui lòng liên hệ Ban quản lý để GIA HẠN thẻ !
XIN MỜI VÀO !
HẸN GẶP LẠI !

Chức năng Cài đặt có 5 tab chính
HỆ THỐNG	
Máy chủ & và Kết nối	
Server name: 	192.168.1.19
Server Local: 	192.168.1.19
Cổng:	1443
Nút 	Kiểm tra kết nối với Server
Thông báo kết quả kết nối	
Cơ sở dữ liệu	
Username	sa
Password	123ABC
Dữ liệu	Giuxe
Nút 	Kiểm tra kết nối với Dữ liệu
Thông báo kết quả kết nối	
Đường dẫn lưu hình ảnh	
Local Path	D:\PARKING_IMAGES
URL Server	http://117.4.91.45:85/images
Backup Path	E:\BACKUP_DB
Tùy chọn vận hành hệ thống	
Nút checkbox	Tăng tốc độ xử lý khi quẹt thẻ
Nút checkbox	Đồng bộ dữ liệu (Chế độ 3 máy)
Nút checkbox	Tự động kết nối lại khi rớt Server
Nút checkbox	In vé tự động cho xe hơi
Nút checkbox	Chế độ xem hình online
Nút checkbox	Hiển thị báo cáo doanh thu khi ra ca
Nút checkbox	Đọc giá tiền bằng giọng nói AI
Nút checkbox	Phát âm thanh cảnh báo giọng nói
Bên dưới cùng nút	Lưu cài đặt Hệ thống
Bên trái nút 	Hướng dẫn cấu hình
THIẾT BỊ	
Cho phép cho bên trái hay bên phải là Làn ra hay Làn vào	
Cho phép cấu hình Camera	
Camera IP (Qua địa chỉ IP)	
Camera Analog (Qua đầu ghi)	
Làn bên Phải	
Cấu hình thông tin Camera Chụp sau (Biển số)	
Cấu hình thông tin Camera Chụp trước (Toàn cảnh)	
Cấu hình Đầu đọc thẻ Cổng COM	
Làn bên Trái	
Cấu hình thông tin Camera Chụp sau (Biển số)	
Cấu hình thông tin Camera Chụp trước (Toàn cảnh)	
Cấu hình Đầu đọc thẻ Cổng COM	
Bên dưới cùng nút	Lưu cài đặt Thiết bị
Bên trái nút 	Hướng dẫn cấu hình
LOẠI THẺ	
Thêm/Xóa/Sửa	Loại thẻ
Mã Loại	
Diễn dãi	
Checkbox	Kích hoạt tính tiền
Checkbox	Tính tiền vượt thời gian quy định
Checkbox 	Tự động khóa thẻ sau 30 ngày không sử dụng
Bên dưới cùng nút	Lưu cài đặt Thiết bị
Bên trái nút 	Hướng dẫn cấu hình
GIÁ TIỀN	
Chưa có ý tưởng, để trống Form - Đang thu thập thông tin	
NÂNG CAO	
Chưa có ý tưởng, để trống Form - Đang thu thập thông tin	















