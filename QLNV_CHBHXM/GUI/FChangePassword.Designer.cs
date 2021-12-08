
namespace QLNV_CHBHXM.GUI
{
    partial class FChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FChangePassword));
            this.panel75 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txbConfirmPass = new MyControlLibrary.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txbNewPass = new MyControlLibrary.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel82 = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbPassword = new MyControlLibrary.MyTextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txbUsername = new MyControlLibrary.MyTextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel75.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel83.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.panel2);
            this.panel75.Controls.Add(this.panel1);
            this.panel75.Controls.Add(this.panel82);
            this.panel75.Controls.Add(this.panel83);
            this.panel75.Location = new System.Drawing.Point(13, 13);
            this.panel75.Margin = new System.Windows.Forms.Padding(4);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(365, 280);
            this.panel75.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblConfirmPass);
            this.panel2.Controls.Add(this.txbConfirmPass);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(4, 215);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 60);
            this.panel2.TabIndex = 25;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPass.Location = new System.Drawing.Point(125, 29);
            this.lblConfirmPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(75, 13);
            this.lblConfirmPass.TabIndex = 6;
            this.lblConfirmPass.Text = "lblConfirmPass";
            this.lblConfirmPass.Visible = false;
            // 
            // txbConfirmPass
            // 
            this.txbConfirmPass.BorderColor = System.Drawing.Color.Black;
            this.txbConfirmPass.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txbConfirmPass.Location = new System.Drawing.Point(125, 6);
            this.txbConfirmPass.Name = "txbConfirmPass";
            this.txbConfirmPass.Size = new System.Drawing.Size(215, 20);
            this.txbConfirmPass.TabIndex = 5;
            this.txbConfirmPass.UseSystemPasswordChar = true;
            this.txbConfirmPass.TextChanged += new System.EventHandler(this.txbConfirmPass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNewPass);
            this.panel1.Controls.Add(this.txbNewPass);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 147);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 60);
            this.panel1.TabIndex = 24;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.ForeColor = System.Drawing.Color.Red;
            this.lblNewPass.Location = new System.Drawing.Point(125, 29);
            this.lblNewPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(62, 13);
            this.lblNewPass.TabIndex = 6;
            this.lblNewPass.Text = "lblNewPass";
            this.lblNewPass.Visible = false;
            // 
            // txbNewPass
            // 
            this.txbNewPass.BorderColor = System.Drawing.Color.Black;
            this.txbNewPass.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txbNewPass.Location = new System.Drawing.Point(125, 6);
            this.txbNewPass.Name = "txbNewPass";
            this.txbNewPass.Size = new System.Drawing.Size(215, 20);
            this.txbNewPass.TabIndex = 5;
            this.txbNewPass.UseSystemPasswordChar = true;
            this.txbNewPass.TextChanged += new System.EventHandler(this.txbNewPass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.lblPassword);
            this.panel82.Controls.Add(this.txbPassword);
            this.panel82.Controls.Add(this.label91);
            this.panel82.Location = new System.Drawing.Point(4, 79);
            this.panel82.Margin = new System.Windows.Forms.Padding(4);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(355, 60);
            this.panel82.TabIndex = 23;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.Red;
            this.lblPassword.Location = new System.Drawing.Point(125, 29);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "lblPassword";
            this.lblPassword.Visible = false;
            // 
            // txbPassword
            // 
            this.txbPassword.BorderColor = System.Drawing.Color.Black;
            this.txbPassword.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txbPassword.Location = new System.Drawing.Point(125, 6);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(215, 20);
            this.txbPassword.TabIndex = 5;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(3, 9);
            this.label91.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(70, 13);
            this.label91.TabIndex = 0;
            this.label91.Text = "Mật khẩu cũ:";
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.lblUsername);
            this.panel83.Controls.Add(this.txbUsername);
            this.panel83.Controls.Add(this.label92);
            this.panel83.Location = new System.Drawing.Point(4, 4);
            this.panel83.Margin = new System.Windows.Forms.Padding(4);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(355, 67);
            this.panel83.TabIndex = 22;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.Red;
            this.lblUsername.Location = new System.Drawing.Point(125, 29);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "lblUsername";
            this.lblUsername.Visible = false;
            // 
            // txbUsername
            // 
            this.txbUsername.BorderColor = System.Drawing.Color.Black;
            this.txbUsername.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txbUsername.Location = new System.Drawing.Point(125, 6);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(215, 20);
            this.txbUsername.TabIndex = 3;
            this.txbUsername.TextChanged += new System.EventHandler(this.txbUsername_TextChanged);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(3, 9);
            this.label92.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(84, 13);
            this.label92.TabIndex = 0;
            this.label92.Text = "Tên đăng nhập:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnAccept);
            this.panel3.Location = new System.Drawing.Point(13, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(365, 60);
            this.panel3.TabIndex = 42;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::QLNV_CHBHXM.Properties.Resources.exit;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(184, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(62, 11);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(116, 39);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FChangePassword
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 375);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel75);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.panel75.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel82.ResumeLayout(false);
            this.panel82.PerformLayout();
            this.panel83.ResumeLayout(false);
            this.panel83.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel75;
        private System.Windows.Forms.Panel panel82;
        private System.Windows.Forms.Label lblPassword;
        private MyControlLibrary.MyTextBox txbPassword;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Panel panel83;
        private System.Windows.Forms.Label lblUsername;
        private MyControlLibrary.MyTextBox txbUsername;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblConfirmPass;
        private MyControlLibrary.MyTextBox txbConfirmPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNewPass;
        private MyControlLibrary.MyTextBox txbNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}