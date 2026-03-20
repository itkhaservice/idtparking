using System;
using System.IO;
using System.Xml.Serialization;

namespace IDTSERVER
{
    public class AppSettings
    {
        // Tab 1 - Hệ thống
        public string PrimaryServer { get; set; } = "192.168.100.81";
        public string BackupServer { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "1433";
        public string Username { get; set; } = "sa";
        public string Password { get; set; } = "123ABC";
        public string DatabaseName { get; set; } = "GIUXE";
        public string LocalPath { get; set; } = @"C:\IDTParking\Data";
        public string URLServer { get; set; } = "http://192.168.100.81:8080";
        public string BackupPath { get; set; } = @"D:\IDTParking\Backup";

        // Cấu hình số làn
        public int LaneCount { get; set; } = 2; // Mặc định 2 làn

        // Tab 2 - Cấu hình Làn & COM
        public int Lane1Direction { get; set; } = 0; // 0: Vào, 1: Ra, 2: Đảo chiều
        public int Lane2Direction { get; set; } = 1; // 0: Vào, 1: Ra, 2: Đảo chiều
        public string Lane1ComPort { get; set; } = "COM1";
        public string Lane2ComPort { get; set; } = "COM2";

        // Tab 2 - Camera General
        public int CameraType { get; set; } = 0; // 0: Analog, 1: IP

        // Analog Settings (Kênh trên đầu ghi)
        public string DvrHost { get; set; } = "192.168.100.99";
        public int DvrPort { get; set; } = 8888;
        public string DvrUser { get; set; } = "admin";
        public string DvrPass { get; set; } = "idt123321";
        public int ChLane1Plate { get; set; } = 1; // Làn 1 - Sau (Biển số)
        public int ChLane1Front { get; set; } = 2; // Làn 1 - Trước (Toàn cảnh)
        public int ChLane2Plate { get; set; } = 3; // Làn 2 - Sau (Biển số)
        public int ChLane2Front { get; set; } = 4; // Làn 2 - Trước (Toàn cảnh)

        // IP Camera Settings (RTSP)
        // Làn 1
        public string IpCamL1PlateHost { get; set; } = "192.168.1.101";
        public string IpCamL1PlateUser { get; set; } = "admin";
        public string IpCamL1PlatePass { get; set; } = "admin123";
        public string IpCamL1PlateRTSP { get; set; } = "/Streaming/Channels/101";

        public string IpCamL1FrontHost { get; set; } = "192.168.1.102";
        public string IpCamL1FrontUser { get; set; } = "admin";
        public string IpCamL1FrontPass { get; set; } = "admin123";
        public string IpCamL1FrontRTSP { get; set; } = "/Streaming/Channels/101";

        // Làn 2
        public string IpCamL2PlateHost { get; set; } = "192.168.1.103";
        public string IpCamL2PlateUser { get; set; } = "admin";
        public string IpCamL2PlatePass { get; set; } = "admin123";
        public string IpCamL2PlateRTSP { get; set; } = "/Streaming/Channels/101";

        public string IpCamL2FrontHost { get; set; } = "192.168.1.104";
        public string IpCamL2FrontUser { get; set; } = "admin";
        public string IpCamL2FrontPass { get; set; } = "admin123";
        public string IpCamL2FrontRTSP { get; set; } = "/Streaming/Channels/101";

        // Tab 1 - Options
        public bool FastScan { get; set; } = true;
        public bool SyncData { get; set; } = false;
        public bool AutoReconnect { get; set; } = true;
        public bool AutoPrint { get; set; } = false;
        public bool OnlineImage { get; set; } = true;
        public bool ShowCamerasOnMain { get; set; } = false;
        public bool ShowRevenue { get; set; } = true;
        public bool VoiceMoney { get; set; } = true;
        public bool VoiceWarning { get; set; } = true;

        private static string GetConfigPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
        }

        public void Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                using (StreamWriter writer = new StreamWriter(GetConfigPath()))
                {
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi lưu cấu hình: " + ex.Message);
            }
        }

        public static AppSettings Load()
        {
            string path = GetConfigPath();
            if (!File.Exists(path)) return new AppSettings();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                using (StreamReader reader = new StreamReader(path))
                {
                    return (AppSettings)serializer.Deserialize(reader);
                }
            }
            catch
            {
                return new AppSettings();
            }
        }

        public string GetConnectionString(bool useBackup = false)
        {
            string server = useBackup ? BackupServer : PrimaryServer;
            return $"Server={server},{Port};Database={DatabaseName};User ID={Username};Password={Password};Connect Timeout=10;TrustServerCertificate=True;";
        }
    }
}
