
namespace QLNV_CHBHXM.GUI
{
    partial class FAddYourTalent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAddYourTalent));
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.txbFindSerName_Talent = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbServiceID = new System.Windows.Forms.TextBox();
            this.dgrvServices = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblError);
            this.panel8.Controls.Add(this.btnExit);
            this.panel8.Controls.Add(this.btnAccept);
            this.panel8.Location = new System.Drawing.Point(10, 400);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(369, 88);
            this.panel8.TabIndex = 37;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(17, 14);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(229, 13);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Phải có một dịch vụ được chọn để phân công!";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::QLNV_CHBHXM.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(251, 46);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 38);
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
            this.btnAccept.Location = new System.Drawing.Point(251, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(109, 38);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel45
            // 
            this.panel45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel45.Controls.Add(this.panel24);
            this.panel45.Controls.Add(this.label53);
            this.panel45.Location = new System.Drawing.Point(10, 317);
            this.panel45.Margin = new System.Windows.Forms.Padding(4);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(369, 76);
            this.panel45.TabIndex = 36;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.txbFindSerName_Talent);
            this.panel24.Controls.Add(this.label41);
            this.panel24.Location = new System.Drawing.Point(14, 29);
            this.panel24.Margin = new System.Windows.Forms.Padding(4);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(307, 35);
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
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 298);
            this.panel2.TabIndex = 35;
            // 
            // txbServiceID
            // 
            this.txbServiceID.Location = new System.Drawing.Point(336, 5);
            this.txbServiceID.Margin = new System.Windows.Forms.Padding(2);
            this.txbServiceID.Name = "txbServiceID";
            this.txbServiceID.ReadOnly = true;
            this.txbServiceID.Size = new System.Drawing.Size(120, 20);
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
            this.label2.Location = new System.Drawing.Point(20, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn một dịch vụ bạn muốn được phân công";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::QLNV_CHBHXM.Properties.Resources.download__6_;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(415, 317);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 167);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // FAddYourTalent
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(602, 514);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel45);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAddYourTalent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm năng lực của bạn";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TextBox txbFindSerName_Talent;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbServiceID;
        private System.Windows.Forms.DataGridView dgrvServices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}