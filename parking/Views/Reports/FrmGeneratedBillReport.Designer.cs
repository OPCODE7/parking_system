namespace parking.Views.Reports
{
    partial class FrmGeneratedBillReport
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
            this.RptBill = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RptBill
            // 
            this.RptBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptBill.LocalReport.ReportEmbeddedResource = "parking.Views.Reports.RDLC.ReportGeneratedBill.rdlc";
            this.RptBill.Location = new System.Drawing.Point(0, 0);
            this.RptBill.Name = "RptBill";
            this.RptBill.ServerReport.BearerToken = null;
            this.RptBill.Size = new System.Drawing.Size(870, 647);
            this.RptBill.TabIndex = 0;
            // 
            // FrmGeneratedBillReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 647);
            this.Controls.Add(this.RptBill);
            this.Name = "FrmGeneratedBillReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGeneratedBillReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGeneratedBillReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer RptBill;
    }
}