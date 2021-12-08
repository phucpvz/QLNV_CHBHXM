
namespace QLNV_CHBHXM.GUI
{
    partial class FAddPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAddPrice));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbServiceID = new System.Windows.Forms.TextBox();
            this.dgrvServices = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbVehicleID = new System.Windows.Forms.TextBox();
            this.dgrvVehicles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.txbLikeVehicleName = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.txbLikeServiceName = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.cbPriceStatus = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvServices)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvVehicles)).BeginInit();
            this.panel45.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel46.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel53.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn một dịch vụ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbServiceID);
            this.panel1.Controls.Add(this.dgrvServices);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 296);
            this.panel1.TabIndex = 1;
            // 
            // txbServiceID
            // 
            this.txbServiceID.Location = new System.Drawing.Point(133, 5);
            this.txbServiceID.Margin = new System.Windows.Forms.Padding(2);
            this.txbServiceID.Name = "txbServiceID";
            this.txbServiceID.ReadOnly = true;
            this.txbServiceID.Size = new System.Drawing.Size(209, 20);
            this.txbServiceID.TabIndex = 7;
            this.txbServiceID.TextChanged += new System.EventHandler(this.txbFindVehicleID_TextChanged);
            // 
            // dgrvServices
            // 
            this.dgrvServices.AllowUserToAddRows = false;
            this.dgrvServices.AllowUserToDeleteRows = false;
            this.dgrvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvServices.Location = new System.Drawing.Point(9, 30);
            this.dgrvServices.MultiSelect = false;
            this.dgrvServices.Name = "dgrvServices";
            this.dgrvServices.ReadOnly = true;
            this.dgrvServices.RowHeadersWidth = 51;
            this.dgrvServices.Size = new System.Drawing.Size(487, 261);
            this.dgrvServices.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbVehicleID);
            this.panel2.Controls.Add(this.dgrvVehicles);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(514, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 296);
            this.panel2.TabIndex = 2;
            // 
            // txbVehicleID
            // 
            this.txbVehicleID.Location = new System.Drawing.Point(130, 5);
            this.txbVehicleID.Margin = new System.Windows.Forms.Padding(2);
            this.txbVehicleID.Name = "txbVehicleID";
            this.txbVehicleID.ReadOnly = true;
            this.txbVehicleID.Size = new System.Drawing.Size(209, 20);
            this.txbVehicleID.TabIndex = 7;
            this.txbVehicleID.TextChanged += new System.EventHandler(this.txbFindVehicleID_TextChanged);
            // 
            // dgrvVehicles
            // 
            this.dgrvVehicles.AllowUserToAddRows = false;
            this.dgrvVehicles.AllowUserToDeleteRows = false;
            this.dgrvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvVehicles.Location = new System.Drawing.Point(3, 30);
            this.dgrvVehicles.MultiSelect = false;
            this.dgrvVehicles.Name = "dgrvVehicles";
            this.dgrvVehicles.ReadOnly = true;
            this.dgrvVehicles.RowHeadersWidth = 51;
            this.dgrvVehicles.Size = new System.Drawing.Size(487, 261);
            this.dgrvVehicles.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn một loại xe";
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel45.Controls.Add(this.panel47);
            this.panel45.Controls.Add(this.label53);
            this.panel45.Controls.Add(this.panel46);
            this.panel45.Location = new System.Drawing.Point(12, 397);
            this.panel45.Margin = new System.Windows.Forms.Padding(4);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(998, 76);
            this.panel45.TabIndex = 27;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.txbLikeVehicleName);
            this.panel47.Controls.Add(this.label55);
            this.panel47.Location = new System.Drawing.Point(508, 32);
            this.panel47.Margin = new System.Windows.Forms.Padding(4);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(304, 35);
            this.panel47.TabIndex = 14;
            // 
            // txbLikeVehicleName
            // 
            this.txbLikeVehicleName.Location = new System.Drawing.Point(86, 6);
            this.txbLikeVehicleName.Margin = new System.Windows.Forms.Padding(2);
            this.txbLikeVehicleName.Name = "txbLikeVehicleName";
            this.txbLikeVehicleName.Size = new System.Drawing.Size(209, 20);
            this.txbLikeVehicleName.TabIndex = 7;
            this.txbLikeVehicleName.TextChanged += new System.EventHandler(this.txbFindVehicleName_TextChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(3, 9);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(62, 13);
            this.label55.TabIndex = 0;
            this.label55.Text = "Tên loại xe:";
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
            this.panel46.Controls.Add(this.txbLikeServiceName);
            this.panel46.Controls.Add(this.label54);
            this.panel46.Location = new System.Drawing.Point(14, 32);
            this.panel46.Margin = new System.Windows.Forms.Padding(4);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(308, 35);
            this.panel46.TabIndex = 13;
            // 
            // txbLikeServiceName
            // 
            this.txbLikeServiceName.Location = new System.Drawing.Point(86, 6);
            this.txbLikeServiceName.Margin = new System.Windows.Forms.Padding(2);
            this.txbLikeServiceName.Name = "txbLikeServiceName";
            this.txbLikeServiceName.Size = new System.Drawing.Size(209, 20);
            this.txbLikeServiceName.TabIndex = 7;
            this.txbLikeServiceName.TextChanged += new System.EventHandler(this.txbFindServiceName_TextChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(3, 9);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(67, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "Tên dịch vụ:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.panel44);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.panel53);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 315);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(998, 74);
            this.panel3.TabIndex = 28;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.cbPriceStatus);
            this.panel44.Controls.Add(this.label92);
            this.panel44.Location = new System.Drawing.Point(508, 29);
            this.panel44.Margin = new System.Windows.Forms.Padding(4);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(304, 38);
            this.panel44.TabIndex = 21;
            // 
            // cbPriceStatus
            // 
            this.cbPriceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriceStatus.FormattingEnabled = true;
            this.cbPriceStatus.Location = new System.Drawing.Point(86, 6);
            this.cbPriceStatus.Name = "cbPriceStatus";
            this.cbPriceStatus.Size = new System.Drawing.Size(209, 21);
            this.cbPriceStatus.TabIndex = 1;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(3, 9);
            this.label92.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(58, 13);
            this.label92.TabIndex = 0;
            this.label92.Text = "Trạng thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(505, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Chọn trạng thái";
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.label3);
            this.panel53.Controls.Add(this.nmrPrice);
            this.panel53.Controls.Add(this.label62);
            this.panel53.Location = new System.Drawing.Point(14, 29);
            this.panel53.Margin = new System.Windows.Forms.Padding(4);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(308, 38);
            this.panel53.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "VNĐ";
            // 
            // nmrPrice
            // 
            this.nmrPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmrPrice.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrPrice.Location = new System.Drawing.Point(85, 9);
            this.nmrPrice.Margin = new System.Windows.Forms.Padding(2);
            this.nmrPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmrPrice.Name = "nmrPrice";
            this.nmrPrice.Size = new System.Drawing.Size(159, 20);
            this.nmrPrice.TabIndex = 30;
            this.nmrPrice.ThousandsSeparator = true;
            this.nmrPrice.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(3, 11);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(47, 13);
            this.label62.TabIndex = 1;
            this.label62.Text = "Đơn giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Chọn giá trị đơn giá";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblError);
            this.panel8.Controls.Add(this.btnExit);
            this.panel8.Controls.Add(this.btnAccept);
            this.panel8.Location = new System.Drawing.Point(12, 480);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(998, 44);
            this.panel8.TabIndex = 29;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(160, 15);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(253, 13);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Phải có một dịch vụ và một loại xe để thêm đơn giá!";
            this.lblError.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::QLNV_CHBHXM.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(522, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 37);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(418, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(98, 37);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FAddPrice
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLNV_CHBHXM.Properties.Resources.download__8_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1024, 535);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel45);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAddPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm đơn giá mới";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvServices)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvVehicles)).EndInit();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            this.panel46.ResumeLayout(false);
            this.panel46.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel44.ResumeLayout(false);
            this.panel44.PerformLayout();
            this.panel53.ResumeLayout(false);
            this.panel53.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrvServices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrvVehicles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.TextBox txbLikeVehicleName;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.TextBox txbLikeServiceName;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbServiceID;
        private System.Windows.Forms.TextBox txbVehicleID;
        private System.Windows.Forms.Panel panel53;
        private System.Windows.Forms.NumericUpDown nmrPrice;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.ComboBox cbPriceStatus;
        private System.Windows.Forms.Label label92;
    }
}