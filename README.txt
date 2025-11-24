Đến hiện tại tôi đã hoàn thành xong phần mềm dành cho Ban quản lý tòa nhà quản lý dữ liệu hệ thống xe. Bây giờ tôi sẽ lên ý tưởng để viết chương trình cài đặt tại máy tính bãi xe để kiểm soát xe ra vào.

Phần mềm này sẽ chung Solution, nhưng sẽ build cho máy server tên là IDTSERVER. Máy tính này sẽ kết nối với đầu đọc thẻ từ, barier, camera.

Nhưng tôi sẽ thiết kế để phù hợp cho nhiều nhu cầu khác nhau như
- Hệ thống gồm 1 máy kiểm soát ra và vào chỉ dành cho xe máy (Tổng cộng 2 đầu đọc thẻ - 4 camera - 2 barrier)
- Hệ thống gồm 1 máy kiểm soát ra và 1 máy kiểm soát vào chỉ dành cho xe máy  (Tổng cộng 4 đầu đọc thẻ - 8 camera - 4 barrier)
- Hệ thống gồm 1 máy kiểm soát ra và vào dành cho xe máy và ô tô (Tổng cộng 3 đầu đọc thẻ - 6 camera - 3 barrier hoặc 2 đầu đọc thẻ - 4 camera - 2 barier)
- Hệ thống gồm 1 máy kiểm soát ra và 1 máy kiểm soát vào dành cho xe máy và ô tô (Tổng cộng 6 đầu đọc thẻ - 12 camera - 4 barrier hoặc 4 đầu đọc thẻ - 8 camera - 4 barrier hoặc)

Hệ thống có thể set camera dạng IP hoặc analog từ đầu ghi. Có các remote để mở/dừng/đóng cần barier. Phần mềm cũng có chức năng kích mở barier, ở mỗi barier đều có mắt cảm biến hạ cần khi xe đi qua, dừng cần khi xe chưa qua hết. Phần mềm có thể tinh chỉnh số cổng COM, USB để kết nối đến các thiết bị ngoại vi hỗ trợ hệ thống như camera, đầu đọc.  

Phần mềm có thể co giãn ở nhiều kích thước màn hình khác nhau như 19, 21, 22, 24, 27. Màn hình hiển thị sẽ gồm các ô camera, vùng để thể hiện thông tin thể vãng lai, thẻ tháng, số tiền, thời gian ra và thời gian vào.