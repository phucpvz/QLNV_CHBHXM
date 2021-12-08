
namespace QLNV_CHBHXM.GUI
{
    partial class FReportPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportPrice));
            this.USP_TimKiemVaSapXepDonGiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNV_CHBHXMDataSet = new QLNV_CHBHXM.QLNV_CHBHXMDataSet();
            this.rvPrice = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_TimKiemVaSapXepDonGiaTableAdapter = new QLNV_CHBHXM.QLNV_CHBHXMDataSetTableAdapters.USP_TimKiemVaSapXepDonGiaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TimKiemVaSapXepDonGiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNV_CHBHXMDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_TimKiemVaSapXepDonGiaBindingSource
            // 
            this.USP_TimKiemVaSapXepDonGiaBindingSource.DataMember = "USP_TimKiemVaSapXepDonGia";
            this.USP_TimKiemVaSapXepDonGiaBindingSource.DataSource = this.qLNV_CHBHXMDataSet;
            // 
            // qLNV_CHBHXMDataSet
            // 
            this.qLNV_CHBHXMDataSet.DataSetName = "QLNV_CHBHXMDataSet";
            this.qLNV_CHBHXMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvPrice
            // 
            this.rvPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rvPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_TimKiemVaSapXepDonGiaBindingSource;
            this.rvPrice.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPrice.LocalReport.ReportEmbeddedResource = "QLNV_CHBHXM.REPORT.ReportPrice.rdlc";
            this.rvPrice.Location = new System.Drawing.Point(0, 0);
            this.rvPrice.Name = "rvPrice";
            this.rvPrice.ServerReport.BearerToken = null;
            this.rvPrice.Size = new System.Drawing.Size(800, 450);
            this.rvPrice.TabIndex = 0;
            // 
            // uSP_TimKiemVaSapXepDonGiaTableAdapter
            // 
            this.uSP_TimKiemVaSapXepDonGiaTableAdapter.ClearBeforeFill = true;
            // 
            // FReportPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvPrice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FReportPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng giá bảo hành xe máy tại cửa hàng";
            this.Load += new System.EventHandler(this.FReportPrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_TimKiemVaSapXepDonGiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNV_CHBHXMDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPrice;
        private QLNV_CHBHXMDataSet qLNV_CHBHXMDataSet;
        private QLNV_CHBHXMDataSetTableAdapters.USP_TimKiemVaSapXepDonGiaTableAdapter uSP_TimKiemVaSapXepDonGiaTableAdapter;
        private System.Windows.Forms.BindingSource USP_TimKiemVaSapXepDonGiaBindingSource;
    }
}