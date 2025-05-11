namespace parking.Views.Reports
{
    partial class FrmCheckInReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckInReport));
            this.GbxFilters = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbParkingTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PbxClearFilter = new System.Windows.Forms.PictureBox();
            this.PbxSearch = new System.Windows.Forms.PictureBox();
            this.CmbMonth = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmbUsers = new System.Windows.Forms.ComboBox();
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.RptCheckIn = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GbxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClearFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxFilters
            // 
            this.GbxFilters.Controls.Add(this.label5);
            this.GbxFilters.Controls.Add(this.CmbParkingTypes);
            this.GbxFilters.Controls.Add(this.label4);
            this.GbxFilters.Controls.Add(this.label3);
            this.GbxFilters.Controls.Add(this.PbxClose);
            this.GbxFilters.Controls.Add(this.label2);
            this.GbxFilters.Controls.Add(this.label1);
            this.GbxFilters.Controls.Add(this.PbxClearFilter);
            this.GbxFilters.Controls.Add(this.PbxSearch);
            this.GbxFilters.Controls.Add(this.CmbMonth);
            this.GbxFilters.Controls.Add(this.CmbYear);
            this.GbxFilters.Controls.Add(this.CmbUsers);
            this.GbxFilters.Controls.Add(this.DtpTo);
            this.GbxFilters.Controls.Add(this.DtpFrom);
            this.GbxFilters.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbxFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.GbxFilters.Location = new System.Drawing.Point(12, 12);
            this.GbxFilters.Name = "GbxFilters";
            this.GbxFilters.Size = new System.Drawing.Size(887, 230);
            this.GbxFilters.TabIndex = 135;
            this.GbxFilters.TabStop = false;
            this.GbxFilters.Text = "Seleccione el criterio de búsqueda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(8, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 154;
            this.label5.Text = "Tipo de parqueo:";
            // 
            // CmbParkingTypes
            // 
            this.CmbParkingTypes.FormattingEnabled = true;
            this.CmbParkingTypes.Location = new System.Drawing.Point(161, 172);
            this.CmbParkingTypes.Name = "CmbParkingTypes";
            this.CmbParkingTypes.Size = new System.Drawing.Size(314, 27);
            this.CmbParkingTypes.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(8, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 152;
            this.label4.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 152;
            this.label3.Text = "Año:";
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.Transparent;
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(861, 0);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 130;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 19);
            this.label2.TabIndex = 151;
            this.label2.Text = "Mes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 150;
            this.label1.Text = "Rango de fechas:";
            // 
            // PbxClearFilter
            // 
            this.PbxClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClearFilter.BackColor = System.Drawing.Color.Transparent;
            this.PbxClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClearFilter.Image = ((System.Drawing.Image)(resources.GetObject("PbxClearFilter.Image")));
            this.PbxClearFilter.Location = new System.Drawing.Point(786, 171);
            this.PbxClearFilter.Name = "PbxClearFilter";
            this.PbxClearFilter.Size = new System.Drawing.Size(35, 28);
            this.PbxClearFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClearFilter.TabIndex = 139;
            this.PbxClearFilter.TabStop = false;
            this.PbxClearFilter.Click += new System.EventHandler(this.PbxClearFilter_Click);
            // 
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(824, 171);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(35, 28);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxSearch.TabIndex = 138;
            this.PbxSearch.TabStop = false;
            this.PbxSearch.Click += new System.EventHandler(this.PbxSearch_Click);
            // 
            // CmbMonth
            // 
            this.CmbMonth.FormattingEnabled = true;
            this.CmbMonth.Location = new System.Drawing.Point(161, 71);
            this.CmbMonth.Name = "CmbMonth";
            this.CmbMonth.Size = new System.Drawing.Size(314, 27);
            this.CmbMonth.TabIndex = 137;
            this.CmbMonth.SelectedValueChanged += new System.EventHandler(this.CmbMonth_SelectedValueChanged);
            // 
            // CmbYear
            // 
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(161, 104);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(314, 27);
            this.CmbYear.TabIndex = 136;
            this.CmbYear.SelectedValueChanged += new System.EventHandler(this.CmbYear_SelectedValueChanged);
            // 
            // CmbUsers
            // 
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.Location = new System.Drawing.Point(161, 139);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.Size = new System.Drawing.Size(314, 27);
            this.CmbUsers.TabIndex = 135;
            // 
            // DtpTo
            // 
            this.DtpTo.Location = new System.Drawing.Point(481, 36);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(314, 27);
            this.DtpTo.TabIndex = 134;
            this.DtpTo.ValueChanged += new System.EventHandler(this.DtpTo_ValueChanged);
            // 
            // DtpFrom
            // 
            this.DtpFrom.Location = new System.Drawing.Point(161, 36);
            this.DtpFrom.Name = "DtpFrom";
            this.DtpFrom.Size = new System.Drawing.Size(314, 27);
            this.DtpFrom.TabIndex = 133;
            this.DtpFrom.ValueChanged += new System.EventHandler(this.DtpFrom_ValueChanged);
            // 
            // RptCheckIn
            // 
            this.RptCheckIn.Location = new System.Drawing.Point(13, 258);
            this.RptCheckIn.Name = "RptCheckIn";
            this.RptCheckIn.ServerReport.BearerToken = null;
            this.RptCheckIn.Size = new System.Drawing.Size(886, 402);
            this.RptCheckIn.TabIndex = 136;
            // 
            // FrmCheckInReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(911, 673);
            this.Controls.Add(this.GbxFilters);
            this.Controls.Add(this.RptCheckIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCheckInReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCheckInReport";
            this.Load += new System.EventHandler(this.FrmCheckInReport_Load);
            this.GbxFilters.ResumeLayout(false);
            this.GbxFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClearFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbxClearFilter;
        private System.Windows.Forms.PictureBox PbxSearch;
        private System.Windows.Forms.ComboBox CmbMonth;
        private System.Windows.Forms.ComboBox CmbYear;
        private System.Windows.Forms.ComboBox CmbUsers;
        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.DateTimePicker DtpFrom;
        private Microsoft.Reporting.WinForms.ReportViewer RptCheckIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbParkingTypes;
    }
}