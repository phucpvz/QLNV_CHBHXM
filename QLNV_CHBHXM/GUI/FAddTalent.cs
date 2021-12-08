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
    public partial class FAddTalent : Form
    {
        private event EventHandler talentAdded;
        public event EventHandler TalentAdded
        {
            add { talentAdded += value; }
            remove { talentAdded -= value; }
        }

        private BindingSource employees;
        private BindingSource services;

        public FAddTalent()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            employees = new BindingSource();
            dgrvEmployees.DataSource = employees;
            services = new BindingSource();
            dgrvServices.DataSource = services;

            LoadEmployees();
            LoadServicesByEmployee();
            ChangeTitle(dgrvEmployees, Constants.EMP_HEADER);
            ChangeTitle(dgrvServices, Constants.SERVICE_HEADER);

            AddBinding();
        }

        private void AddBinding()
        {
            txbEmpID.DataBindings.Add(new Binding("Text", dgrvEmployees.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txbServiceID.DataBindings.Add(new Binding("Text", dgrvServices.DataSource, "MaDV", true, DataSourceUpdateMode.Never));
        }

        private void LoadEmployees()
        {
            string empID = txbFindEmpID_Talent.Text;
            string name = txbFindName_Talent.Text;

            try
            {
                employees.DataSource = DataProvider.Instance.DB.USP_TimKiemNhanVienRutGon(empID, name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm nhân viên!",
                    "Lỗi: " + ex.GetType(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServicesByEmployee()
        {
            /* 
              * Tìm kiếm dịch vụ chưa phân công cho nhân viên
              */
            string empID = txbEmpID.Text;
            string serviceName = txbFindSerName_Talent.Text;

            try
            {
                services.DataSource = DataProvider.Instance.DB.USP_TimKiemDichVuChuaPhanCong(empID, serviceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm dịch vụ chưa phân công cho nhân viên!",
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

        private void CheckAddTalentIDs()
        {
            btnAccept.Enabled = !string.IsNullOrEmpty(txbEmpID.Text) && !string.IsNullOrEmpty(txbServiceID.Text);
            lblError.Visible = !btnAccept.Enabled;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AddTalent();
        }

        private void AddTalent()
        {
            string empID = txbEmpID.Text;
            int serviceID = Convert.ToInt32(txbServiceID.Text);

            try
            {
                NhanVien employee = DataProvider.Instance.DB.NhanViens.Find(empID);
                DichVu service = DataProvider.Instance.DB.DichVus.Find(serviceID);
                employee.DichVus.Add(service);
                DataProvider.Instance.DB.SaveChanges();

                OnTalentAdded();
                LoadServicesByEmployee();
                MessageBox.Show("Đã thêm năng lực!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm năng lực!\n\n",
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

        private void txbEmpID_TextChanged(object sender, EventArgs e)
        {
            LoadServicesByEmployee();
            CheckAddTalentIDs();
        }

        private void txbServiceID_TextChanged(object sender, EventArgs e)
        {
            CheckAddTalentIDs();
        }

        private void txbFindEmpID_Talent_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void txbFindSerName_Talent_TextChanged(object sender, EventArgs e)
        {
            LoadServicesByEmployee();
        }
    }
}
