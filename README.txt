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
















