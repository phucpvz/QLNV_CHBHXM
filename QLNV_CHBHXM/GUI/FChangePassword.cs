using MyControlLibrary;
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
    public partial class FChangePassword : Form
    {
        private TaiKhoan account;
        public TaiKhoan Account { get => account; set => account = value; }

        private Dictionary<Control, bool> flags;
        public Dictionary<Control, bool> Flags { get => flags; private set => flags = value; }

        public FChangePassword(TaiKhoan account)
        {
            InitializeComponent();
            Account = account;

            InitFlags();
        }

        private void InitFlags()
        {
            Flags = new Dictionary<Control, bool>()
            {
                {txbUsername, false },
                {txbPassword, false },
                {txbNewPass, false },
                {txbConfirmPass, false }
            };
        }

        private void Review()
        {
            btnAccept.Enabled = Flags.All(f => f.Value == true);
        }

        private void ShowMessage(Control control, Label lblError, string message = null)
        {
            if (control is MyTextBox)
            {
                MyTextBox txb = control as MyTextBox;
                // Nhập thông tin đúng
                if (message == null)
                {
                    Flags[txb] = true;
                    lblError.Text = message;
                    lblError.Visible = false;
                    txb.BorderColor = Color.GreenYellow;

                }
                // Nhập thông tin không hợp lệ
                else
                {
                    Flags[txb] = false;
                    lblError.Text = message;
                    lblError.Visible = true;
                    txb.BorderColor = Color.Red;
                }
            }
            else
            {
                // Nhập thông tin đúng
                if (message == null)
                {
                    Flags[control] = true;
                    lblError.Text = message;
                    lblError.Visible = false;
                }
                // Nhập thông tin không hợp lệ
                else
                {
                    Flags[control] = false;
                    lblError.Text = message;
                    lblError.Visible = true;
                }
            }

            Review();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void ChangePassword()
        {
            string username = txbUsername.Text;
            if (username != Account.TenDangNhap)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu cũ không chính xác!",
                "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = txbPassword.Text;
            string newPass = txbNewPass.Text;

            string passEncode = Encoder.MD5Hash(Encoder.Base64Encode(password));

            TaiKhoan account = null;
            try
            {
                account = DataProvider.Instance.DB.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == username && t.MatKhau == passEncode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kiểm tra thông tin tài khoản!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (account == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu cũ không chính xác!",
                "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn đổi mật khẩu mới?",
                   "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            try
            {
                account.MatKhau = Encoder.MD5Hash(Encoder.Base64Encode(newPass));
                DataProvider.Instance.DB.SaveChanges();

                MessageBox.Show("Đã đổi mật khẩu mới cho tài khoản thành công!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đổi mật khẩu cho tài khoản!\n\n",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CheckUsername()
        {
            string username = txbUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                ShowMessage(txbUsername, lblUsername, "Tên đăng nhập không được để trống!");
                return;
            }

            ShowMessage(txbUsername, lblUsername);
        }

        private void CheckPassword()
        {
            string password = txbPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                ShowMessage(txbPassword, lblPassword, "Mật khẩu cũ không được để trống!");
                return;
            }

            ShowMessage(txbPassword, lblPassword);
        }

        private void CheckNewPass()
        {
            string newPass = txbNewPass.Text;

            if (string.IsNullOrEmpty(newPass))
            {
                ShowMessage(txbNewPass, lblNewPass, "Mật khẩu mới không được để trống!");
                return;
            }

            ShowMessage(txbNewPass, lblNewPass);
        }

        private void CheckConfirmPass()
        {
            if (txbConfirmPass.Text != txbNewPass.Text)
            {
                ShowMessage(txbConfirmPass, lblConfirmPass, "Xác nhận mật khẩu mới không chính xác!");
                return;
            }

            ShowMessage(txbConfirmPass, lblConfirmPass);
        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            CheckUsername();
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void txbNewPass_TextChanged(object sender, EventArgs e)
        {
            CheckNewPass();
            CheckConfirmPass();
        }

        private void txbConfirmPass_TextChanged(object sender, EventArgs e)
        {
            CheckConfirmPass();
        }
    }
}
