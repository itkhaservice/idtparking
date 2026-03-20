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
========================================================================================
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

========================================================================================
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
========================================================================================
npx @google/gemini-cli
========================================================================================


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
========================================================================================
Cấu hình Thiết bị Camera
Chọn loại camera Analog: OK
Chọn loại camera IP: Phải đủ 4 camera ( Ra (Trước - Sau) và Vào (Trước - Sau)
Chưa thấy chọn cấu hình Làn cho hệ thống
Chưa thấy chọn cấu hình các Cổng COM

Tôi sẽ cung cấp thông tin Đầu ghi
Địa chỉ IP: 192.168.100.99
Port: 8888
Username: admin
Password: idt123321
========================================================================================
Giải thích các phần trên FrmMain.cs
Đầu tiên
KHA - PARKING giới thiệu tên phần mềm
Bên trái nó là thông tin thời gian hiện tại. Doanh thu của ca đăng nhập. Bao nhiêu lượt ra. Bao nhiêu lượt vào.
Bên dưới được chia ra làm 2 làn xe
Đối với làn bên trái - được cho làn ra của hệ thống
Có 2 camera live lần lượt là Camera Toàn cảnh và Camera Biển số
Bên dưới là thông tin đăng nhập của Bảo vệ
Bên dưới nữa được chia ra làm 2 phần
Phần 1 là phần thông tin thẻ vượt quẹt, bao gồm
Số thẻ | Loại thẻ | TG lưu bãi
Chủ thẻ | BS
Đăng ký thẻ
Vào | Ra
Thanh toán (áp dụng cho xe vãng lai)
Phần 2 là phần AI nhận diện biển số, nếu làn ra sẽ có cả 2 hình biển số lúc vào - ra, AI đọc và so sánh
Bên dưới tiếp theo là 2 khung ảnh Camera Snapshot, chụp lại lúc quẹt thẻ vào hệ thống
Cuối cùng là phần thông báo sau khi quẹt thẻ
Bên phải thì tương tự, nó được cho là làn vào của hệ thống, làn vào thì thẻ đó chỉ có 1 hình biển số nên AI không thể so sánh được
Ghi chú: Nếu là thẻ đăng ký tháng, khi quẹt vào sẽ có các thông tin mặc định như Số thẻ, Loại thẻ, Chủ thẻ, Biển số, Đăng ký thẻ (Tức bao gồm ngày đăng ký và ngày hết hạn của thẻ), Vào (Thời gian vào của lượt mới nhất), Ra (Thời gian ra lượt mới nhất) và thanh toán 0 vnđ
========================================================================================
Đây là danh sách toàn bộ các tên thành phần (Name) bạn cần đặt cho các Toolbox trên giao diện FormMain để khớp hoàn
  toàn với logic xử lý 2 làn (Trái-Ra, Phải-Vào) mà chúng ta đã thống nhất.

  1. Nhóm Tiêu đề & Thống kê (Phía trên cùng)
   * Tên phần mềm (KHA - PARKING): lblSoftwareName
   * Đồng hồ hiển thị thời gian: lblCurrentTime
   * Doanh thu ca hiện tại: lblRevenue
   * Tổng số lượt xe vào: lblEntryCount
   * Tổng số lượt xe ra: lblExitCount

  ---

  2. Làn 1: Bên Trái (Làn RA)
  Khu vực Camera Live:
   * Camera Toàn cảnh: pbCamL1Panorama
   * Camera Biển số: pbCamL1Plate

  Thông tin Bảo vệ:
   * Tên bảo vệ trực làn: lblGuardL1

  Bảng thông tin thẻ (UserControl gateL1 - Xem chi tiết mục 4 bên dưới):
   * Tên Control tổng: gateL1

  Khu vực AI Nhận diện (So sánh):
   * Ảnh biển số lúc VÀO (đối soát): pbAIL1In
   * Ảnh biển số lúc RA (hiện tại): pbAIL1Out
   * Kết quả biển số lúc VÀO (đối soát): lblAIPlateInL1
   * Kết quả biển số lúc RA (hiện tại): lblAIPlateOutL1
   * Kết quả so sánh AI (Text): lblAIResultL1

  Khu vực Ảnh Snapshot (Chụp lúc quẹt thẻ):
   * Ảnh Snapshot 1: pbSnapL1_1
   * Ảnh Snapshot 2: pbSnapL1_2

  Thông báo:
   * Dòng thông báo sau quẹt thẻ: lblNotifyL1

  ---

  3. Làn 2: Bên Phải (Làn VÀO)
  Khu vực Camera Live:
   * Camera Toàn cảnh: pbCamL2Panorama
   * Camera Biển số: pbCamL2Plate

  Thông tin Bảo vệ:
   * Tên bảo vệ trực làn: lblGuardL2

  Bảng thông tin thẻ (UserControl gateL2):
   * Tên Control tổng: gateL2

  Khu vực AI Nhận diện (Làn vào chỉ có 1 ảnh):
   * Ảnh biển số lúc VÀO (đối soát): pbAIL2In
   * Ảnh biển số lúc RA (hiện tại): pbAIL2Out
   * Kết quả biển số lúc VÀO (đối soát): lblAIPlateInL2
   * Kết quả biển số lúc RA (hiện tại): lblAIPlateOutL2
   * Kết quả so sánh AI (Text): lblAIResultL2

  Khu vực Ảnh Snapshot (Chụp lúc quẹt thẻ):
   * Ảnh Snapshot 1: pbSnapL2_1
   * Ảnh Snapshot 2: pbSnapL2_2

  Thông báo:
   * Dòng thông báo sau quẹt thẻ: lblNotifyL2

  ---

  4. Chi tiết các Label bên trong Bảng thông tin thẻ
  Nếu bạn dùng UserControl ParkingGateSection, bạn hãy mở file Designer của nó và đặt tên cho các nhãn bên trong. Code
  sẽ gọi thông qua gateL1.lblCardID,...:
Áp dụng cho Làn 1 từ trái qua
   * Số thẻ: lblCardID1
   * Loại thẻ: lblCardType1
   * Thời gian lưu bãi: lblStayDuration1
   * Chủ thẻ (Tên khách hàng): lblOwner1
   * Biển số (BS đăng ký): lblPlate1
   * Đăng ký thẻ (Ngày BD - KT): lblRegistration1
   * Thời điểm VÀO: lblTimeIn1
   * Thời điểm RA: lblTimeOut1
   * Thanh toán (Phí): lblAmount1

Áp dụng cho Làn 2 từ trái qua
   * Số thẻ: lblCardID2
   * Loại thẻ: lblCardType2
   * Thời gian lưu bãi: lblStayDuration2
   * Chủ thẻ (Tên khách hàng): lblOwner2
   * Biển số (BS đăng ký): lblPlate2
   * Đăng ký thẻ (Ngày BD - KT): lblRegistration2
   * Thời điểm VÀO: lblTimeIn2
   * Thời điểm RA: lblTimeOut2
   * Thanh toán (Phí): lblAmount2
  ---

  Một số lưu ý quan trọng:
   1. Thuộc tính SizeMode: Tất cả các PictureBox (pb...) nên đặt là Zoom để ảnh không bị méo.
   2. Docking: Các thành phần bên trong TableLayoutPanel nên đặt Dock = Fill.
   3. Lưu ý về Làn vào: Đối với thẻ tháng quẹt vào làn Phải, Code sẽ tự động đổ dữ liệu mặc định vào lblOwner, lblPlate,
      và lblRegistration.
   4. Cả 2 bên được thiết kế tương đồng nhau, đối xứng để đáp ứng IT setup cho bên trái là Làn ra/hoặc Vào nếu thích. (Lúc đó thông tin nào có sẽ tự hiển thị, không có mặc đinh trống)
   5. Khu vực Ảnh Snapshot và Camera Live phải đều nhau để bảo vệ có thể xem ảnh rõ hơn, khu vực ảnh AI sẽ có tỉ lệ tương đương 2 khu vực kia nhưng nhỏ hơn.
	













