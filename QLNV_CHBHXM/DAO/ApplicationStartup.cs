using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.DAO
{
    // Computer\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run

    public static class ApplicationStartup
    {
        public static string APPLICATION_NAME = "QLNV_CHBHXM";

        public static void AddRegistry()
        {
            // Tạo mới hoặc mở thư mục chứa các đăng ký của các ứng dụng khởi động cùng máy tính
            RegistryKey regStart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                // Đăng ký ứng dụng khởi động cùng máy tính
                regStart.SetValue(APPLICATION_NAME, Application.ExecutablePath);
                //regStart.SetValue(APPLICATION_NAME, Application.StartupPath + "\\Calendar.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("Đăng ký ứng dụng khởi động cùng máy tính thất bại!!!",
                    "Error: Cannot Registry The App Startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng tiến trình ghi key
                if (regStart != null)
                {
                    regStart.Close();
                }
            }
        }

        public static void RemoveRegistry()
        {
            // Mở thư mục chứa các đăng ký của các ứng dụng khởi động cùng máy tính
            RegistryKey regStart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                // Xóa đăng ký ứng dụng khởi động cùng máy tính
                regStart.DeleteValue(APPLICATION_NAME);
            }
            catch (Exception)
            {
                // Không cần thông báo
            }
            finally
            {
                // Đóng tiến trình thay đổi key
                if (regStart != null)
                {
                    regStart.Close();
                }
            }
        }

        public static bool IsRegistered()
        {
            // Tạo mới hoặc mở thư mục chứa các đăng ký của các ứng dụng khởi động cùng máy tính
            RegistryKey regStart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                object obj = regStart.GetValue(APPLICATION_NAME);
                return obj != null;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                // Đóng tiến trình ghi key
                if (regStart != null)
                {
                    regStart.Close();
                }
            }
        }
    }
}
