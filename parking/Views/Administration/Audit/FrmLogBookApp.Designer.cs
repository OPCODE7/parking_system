namespace parking.Views.Administration.Audit
{
    partial class FrmLogBookApp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogBookApp));
            this.DgvLogs = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGISTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbxSearch = new System.Windows.Forms.PictureBox();
            this.PbxCancel = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.TxtLogId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtAction = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtModule = new System.Windows.Forms.TextBox();
            this.TlpSelectRow = new System.Windows.Forms.ToolTip(this.components);
            this.PbxPrint = new System.Windows.Forms.PictureBox();
            this.TlpGenerateRpt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvLogs
            // 
            this.DgvLogs.AllowUserToAddRows = false;
            this.DgvLogs.AllowUserToDeleteRows = false;
            this.DgvLogs.AllowUserToResizeColumns = false;
            this.DgvLogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DESCRIPCION,
            this.REGISTRO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLogs.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvLogs.Location = new System.Drawing.Point(14, 267);
            this.DgvLogs.Name = "DgvLogs";
            this.DgvLogs.ReadOnly = true;
            this.DgvLogs.RowHeadersVisible = false;
            this.DgvLogs.RowHeadersWidth = 62;
            this.DgvLogs.RowTemplate.Height = 28;
            this.DgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLogs.Size = new System.Drawing.Size(656, 303);
            this.DgvLogs.TabIndex = 93;
            this.TlpSelectRow.SetToolTip(this.DgvLogs, "Doble click para seleccionar un registro.");
            this.DgvLogs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmployees_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 120;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.MinimumWidth = 8;
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 410;
            // 
            // REGISTRO
            // 
            this.REGISTRO.HeaderText = "REGISTRO";
            this.REGISTRO.MinimumWidth = 8;
            this.REGISTRO.Name = "REGISTRO";
            this.REGISTRO.ReadOnly = true;
            this.REGISTRO.Width = 120;
            // 
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(609, 218);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(26, 27);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxSearch.TabIndex = 92;
            this.PbxSearch.TabStop = false;
            this.PbxSearch.Click += new System.EventHandler(this.PbxSearch_Click);
            // 
            // PbxCancel
            // 
            this.PbxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxCancel.BackColor = System.Drawing.Color.Transparent;
            this.PbxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxCancel.Image = ((System.Drawing.Image)(resources.GetObject("PbxCancel.Image")));
            this.PbxCancel.Location = new System.Drawing.Point(643, 218);
            this.PbxCancel.Name = "PbxCancel";
            this.PbxCancel.Size = new System.Drawing.Size(26, 27);
            this.PbxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxCancel.TabIndex = 91;
            this.PbxCancel.TabStop = false;
            this.PbxCancel.Click += new System.EventHandler(this.PbxCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(13, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 90;
            this.label6.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSearch.Location = new System.Drawing.Point(94, 220);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(457, 26);
            this.TxtSearch.TabIndex = 87;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(640, 7);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 89;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCancel,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(679, 42);
            this.toolStrip1.TabIndex = 88;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 37);
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(10, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 102;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 101;
            this.label1.Text = "Código:";
            // 
            // TxtDescription
            // 
            this.TxtDescription.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDescription.Location = new System.Drawing.Point(14, 152);
            this.TxtDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDescription.MaxLength = 30;
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(652, 44);
            this.TxtDescription.TabIndex = 99;
            // 
            // TxtLogId
            // 
            this.TxtLogId.BackColor = System.Drawing.SystemColors.Control;
            this.TxtLogId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLogId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtLogId.Location = new System.Drawing.Point(14, 86);
            this.TxtLogId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtLogId.Multiline = true;
            this.TxtLogId.Name = "TxtLogId";
            this.TxtLogId.ReadOnly = true;
            this.TxtLogId.Size = new System.Drawing.Size(144, 30);
            this.TxtLogId.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(177, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 104;
            this.label3.Text = "Usuario:";
            // 
            // TxtUser
            // 
            this.TxtUser.BackColor = System.Drawing.SystemColors.Control;
            this.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtUser.Location = new System.Drawing.Point(181, 86);
            this.TxtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtUser.Multiline = true;
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.ReadOnly = true;
            this.TxtUser.Size = new System.Drawing.Size(144, 30);
            this.TxtUser.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(343, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 106;
            this.label4.Text = "Acción:";
            // 
            // TxtAction
            // 
            this.TxtAction.BackColor = System.Drawing.SystemColors.Control;
            this.TxtAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtAction.Location = new System.Drawing.Point(347, 86);
            this.TxtAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtAction.Multiline = true;
            this.TxtAction.Name = "TxtAction";
            this.TxtAction.ReadOnly = true;
            this.TxtAction.Size = new System.Drawing.Size(144, 30);
            this.TxtAction.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(518, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 108;
            this.label5.Text = "Módulo:";
            // 
            // TxtModule
            // 
            this.TxtModule.BackColor = System.Drawing.SystemColors.Control;
            this.TxtModule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtModule.Location = new System.Drawing.Point(522, 86);
            this.TxtModule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtModule.Multiline = true;
            this.TxtModule.Name = "TxtModule";
            this.TxtModule.ReadOnly = true;
            this.TxtModule.Size = new System.Drawing.Size(144, 30);
            this.TxtModule.TabIndex = 107;
            // 
            // TlpSelectRow
            // 
            this.TlpSelectRow.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TlpSelectRow.ToolTipTitle = "Seleccionar";
            // 
            // PbxPrint
            // 
            this.PbxPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxPrint.BackColor = System.Drawing.Color.Transparent;
            this.PbxPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxPrint.Image = ((System.Drawing.Image)(resources.GetObject("PbxPrint.Image")));
            this.PbxPrint.Location = new System.Drawing.Point(574, 218);
            this.PbxPrint.Name = "PbxPrint";
            this.PbxPrint.Size = new System.Drawing.Size(26, 27);
            this.PbxPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxPrint.TabIndex = 109;
            this.PbxPrint.TabStop = false;
            this.TlpGenerateRpt.SetToolTip(this.PbxPrint, "Generar reporte de logs.");
            this.PbxPrint.Click += new System.EventHandler(this.PbxPrint_Click);
            // 
            // TlpGenerateRpt
            // 
            this.TlpGenerateRpt.ToolTipTitle = "Generar reporte";
            // 
            // FrmLogBookApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(679, 587);
            this.Controls.Add(this.PbxPrint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtModule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtAction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.TxtLogId);
            this.Controls.Add(this.DgvLogs);
            this.Controls.Add(this.PbxSearch);
            this.Controls.Add(this.PbxCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogBookApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogBookApp";
            this.Load += new System.EventHandler(this.FrmLogBookApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DgvLogs;
        private System.Windows.Forms.PictureBox PbxSearch;
        private System.Windows.Forms.PictureBox PbxCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.TextBox TxtLogId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtAction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtModule;
        private System.Windows.Forms.ToolTip TlpSelectRow;
        private System.Windows.Forms.PictureBox PbxPrint;
        private System.Windows.Forms.ToolTip TlpGenerateRpt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGISTRO;
    }
}