
namespace QLNV_CHBHXM.GUI
{
    partial class FAddWork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAddWork));
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txbSearchVehicleName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txbSearchName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel47 = new System.Windows.Forms.Panel();
            this.txbSearchServiceName = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.txbSearchEmpID = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrvPrices = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgrvEmployees = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel53 = new System.Windows.Forms.Panel();
            this.nmrAmount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txbWorkID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbWorkDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txbPriceID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txbEmpID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel46.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvPrices)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvEmployees)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel53.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAmount)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnExit);
            this.panel8.Controls.Add(this.lblError);
            this.panel8.Controls.Add(this.btnAccept);
            this.panel8.Location = new System.Drawing.Point(12, 563);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(998, 54);
            this.panel8.TabIndex = 34;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::QLNV_CHBHXM.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(519, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 39);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(34, 16);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(379, 13);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Phải có một nhân viên và một đơn giá tương ứng để tạo một chi tiết công việc!";
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::QLNV_CHBHXM.Properties.Resources.ok;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(418, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(95, 39);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel45.Controls.Add(this.panel10);
            this.panel45.Controls.Add(this.panel9);
            this.panel45.Controls.Add(this.panel47);
            this.panel45.Controls.Add(this.label53);
            this.panel45.Controls.Add(this.panel46);
            this.panel45.Location = new System.Drawing.Point(12, 434);
            this.panel45.Margin = new System.Windows.Forms.Padding(4);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(998, 122);
            this.panel45.TabIndex = 32;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txbSearchVehicleName);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Location = new System.Drawing.Point(472, 75);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(385, 35);
            this.panel10.TabIndex = 15;
            // 
            // txbSearchVehicleName
            // 
            this.txbSearchVehicleName.Location = new System.Drawing.Point(86, 6);
            this.txbSearchVehicleName.Margin = new System.Windows.Forms.Padding(2);
            this.txbSearchVehicleName.Name = "txbSearchVehicleName";
            this.txbSearchVehicleName.Size = new System.Drawing.Size(209, 20);
            this.txbSearchVehicleName.TabIndex = 7;
            this.txbSearchVehicleName.TextChanged += new System.EventHandler(this.txbSearchServiceVehicleName_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tên loại xe:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txbSearchName);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Location = new System.Drawing.Point(14, 75);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(385, 35);
            this.panel9.TabIndex = 14;
            // 
            // txbSearchName
            // 
            this.txbSearchName.Location = new System.Drawing.Point(86, 6);
            this.txbSearchName.Margin = new System.Windows.Forms.Padding(2);
            this.txbSearchName.Name = "txbSearchName";
            this.txbSearchName.Size = new System.Drawing.Size(209, 20);
            this.txbSearchName.TabIndex = 7;
            this.txbSearchName.TextChanged += new System.EventHandler(this.txbSearchEmpIDName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tên nhân viên:";
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.txbSearchServiceName);
            this.panel47.Controls.Add(this.label55);
            this.panel47.Location = new System.Drawing.Point(472, 32);
            this.panel47.Margin = new System.Windows.Forms.Padding(4);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(385, 35);
            this.panel47.TabIndex = 14;
            // 
            // txbSearchServiceName
            // 
            this.txbSearchServiceName.Location = new System.Drawing.Point(86, 6);
            this.txbSearchServiceName.Margin = new System.Windows.Forms.Padding(2);
            this.txbSearchServiceName.Name = "txbSearchServiceName";
            this.txbSearchServiceName.Size = new System.Drawing.Size(209, 20);
            this.txbSearchServiceName.TabIndex = 7;
            this.txbSearchServiceName.TextChanged += new System.EventHandler(this.txbSearchServiceVehicleName_TextChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(3, 9);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(67, 13);
            this.label55.TabIndex = 0;
            this.label55.Text = "Tên dịch vụ:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(11, 9);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(71, 16);
            this.label53.TabIndex = 14;
            this.label53.Text = "Tìm kiếm";
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.txbSearchEmpID);
            this.panel46.Controls.Add(this.label54);
            this.panel46.Location = new System.Drawing.Point(14, 32);
            this.panel46.Margin = new System.Windows.Forms.Padding(4);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(385, 35);
            this.panel46.TabIndex = 13;
            // 
            // txbSearchEmpID
            // 
            this.txbSearchEmpID.Location = new System.Drawing.Point(86, 6);
            this.txbSearchEmpID.Margin = new System.Windows.Forms.Padding(2);
            this.txbSearchEmpID.Name = "txbSearchEmpID";
            this.txbSearchEmpID.Size = new System.Drawing.Size(209, 20);
            this.txbSearchEmpID.TabIndex = 7;
            this.txbSearchEmpID.TextChanged += new System.EventHandler(this.txbSearchEmpIDName_TextChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(3, 9);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(75, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "Mã nhân viên:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrvPrices);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(430, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 289);
            this.panel2.TabIndex = 31;
            // 
            // dgrvPrices
            // 
            this.dgrvPrices.AllowUserToAddRows = false;
            this.dgrvPrices.AllowUserToDeleteRows = false;
            this.dgrvPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvPrices.Location = new System.Drawing.Point(3, 25);
            this.dgrvPrices.MultiSelect = false;
            this.dgrvPrices.Name = "dgrvPrices";
            this.dgrvPrices.ReadOnly = true;
            this.dgrvPrices.RowHeadersWidth = 51;
            this.dgrvPrices.Size = new System.Drawing.Size(574, 261);
            this.dgrvPrices.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn một đơn giá ứng với nhân viên được chọn";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgrvEmployees);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 289);
            this.panel1.TabIndex = 30;
            // 
            // dgrvEmployees
            // 
            this.dgrvEmployees.AllowUserToAddRows = false;
            this.dgrvEmployees.AllowUserToDeleteRows = false;
            this.dgrvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvEmployees.Location = new System.Drawing.Point(6, 25);
            this.dgrvEmployees.MultiSelect = false;
            this.dgrvEmployees.Name = "dgrvEmployees";
            this.dgrvEmployees.ReadOnly = true;
            this.dgrvEmployees.RowHeadersWidth = 51;
            this.dgrvEmployees.Size = new System.Drawing.Size(404, 261);
            this.dgrvEmployees.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn một nhân viên";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel53);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(12, 308);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(998, 118);
            this.panel3.TabIndex = 35;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.nmrAmount);
            this.panel53.Controls.Add(this.label10);
            this.panel53.Controls.Add(this.label62);
            this.panel53.Location = new System.Drawing.Point(692, 32);
            this.panel53.Margin = new System.Windows.Forms.Padding(4);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(300, 78);
            this.panel53.TabIndex = 19;
            // 
            // nmrAmount
            // 
            this.nmrAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmrAmount.Location = new System.Drawing.Point(61, 9);
            this.nmrAmount.Margin = new System.Windows.Forms.Padding(2);
            this.nmrAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrAmount.Name = "nmrAmount";
            this.nmrAmount.Size = new System.Drawing.Size(209, 20);
            this.nmrAmount.TabIndex = 32;
            this.nmrAmount.ThousandsSeparator = true;
            this.nmrAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(4, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(270, 26);
            this.label10.TabIndex = 31;
            this.label10.Text = "(Cộng vào số lượng cũ nếu đã có chi tiết công việc này\r\n trước đó)";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(3, 11);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(52, 13);
            this.label62.TabIndex = 1;
            this.label62.Text = "Số lượng:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txbWorkID);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(326, 32);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(358, 35);
            this.panel6.TabIndex = 16;
            // 
            // txbWorkID
            // 
            this.txbWorkID.Location = new System.Drawing.Point(142, 6);
            this.txbWorkID.Margin = new System.Windows.Forms.Padding(2);
            this.txbWorkID.Name = "txbWorkID";
            this.txbWorkID.ReadOnly = true;
            this.txbWorkID.Size = new System.Drawing.Size(209, 20);
            this.txbWorkID.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã công việc (nếu đã có):";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbWorkDay);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(14, 75);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 35);
            this.panel4.TabIndex = 14;
            // 
            // txbWorkDay
            // 
            this.txbWorkDay.Location = new System.Drawing.Point(86, 6);
            this.txbWorkDay.Margin = new System.Windows.Forms.Padding(2);
            this.txbWorkDay.Name = "txbWorkDay";
            this.txbWorkDay.ReadOnly = true;
            this.txbWorkDay.Size = new System.Drawing.Size(209, 20);
            this.txbWorkDay.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày làm:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txbPriceID);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(326, 75);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(358, 35);
            this.panel7.TabIndex = 15;
            // 
            // txbPriceID
            // 
            this.txbPriceID.Location = new System.Drawing.Point(142, 6);
            this.txbPriceID.Margin = new System.Windows.Forms.Padding(2);
            this.txbPriceID.Name = "txbPriceID";
            this.txbPriceID.ReadOnly = true;
            this.txbPriceID.Size = new System.Drawing.Size(209, 20);
            this.txbPriceID.TabIndex = 7;
            this.txbPriceID.TextChanged += new System.EventHandler(this.txbPriceID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã đơn giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Thông tin";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txbEmpID);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(14, 32);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(304, 35);
            this.panel5.TabIndex = 13;
            // 
            // txbEmpID
            // 
            this.txbEmpID.Location = new System.Drawing.Point(86, 6);
            this.txbEmpID.Margin = new System.Windows.Forms.Padding(2);
            this.txbEmpID.Name = "txbEmpID";
            this.txbEmpID.ReadOnly = true;
            this.txbEmpID.Size = new System.Drawing.Size(209, 20);
            this.txbEmpID.TabIndex = 7;
            this.txbEmpID.TextChanged += new System.EventHandler(this.txbEmpID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã nhân viên:";
            // 
            // FAddWork
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLNV_CHBHXM.Properties.Resources.download__8_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1025, 627);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel45);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAddWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm chi tiết công việc";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            this.panel46.ResumeLayout(false);
            this.panel46.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvPrices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvEmployees)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel53.ResumeLayout(false);
            this.panel53.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrAmount)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.TextBox txbSearchServiceName;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.TextBox txbSearchEmpID;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrvPrices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrvEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txbSearchVehicleName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txbSearchName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel53;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txbWorkID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txbWorkDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txbPriceID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txbEmpID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nmrAmount;
        private System.Windows.Forms.Button btnExit;
    }
}