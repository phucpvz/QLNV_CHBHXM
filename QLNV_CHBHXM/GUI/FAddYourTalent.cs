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
    public partial class FAddYourTalent : Form
    {
        private TaiKhoan account;
        public TaiKhoan Account { get => account; set => account = value; }

        private event EventHandler talentAdded;
        public event EventHandler TalentAdded
        {
            add { talentAdded += value; }
            remove { talentAdded -= value; }
        }

        private BindingSource services;

        public FAddYourTalent(TaiKhoan account)
        {
            InitializeComponent();
            Account = account;
            LoadData();
        }

        private void LoadData()
        {
            services = new BindingSource();
            dgrvServices.DataSource = services;

            LoadServicesByEmployee();
            ChangeTitle(dgrvServices, Constants.SERVICE_HEADER);

            AddBinding();
        }

        private void AddBinding()
        {
            txbServiceID.DataBindings.Add(new Binding("Text", dgrvServices.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
        }

        private void LoadServicesByEmployee()
        {
            /* 
            * Tìm kiếm dịch vụ chưa phân công cho bạn
            */
            string empID = Account.MaNV;
            string serviceName = txbFindSerName_Talent.Text;

            try
            {
                services.DataSource = DataProvider.Instance.DB.USP_TimKiemDichVuChuaPhanCong(empID, serviceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm dịch vụ chưa phân công cho bạn!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeTitle(DataGridView dgrv, string[] headers)
        {
            int columnCount = headers.Length;
            for (int i = 0; i < columnCount; i++)
            {
                dgrv.Columns[i].HeaderText = headers[i];
            }
        }

        private void CheckAddYourTalentIDs()
        {
            btnAccept.Enabled = !string.IsNullOrEmpty(txbServiceID.Text);
            lblError.Visible = !btnAccept.Enabled;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AddTalent();
        }

        private void AddTalent()
        {
            int serviceID = Convert.ToInt32(txbServiceID.Text);

            try
            {
                NhanVien employee = Account.NhanVien;
                DichVu service = DataProvider.Instance.DB.DichVus.Find(serviceID);
                employee.DichVus.Add(service);
                DataProvider.Instance.DB.SaveChanges();

                OnTalentAdded();
                LoadServicesByEmployee();
                MessageBox.Show("Đã thêm năng lực mới của bạn!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm năng lực mới của bạn!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnTalentAdded()
        {
            if (talentAdded != null)
            {
                talentAdded(this, new EventArgs());
            }
        }

        private void txbServiceID_TextChanged(object sender, EventArgs e)
        {
            CheckAddYourTalentIDs();
        }

        private void txbFindSerName_Talent_TextChanged(object sender, EventArgs e)
        {
            LoadServicesByEmployee();
        }
    }
}
