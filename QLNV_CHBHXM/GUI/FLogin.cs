using QLNV_CHBHXM.DAO;
using QLNV_CHBHXM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNV_CHBHXM.GUI
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void ClearInfo()
        {
            txbUsername.Clear();
            txbPassword.Clear();
            ckbShowPassword.Checked = false;
        }

        // Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;

            string passEncode = Encoder.MD5Hash(Encoder.Base64Encode(password));

            TaiKhoan account = null;
            try
            {
                account = DataProvider.Instance.DB.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == username && t.MatKhau == passEncode);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy cơ sở dữ liệu! Chương trình sẽ kết thúc!",
                "Lỗi: Không tìm thấy tệp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

            if (account == null)
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu của bạn không chính xác!",
                "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVien employee = account.NhanVien;

            Hide();
            if (employee.LoaiNV.TenLoai == Constants.QUAN_LY)
            {
                FAdmin f = new FAdmin(account);
                f.ShowDialog();
            }
            else if (employee.LoaiNV.TenLoai == Constants.NHAN_VIEN)
            {
                FStaff f = new FStaff(account);
                f.ShowDialog();
            }
            Show();
        }

        // Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //Close();
        }

        private void FLogin_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                ClearInfo();
            }
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát khỏi ứng dụng không?",
                "Xác nhận rời khỏi", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txbPassword.UseSystemPasswordChar = !ckbShowPassword.Checked;
        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrEmpty(txbUsername.Text) && !string.IsNullOrEmpty(txbPassword.Text);
        }
    }
}
