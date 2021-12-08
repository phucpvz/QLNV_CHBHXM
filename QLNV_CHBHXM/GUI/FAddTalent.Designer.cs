
namespace QLNV_CHBHXM.GUI
{
    partial class FAddTalent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAddTalent));
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.txbFindEmpID_Talent = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.txbFindSerName_Talent = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.txbFindName_Talent = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbServiceID = new System.Windows.Forms.TextBox();
            this.dgrvServices = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbEmpID = new System.Windows.Forms.TextBox();
            this.dgrvEmployees = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvServices)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblError);
            this.panel8.Controls.Add(this.btnExit);
            this.panel8.Controls.Add(this.btnAccept);
            this.panel8.Location = new System.Drawing.Point(12, 439);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1075, 41);
            this.panel8.TabIndex = 34;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(124, 14);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(275, 13);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Phải có một nhân viên và một dịch vụ để thêm năng lực!";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(541, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Image = global::QLNV_CHBHXM.Properties.Resources.thumb_up;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(418, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(117, 34);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel45.Controls.Add(this.panel36);
            this.panel45.Controls.Add(this.panel24);
            this.panel45.Controls.Add(this.panel31);
            this.panel45.Controls.Add(this.label53);
            this.panel45.Location = new System.Drawing.Point(12, 317);
            this.panel45.Margin = new System.Windows.Forms.Padding(4);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(1075, 115);
            this.panel45.TabIndex = 32;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.txbFindEmpID_Talent);
            this.panel36.Controls.Add(this.label47);
            this.panel36.Location = new System.Drawing.Point(14, 29);
            this.panel36.Margin = new System.Windows.Forms.Padding(4);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(385, 35);
            this.panel36.TabIndex = 18;
            // 
            // txbFindEmpID_Talent
            // 
            this.txbFindEmpID_Talent.Location = new System.Drawing.Point(86, 6);
            this.txbFindEmpID_Talent.Margin = new System.Windows.Forms.Padding(2);
            this.txbFindEmpID_Talent.Name = "txbFindEmpID_Talent";
            this.txbFindEmpID_Talent.Size = new System.Drawing.Size(209, 20);
            this.txbFindEmpID_Talent.TabIndex = 7;
            this.txbFindEmpID_Talent.TextChanged += new System.EventHandler(this.txbFindEmpID_Talent_TextChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(3, 9);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(75, 13);
            this.label47.TabIndex = 0;
            this.label47.Text = "Mã nhân viên:";
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.txbFindSerName_Talent);
            this.panel24.Controls.Add(this.label41);
            this.panel24.Location = new System.Drawing.Point(508, 72);
            this.panel24.Margin = new System.Windows.Forms.Padding(4);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(385, 35);
            this.panel24.TabIndex = 17;
            // 
            // txbFindSerName_Talent
            // 
            this.txbFindSerName_Talent.Location = new System.Drawing.Point(86, 6);
            this.txbFindSerName_Talent.Margin = new System.Windows.Forms.Padding(2);
            this.txbFindSerName_Talent.Name = "txbFindSerName_Talent";
            this.txbFindSerName_Talent.Size = new System.Drawing.Size(209, 20);
            this.txbFindSerName_Talent.TabIndex = 7;
            this.txbFindSerName_Talent.TextChanged += new System.EventHandler(this.txbFindSerName_Talent_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 9);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(67, 13);
            this.label41.TabIndex = 0;
            this.label41.Text = "Tên dịch vụ:";
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.txbFindName_Talent);
            this.panel31.Controls.Add(this.label43);
            this.panel31.Location = new System.Drawing.Point(14, 72);
            this.panel31.Margin = new System.Windows.Forms.Padding(4);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(385, 35);
            this.panel31.TabIndex = 16;
            // 
            // txbFindName_Talent
            // 
            this.txbFindName_Talent.Location = new System.Drawing.Point(86, 6);
            this.txbFindName_Talent.Margin = new System.Windows.Forms.Padding(2);
            this.txbFindName_Talent.Name = "txbFindName_Talent";
            this.txbFindName_Talent.Size = new System.Drawing.Size(209, 20);
            this.txbFindName_Talent.TabIndex = 7;
            this.txbFindName_Talent.TextChanged += new System.EventHandler(this.txbFindEmpID_Talent_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(3, 9);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(57, 13);
            this.label43.TabIndex = 0;
            this.label43.Text = "Họ và tên:";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.txbServiceID);
            this.panel2.Controls.Add(this.dgrvServices);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(514, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 298);
            this.panel2.TabIndex = 31;
            // 
            // txbServiceID
            // 
            this.txbServiceID.Location = new System.Drawing.Point(442, 5);
            this.txbServiceID.Margin = new System.Windows.Forms.Padding(2);
            this.txbServiceID.Name = "txbServiceID";
            this.txbServiceID.ReadOnly = true;
            this.txbServiceID.Size = new System.Drawing.Size(118, 20);
            this.txbServiceID.TabIndex = 9;
            this.txbServiceID.TextChanged += new System.EventHandler(this.txbServiceID_TextChanged);
            // 
            // dgrvServices
            // 
            this.dgrvServices.AllowUserToAddRows = false;
            this.dgrvServices.AllowUserToDeleteRows = false;
            this.dgrvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvServices.Location = new System.Drawing.Point(6, 30);
            this.dgrvServices.MultiSelect = false;
            this.dgrvServices.Name = "dgrvServices";
            this.dgrvServices.ReadOnly = true;
            this.dgrvServices.RowHeadersWidth = 51;
            this.dgrvServices.Size = new System.Drawing.Size(554, 261);
            this.dgrvServices.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(437, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn một dịch vụ chưa được phân công của nhân viên đã chọn";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbEmpID);
            this.panel1.Controls.Add(this.dgrvEmployees);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 298);
            this.panel1.TabIndex = 30;
            // 
            // txbEmpID
            // 
            this.txbEmpID.Location = new System.Drawing.Point(150, 5);
            this.txbEmpID.Margin = new System.Windows.Forms.Padding(2);
            this.txbEmpID.Name = "txbEmpID";
            this.txbEmpID.ReadOnly = true;
            this.txbEmpID.Size = new System.Drawing.Size(209, 20);
            this.txbEmpID.TabIndex = 8;
            this.txbEmpID.TextChanged += new System.EventHandler(this.txbEmpID_TextChanged);
            // 
            // dgrvEmployees
            // 
            this.dgrvEmployees.AllowUserToAddRows = false;
            this.dgrvEmployees.AllowUserToDeleteRows = false;
            this.dgrvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvEmployees.Location = new System.Drawing.Point(3, 30);
            this.dgrvEmployees.MultiSelect = false;
            this.dgrvEmployees.Name = "dgrvEmployees";
            this.dgrvEmployees.ReadOnly = true;
            this.dgrvEmployees.RowHeadersWidth = 51;
            this.dgrvEmployees.Size = new System.Drawing.Size(487, 261);
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
            // FAddTalent
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLNV_CHBHXM.Properties.Resources.download__8_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1102, 501);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel45);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAddTalent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm năng lực";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvServices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrvServices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrvEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.TextBox txbFindEmpID_Talent;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TextBox txbFindSerName_Talent;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.TextBox txbFindName_Talent;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txbEmpID;
        private System.Windows.Forms.TextBox txbServiceID;
    }
}