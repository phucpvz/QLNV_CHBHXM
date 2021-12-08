
namespace QLNV_CHBHXM.GUI
{
    partial class FReportSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportSalary));
            this.USP_TimKiemVaSapXepLuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNV_CHBHXMDataSet = new QLNV_CHBHXM.QLNV_CHBHXMDataSet();
            this.rvSalary = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_TimKiemVaSapXepLuongTableAdapter = new QLNV_CHBHXM.QLNV_CHBHXMDataSetTableAdapters.USP_TimKiemVaSapXepLuongTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TimKiemVaSapXepLuongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNV_CHBHXMDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_TimKiemVaSapXepLuongBindingSource
            // 
            this.USP_TimKiemVaSapXepLuongBindingSource.DataMember = "USP_TimKiemVaSapXepLuong";
            this.USP_TimKiemVaSapXepLuongBindingSource.DataSource = this.qLNV_CHBHXMDataSet;
            // 
            // qLNV_CHBHXMDataSet
            // 
            this.qLNV_CHBHXMDataSet.DataSetName = "QLNV_CHBHXMDataSet";
            this.qLNV_CHBHXMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvSalary
            // 
            this.rvSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rvSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_TimKiemVaSapXepLuongBindingSource;
            this.rvSalary.LocalReport.DataSources.Add(reportDataSource1);
            this.rvSalary.LocalReport.ReportEmbeddedResource = "QLNV_CHBHXM.REPORT.ReportSalary.rdlc";
            this.rvSalary.Location = new System.Drawing.Point(0, 0);
            this.rvSalary.Name = "rvSalary";
            this.rvSalary.ServerReport.BearerToken = null;
            this.rvSalary.Size = new System.Drawing.Size(1155, 568);
            this.rvSalary.TabIndex = 0;
            // 
            // uSP_TimKiemVaSapXepLuongTableAdapter
            // 
            this.uSP_TimKiemVaSapXepLuongTableAdapter.ClearBeforeFill = true;
            // 
            // FReportSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 568);
            this.Controls.Add(this.rvSalary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FReportSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu và lương";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FReportSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_TimKiemVaSapXepLuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNV_CHBHXMDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvSalary;
        private System.Windows.Forms.BindingSource USP_TimKiemVaSapXepLuongBindingSource;
        private QLNV_CHBHXMDataSet qLNV_CHBHXMDataSet;
        private QLNV_CHBHXMDataSetTableAdapters.USP_TimKiemVaSapXepLuongTableAdapter uSP_TimKiemVaSapXepLuongTableAdapter;
    }
}