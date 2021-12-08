
namespace QLNV_CHBHXM.GUI
{
    partial class FReportEmployee
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportEmployee));
            this.USP_TimKiemVaSapXepNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNV_CHBHXMDataSet = new QLNV_CHBHXM.QLNV_CHBHXMDataSet();
            this.rvEmployee = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_TimKiemVaSapXepNhanVienTableAdapter = new QLNV_CHBHXM.QLNV_CHBHXMDataSetTableAdapters.USP_TimKiemVaSapXepNhanVienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TimKiemVaSapXepNhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNV_CHBHXMDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_TimKiemVaSapXepNhanVienBindingSource
            // 
            this.USP_TimKiemVaSapXepNhanVienBindingSource.DataMember = "USP_TimKiemVaSapXepNhanVien";
            this.USP_TimKiemVaSapXepNhanVienBindingSource.DataSource = this.qLNV_CHBHXMDataSet;
            // 
            // qLNV_CHBHXMDataSet
            // 
            this.qLNV_CHBHXMDataSet.DataSetName = "QLNV_CHBHXMDataSet";
            this.qLNV_CHBHXMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvEmployee
            // 
            this.rvEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rvEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "MyDataSet";
            reportDataSource1.Value = this.USP_TimKiemVaSapXepNhanVienBindingSource;
            this.rvEmployee.LocalReport.DataSources.Add(reportDataSource1);
            this.rvEmployee.LocalReport.ReportEmbeddedResource = "QLNV_CHBHXM.REPORT.ReportEmployee.rdlc";
            this.rvEmployee.Location = new System.Drawing.Point(0, 0);
            this.rvEmployee.Name = "rvEmployee";
            this.rvEmployee.ServerReport.BearerToken = null;
            this.rvEmployee.Size = new System.Drawing.Size(1155, 583);
            this.rvEmployee.TabIndex = 0;
            // 
            // uSP_TimKiemVaSapXepNhanVienTableAdapter
            // 
            this.uSP_TimKiemVaSapXepNhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // FReportEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 583);
            this.Controls.Add(this.rvEmployee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FReportEmployee";
            this.Text = "Thống kê nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReportEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_TimKiemVaSapXepNhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNV_CHBHXMDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvEmployee;
        private QLNV_CHBHXMDataSet qLNV_CHBHXMDataSet;
        private QLNV_CHBHXMDataSetTableAdapters.USP_TimKiemVaSapXepNhanVienTableAdapter uSP_TimKiemVaSapXepNhanVienTableAdapter;
        private System.Windows.Forms.BindingSource USP_TimKiemVaSapXepNhanVienBindingSource;
    }
}