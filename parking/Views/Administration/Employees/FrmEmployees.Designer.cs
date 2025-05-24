namespace parking.Views.Administration.Employees
{
    partial class FrmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployees));
            this.DgvEmployees = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDENTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HORARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGISTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbxSearch = new System.Windows.Forms.PictureBox();
            this.PbxCancel = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.CmbJobPosition = new System.Windows.Forms.ComboBox();
            this.TxtEmployeeName = new System.Windows.Forms.TextBox();
            this.TxtDni = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPaperbin = new System.Windows.Forms.ToolStripButton();
            this.TxtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MskPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbHorary = new System.Windows.Forms.ComboBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.PbxRecovery = new System.Windows.Forms.PictureBox();
            this.PbxDestroy = new System.Windows.Forms.PictureBox();
            this.TtpDestroy = new System.Windows.Forms.ToolTip(this.components);
            this.TtpRecovery = new System.Windows.Forms.ToolTip(this.components);
            this.PbxPrint = new System.Windows.Forms.PictureBox();
            this.TlpGenerateRpt = new System.Windows.Forms.ToolTip(this.components);
            this.TlpSelectRow = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxRecovery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDestroy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvEmployees
            // 
            this.DgvEmployees.AllowUserToAddRows = false;
            this.DgvEmployees.AllowUserToDeleteRows = false;
            this.DgvEmployees.AllowUserToResizeColumns = false;
            this.DgvEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDENTIDAD,
            this.NOMBRE,
            this.CARGO,
            this.HORARIO,
            this.TELEFONO,
            this.REGISTRO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvEmployees.Location = new System.Drawing.Point(25, 321);
            this.DgvEmployees.Name = "DgvEmployees";
            this.DgvEmployees.ReadOnly = true;
            this.DgvEmployees.RowHeadersVisible = false;
            this.DgvEmployees.RowHeadersWidth = 62;
            this.DgvEmployees.RowTemplate.Height = 28;
            this.DgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvEmployees.Size = new System.Drawing.Size(813, 246);
            this.DgvEmployees.TabIndex = 77;
            this.TlpSelectRow.SetToolTip(this.DgvEmployees, "Doble click para seleccionar registro.");
            this.DgvEmployees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmployees_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // IDENTIDAD
            // 
            this.IDENTIDAD.HeaderText = "IDENTIDAD";
            this.IDENTIDAD.MinimumWidth = 8;
            this.IDENTIDAD.Name = "IDENTIDAD";
            this.IDENTIDAD.ReadOnly = true;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.MinimumWidth = 8;
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            // 
            // CARGO
            // 
            this.CARGO.HeaderText = "CARGO";
            this.CARGO.MinimumWidth = 8;
            this.CARGO.Name = "CARGO";
            this.CARGO.ReadOnly = true;
            // 
            // HORARIO
            // 
            this.HORARIO.HeaderText = "HORARIO";
            this.HORARIO.MinimumWidth = 8;
            this.HORARIO.Name = "HORARIO";
            this.HORARIO.ReadOnly = true;
            // 
            // TELEFONO
            // 
            this.TELEFONO.HeaderText = "TELEFONO";
            this.TELEFONO.MinimumWidth = 8;
            this.TELEFONO.Name = "TELEFONO";
            this.TELEFONO.ReadOnly = true;
            // 
            // REGISTRO
            // 
            this.REGISTRO.HeaderText = "REGISTRO";
            this.REGISTRO.MinimumWidth = 8;
            this.REGISTRO.Name = "REGISTRO";
            this.REGISTRO.ReadOnly = true;
            // 
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(777, 281);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(26, 27);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxSearch.TabIndex = 76;
            this.PbxSearch.TabStop = false;
            this.PbxSearch.Click += new System.EventHandler(this.PbxSearch_Click);
            // 
            // PbxCancel
            // 
            this.PbxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxCancel.BackColor = System.Drawing.Color.Transparent;
            this.PbxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxCancel.Image = ((System.Drawing.Image)(resources.GetObject("PbxCancel.Image")));
            this.PbxCancel.Location = new System.Drawing.Point(811, 281);
            this.PbxCancel.Name = "PbxCancel";
            this.PbxCancel.Size = new System.Drawing.Size(26, 27);
            this.PbxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxCancel.TabIndex = 75;
            this.PbxCancel.TabStop = false;
            this.PbxCancel.Click += new System.EventHandler(this.PbxCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(23, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 74;
            this.label6.Text = "Buscar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(593, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 22);
            this.label4.TabIndex = 71;
            this.label4.Text = "Seleccionar Cargo:";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.LblName.Location = new System.Drawing.Point(21, 124);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(87, 22);
            this.LblName.TabIndex = 70;
            this.LblName.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(183, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 69;
            this.label2.Text = "DNI:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 68;
            this.label1.Text = "Código:";
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(819, 7);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 66;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // CmbJobPosition
            // 
            this.CmbJobPosition.BackColor = System.Drawing.SystemColors.Control;
            this.CmbJobPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.CmbJobPosition.FormattingEnabled = true;
            this.CmbJobPosition.Location = new System.Drawing.Point(596, 153);
            this.CmbJobPosition.Name = "CmbJobPosition";
            this.CmbJobPosition.Size = new System.Drawing.Size(242, 28);
            this.CmbJobPosition.TabIndex = 7;
            // 
            // TxtEmployeeName
            // 
            this.TxtEmployeeName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmployeeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtEmployeeName.Location = new System.Drawing.Point(25, 154);
            this.TxtEmployeeName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtEmployeeName.MaxLength = 50;
            this.TxtEmployeeName.Name = "TxtEmployeeName";
            this.TxtEmployeeName.Size = new System.Drawing.Size(250, 26);
            this.TxtEmployeeName.TabIndex = 3;
            // 
            // TxtDni
            // 
            this.TxtDni.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDni.Location = new System.Drawing.Point(187, 89);
            this.TxtDni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDni.MaxLength = 15;
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(305, 26);
            this.TxtDni.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.toolStripSeparator1,
            this.BtnEdit,
            this.toolStripSeparator2,
            this.BtnDelete,
            this.toolStripSeparator3,
            this.BtnSave,
            this.toolStripSeparator4,
            this.BtnCancel,
            this.toolStripSeparator5,
            this.BtnPaperbin});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(852, 42);
            this.toolStrip1.TabIndex = 61;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.Image")));
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(88, 37);
            this.BtnNew.Text = "Nuevo";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
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
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(99, 37);
            this.BtnDelete.Text = "Eliminar";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(103, 37);
            this.BtnSave.Text = "Guardar";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
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
            // BtnPaperbin
            // 
            this.BtnPaperbin.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaperbin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnPaperbin.Image = ((System.Drawing.Image)(resources.GetObject("BtnPaperbin.Image")));
            this.BtnPaperbin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPaperbin.Name = "BtnPaperbin";
            this.BtnPaperbin.Size = new System.Drawing.Size(108, 37);
            this.BtnPaperbin.Text = "Papelera";
            this.BtnPaperbin.Click += new System.EventHandler(this.BtnPaperbin_Click);
            // 
            // TxtEmployeeCode
            // 
            this.TxtEmployeeCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmployeeCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtEmployeeCode.Location = new System.Drawing.Point(24, 89);
            this.TxtEmployeeCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtEmployeeCode.Name = "TxtEmployeeCode";
            this.TxtEmployeeCode.ReadOnly = true;
            this.TxtEmployeeCode.Size = new System.Drawing.Size(144, 26);
            this.TxtEmployeeCode.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(310, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 79;
            this.label7.Text = "Apellido:";
            // 
            // TxtLastName
            // 
            this.TxtLastName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtLastName.Location = new System.Drawing.Point(314, 154);
            this.TxtLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtLastName.MaxLength = 50;
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(250, 26);
            this.TxtLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(503, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 81;
            this.label3.Text = "Teléfono";
            // 
            // MskPhoneNumber
            // 
            this.MskPhoneNumber.BackColor = System.Drawing.SystemColors.Control;
            this.MskPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MskPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.MskPhoneNumber.Location = new System.Drawing.Point(507, 89);
            this.MskPhoneNumber.Mask = "0000-0000";
            this.MskPhoneNumber.Name = "MskPhoneNumber";
            this.MskPhoneNumber.Size = new System.Drawing.Size(144, 26);
            this.MskPhoneNumber.TabIndex = 2;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.SystemColors.Control;
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtEmail.Location = new System.Drawing.Point(26, 225);
            this.TxtEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtEmail.MaxLength = 200;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(203, 26);
            this.TxtEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(22, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 22);
            this.label5.TabIndex = 70;
            this.label5.Text = "Email:";
            // 
            // TxtAddress
            // 
            this.TxtAddress.BackColor = System.Drawing.SystemColors.Control;
            this.TxtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtAddress.Location = new System.Drawing.Point(242, 225);
            this.TxtAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtAddress.MaxLength = 255;
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(322, 26);
            this.TxtAddress.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(238, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 22);
            this.label8.TabIndex = 79;
            this.label8.Text = "Dirección:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label9.Location = new System.Drawing.Point(594, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 22);
            this.label9.TabIndex = 84;
            this.label9.Text = "Seleccionar Horario:";
            // 
            // CmbHorary
            // 
            this.CmbHorary.BackColor = System.Drawing.SystemColors.Control;
            this.CmbHorary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.CmbHorary.FormattingEnabled = true;
            this.CmbHorary.Location = new System.Drawing.Point(597, 224);
            this.CmbHorary.Name = "CmbHorary";
            this.CmbHorary.Size = new System.Drawing.Size(241, 28);
            this.CmbHorary.TabIndex = 8;
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSearch.Location = new System.Drawing.Point(104, 281);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(546, 26);
            this.TxtSearch.TabIndex = 9;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // PbxRecovery
            // 
            this.PbxRecovery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxRecovery.BackColor = System.Drawing.Color.Transparent;
            this.PbxRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxRecovery.Image = ((System.Drawing.Image)(resources.GetObject("PbxRecovery.Image")));
            this.PbxRecovery.Location = new System.Drawing.Point(678, 282);
            this.PbxRecovery.Name = "PbxRecovery";
            this.PbxRecovery.Size = new System.Drawing.Size(26, 27);
            this.PbxRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxRecovery.TabIndex = 85;
            this.PbxRecovery.TabStop = false;
            this.TtpRecovery.SetToolTip(this.PbxRecovery, "Recuperar registro de la papelera");
            this.PbxRecovery.Visible = false;
            this.PbxRecovery.Click += new System.EventHandler(this.PbxRecovery_Click);
            // 
            // PbxDestroy
            // 
            this.PbxDestroy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxDestroy.BackColor = System.Drawing.Color.Transparent;
            this.PbxDestroy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxDestroy.Image = ((System.Drawing.Image)(resources.GetObject("PbxDestroy.Image")));
            this.PbxDestroy.Location = new System.Drawing.Point(712, 282);
            this.PbxDestroy.Name = "PbxDestroy";
            this.PbxDestroy.Size = new System.Drawing.Size(26, 27);
            this.PbxDestroy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxDestroy.TabIndex = 86;
            this.PbxDestroy.TabStop = false;
            this.TtpDestroy.SetToolTip(this.PbxDestroy, "Destruir registro definitivamente de la base de datos");
            this.PbxDestroy.Visible = false;
            this.PbxDestroy.Click += new System.EventHandler(this.PbxDestroy_Click);
            // 
            // TtpDestroy
            // 
            this.TtpDestroy.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TtpDestroy.ToolTipTitle = "Destruir";
            // 
            // TtpRecovery
            // 
            this.TtpRecovery.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TtpRecovery.ToolTipTitle = "Recuperar ";
            // 
            // PbxPrint
            // 
            this.PbxPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxPrint.BackColor = System.Drawing.Color.Transparent;
            this.PbxPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxPrint.Image = ((System.Drawing.Image)(resources.GetObject("PbxPrint.Image")));
            this.PbxPrint.Location = new System.Drawing.Point(745, 282);
            this.PbxPrint.Name = "PbxPrint";
            this.PbxPrint.Size = new System.Drawing.Size(26, 27);
            this.PbxPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxPrint.TabIndex = 110;
            this.PbxPrint.TabStop = false;
            this.TlpGenerateRpt.SetToolTip(this.PbxPrint, "Generar reporte de empleados");
            this.PbxPrint.Click += new System.EventHandler(this.PbxPrint_Click);
            // 
            // TlpGenerateRpt
            // 
            this.TlpGenerateRpt.ToolTipTitle = "Generar reporte";
            // 
            // TlpSelectRow
            // 
            this.TlpSelectRow.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TlpSelectRow.ToolTipTitle = "Seleccionar";
            // 
            // FrmEmployees
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(852, 588);
            this.Controls.Add(this.PbxPrint);
            this.Controls.Add(this.PbxDestroy);
            this.Controls.Add(this.PbxRecovery);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmbHorary);
            this.Controls.Add(this.MskPhoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.DgvEmployees);
            this.Controls.Add(this.PbxSearch);
            this.Controls.Add(this.PbxCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.CmbJobPosition);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtEmployeeName);
            this.Controls.Add(this.TxtDni);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TxtEmployeeCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEmployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEmployees";
            this.Load += new System.EventHandler(this.FrmEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxRecovery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDestroy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvEmployees;
        private System.Windows.Forms.PictureBox PbxSearch;
        private System.Windows.Forms.PictureBox PbxCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.ComboBox CmbJobPosition;
        private System.Windows.Forms.TextBox TxtEmployeeName;
        private System.Windows.Forms.TextBox TxtDni;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TextBox TxtEmployeeCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox MskPhoneNumber;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbHorary;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.ToolStripButton BtnPaperbin;
        private System.Windows.Forms.PictureBox PbxRecovery;
        private System.Windows.Forms.PictureBox PbxDestroy;
        private System.Windows.Forms.ToolTip TtpDestroy;
        private System.Windows.Forms.ToolTip TtpRecovery;
        private System.Windows.Forms.PictureBox PbxPrint;
        private System.Windows.Forms.ToolTip TlpGenerateRpt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDENTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HORARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGISTRO;
        private System.Windows.Forms.ToolTip TlpSelectRow;
    }
}