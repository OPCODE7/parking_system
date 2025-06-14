namespace parking.Views.Administration.BillingModule
{
    partial class FrmManageDiscounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageDiscounts));
            this.DgvDiscounts = new System.Windows.Forms.DataGridView();
            this.DISCOUNT_TYPE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISCOUNT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOURS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FREQUENCY_DAYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDescriptionDiscountType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDiscountDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDiscountValue = new System.Windows.Forms.TextBox();
            this.ChkState = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtHours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDays = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDiscounts)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvDiscounts
            // 
            this.DgvDiscounts.AllowUserToAddRows = false;
            this.DgvDiscounts.AllowUserToDeleteRows = false;
            this.DgvDiscounts.AllowUserToResizeColumns = false;
            this.DgvDiscounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvDiscounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvDiscounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDiscounts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DISCOUNT_TYPE_ID,
            this.DISCOUNT_ID,
            this.DESCRIPTION,
            this.VALUE,
            this.ESTADO,
            this.HOURS,
            this.FREQUENCY_DAYS});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvDiscounts.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvDiscounts.Location = new System.Drawing.Point(13, 211);
            this.DgvDiscounts.Name = "DgvDiscounts";
            this.DgvDiscounts.ReadOnly = true;
            this.DgvDiscounts.RowHeadersVisible = false;
            this.DgvDiscounts.RowHeadersWidth = 62;
            this.DgvDiscounts.RowTemplate.Height = 28;
            this.DgvDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDiscounts.Size = new System.Drawing.Size(646, 313);
            this.DgvDiscounts.TabIndex = 154;
            this.DgvDiscounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDiscounts_CellDoubleClick);
            // 
            // DISCOUNT_TYPE_ID
            // 
            this.DISCOUNT_TYPE_ID.HeaderText = "ID TIPO DESCUENTO";
            this.DISCOUNT_TYPE_ID.MinimumWidth = 8;
            this.DISCOUNT_TYPE_ID.Name = "DISCOUNT_TYPE_ID";
            this.DISCOUNT_TYPE_ID.ReadOnly = true;
            // 
            // DISCOUNT_ID
            // 
            this.DISCOUNT_ID.HeaderText = "ID DESCUENTO";
            this.DISCOUNT_ID.MinimumWidth = 8;
            this.DISCOUNT_ID.Name = "DISCOUNT_ID";
            this.DISCOUNT_ID.ReadOnly = true;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.HeaderText = "DESCRIPCION";
            this.DESCRIPTION.MinimumWidth = 8;
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            // 
            // VALUE
            // 
            this.VALUE.HeaderText = "VALOR";
            this.VALUE.MinimumWidth = 8;
            this.VALUE.Name = "VALUE";
            this.VALUE.ReadOnly = true;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "ESTADO";
            this.ESTADO.MinimumWidth = 8;
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            // 
            // HOURS
            // 
            this.HOURS.HeaderText = "HORAS";
            this.HOURS.MinimumWidth = 8;
            this.HOURS.Name = "HOURS";
            this.HOURS.ReadOnly = true;
            // 
            // FREQUENCY_DAYS
            // 
            this.FREQUENCY_DAYS.HeaderText = "FREQUENCIA EN DIAS";
            this.FREQUENCY_DAYS.MinimumWidth = 8;
            this.FREQUENCY_DAYS.Name = "FREQUENCY_DAYS";
            this.FREQUENCY_DAYS.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnEdit,
            this.toolStripSeparator2,
            this.BtnCancel,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(671, 42);
            this.toolStrip1.TabIndex = 155;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("BtnEdit.Image")));
            this.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(80, 37);
            this.BtnEdit.Text = "Editar";
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
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
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(636, 10);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 156;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 158;
            this.label1.Text = "Tipo de descuento:";
            // 
            // TxtDescriptionDiscountType
            // 
            this.TxtDescriptionDiscountType.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDescriptionDiscountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescriptionDiscountType.Enabled = false;
            this.TxtDescriptionDiscountType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDescriptionDiscountType.Location = new System.Drawing.Point(13, 87);
            this.TxtDescriptionDiscountType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDescriptionDiscountType.Multiline = true;
            this.TxtDescriptionDiscountType.Name = "TxtDescriptionDiscountType";
            this.TxtDescriptionDiscountType.ReadOnly = true;
            this.TxtDescriptionDiscountType.Size = new System.Drawing.Size(305, 30);
            this.TxtDescriptionDiscountType.TabIndex = 157;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(331, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 22);
            this.label2.TabIndex = 160;
            this.label2.Text = "Descripción descuento:";
            // 
            // TxtDiscountDescription
            // 
            this.TxtDiscountDescription.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDiscountDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDiscountDescription.Enabled = false;
            this.TxtDiscountDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDiscountDescription.Location = new System.Drawing.Point(335, 87);
            this.TxtDiscountDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDiscountDescription.Multiline = true;
            this.TxtDiscountDescription.Name = "TxtDiscountDescription";
            this.TxtDiscountDescription.Size = new System.Drawing.Size(324, 30);
            this.TxtDiscountDescription.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(9, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 22);
            this.label3.TabIndex = 162;
            this.label3.Text = "Porcentaje descuento:";
            // 
            // TxtDiscountValue
            // 
            this.TxtDiscountValue.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDiscountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDiscountValue.Enabled = false;
            this.TxtDiscountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDiscountValue.Location = new System.Drawing.Point(13, 161);
            this.TxtDiscountValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDiscountValue.Multiline = true;
            this.TxtDiscountValue.Name = "TxtDiscountValue";
            this.TxtDiscountValue.Size = new System.Drawing.Size(191, 30);
            this.TxtDiscountValue.TabIndex = 161;
            // 
            // ChkState
            // 
            this.ChkState.AutoSize = true;
            this.ChkState.Checked = true;
            this.ChkState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.ChkState.Location = new System.Drawing.Point(577, 164);
            this.ChkState.Name = "ChkState";
            this.ChkState.Size = new System.Drawing.Size(86, 24);
            this.ChkState.TabIndex = 163;
            this.ChkState.Text = "Estado";
            this.ChkState.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(224, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 22);
            this.label4.TabIndex = 165;
            this.label4.Text = "Horas:";
            // 
            // TxtHours
            // 
            this.TxtHours.BackColor = System.Drawing.SystemColors.Control;
            this.TxtHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtHours.Enabled = false;
            this.TxtHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtHours.Location = new System.Drawing.Point(228, 161);
            this.TxtHours.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtHours.Multiline = true;
            this.TxtHours.Name = "TxtHours";
            this.TxtHours.Size = new System.Drawing.Size(157, 30);
            this.TxtHours.TabIndex = 164;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(398, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 22);
            this.label5.TabIndex = 167;
            this.label5.Text = "Días de frequencia:";
            // 
            // TxtDays
            // 
            this.TxtDays.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDays.Enabled = false;
            this.TxtDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDays.Location = new System.Drawing.Point(402, 161);
            this.TxtDays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDays.Multiline = true;
            this.TxtDays.Name = "TxtDays";
            this.TxtDays.Size = new System.Drawing.Size(157, 30);
            this.TxtDays.TabIndex = 166;
            // 
            // FrmManageDiscounts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(671, 542);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtHours);
            this.Controls.Add(this.ChkState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtDiscountValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtDiscountDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDescriptionDiscountType);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.DgvDiscounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmManageDiscounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmManageDiscounts";
            this.Load += new System.EventHandler(this.FrmManageDiscounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDiscounts)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DgvDiscounts;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCOUNT_TYPE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCOUNT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOURS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FREQUENCY_DAYS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDescriptionDiscountType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDiscountDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDiscountValue;
        private System.Windows.Forms.CheckBox ChkState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDays;
    }
}