namespace parking.Views.Administration.ParkingStructure
{
    partial class FrmCheckIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckIn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbParkingSpaces = new System.Windows.Forms.ComboBox();
            this.PbxClose = new System.Windows.Forms.PictureBox();
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
            this.PbxSearch = new System.Windows.Forms.PictureBox();
            this.PbxCancel = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvCheckIns = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLACA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMEROPARQUEO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_PARQUEO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAYHORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtClientCode = new System.Windows.Forms.TextBox();
            this.TxtCheckInCode = new System.Windows.Forms.TextBox();
            this.PbxSearchClient = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtObservations = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbParkingTypes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtClientName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtVehiclePlate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MskClientPhone = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckIns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearchClient)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(399, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 22);
            this.label4.TabIndex = 128;
            this.label4.Text = "Seleccionar espacio de parqueo:";
            // 
            // CmbParkingSpaces
            // 
            this.CmbParkingSpaces.BackColor = System.Drawing.SystemColors.Control;
            this.CmbParkingSpaces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.CmbParkingSpaces.FormattingEnabled = true;
            this.CmbParkingSpaces.Location = new System.Drawing.Point(402, 165);
            this.CmbParkingSpaces.Name = "CmbParkingSpaces";
            this.CmbParkingSpaces.Size = new System.Drawing.Size(306, 28);
            this.CmbParkingSpaces.TabIndex = 4;
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(910, 7);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 125;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
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
            this.BtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(946, 42);
            this.toolStrip1.TabIndex = 124;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.Image")));
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(115, 37);
            this.BtnNew.Text = "Nuevo[F1]";
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
            this.BtnEdit.Size = new System.Drawing.Size(107, 37);
            this.BtnEdit.Text = "Editar[F2]";
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
            this.BtnDelete.Size = new System.Drawing.Size(126, 37);
            this.BtnDelete.Text = "Eliminar[F3]";
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
            this.BtnSave.Size = new System.Drawing.Size(130, 37);
            this.BtnSave.Text = "Guardar[F4]";
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
            this.BtnCancel.Size = new System.Drawing.Size(137, 37);
            this.BtnCancel.Text = "Cancelar[F5]";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(591, 320);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(31, 30);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxSearch.TabIndex = 123;
            this.PbxSearch.TabStop = false;
            this.PbxSearch.Click += new System.EventHandler(this.PbxSearch_Click);
            // 
            // PbxCancel
            // 
            this.PbxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxCancel.BackColor = System.Drawing.Color.Transparent;
            this.PbxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxCancel.Image = ((System.Drawing.Image)(resources.GetObject("PbxCancel.Image")));
            this.PbxCancel.Location = new System.Drawing.Point(634, 320);
            this.PbxCancel.Name = "PbxCancel";
            this.PbxCancel.Size = new System.Drawing.Size(31, 30);
            this.PbxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxCancel.TabIndex = 122;
            this.PbxCancel.TabStop = false;
            this.PbxCancel.Click += new System.EventHandler(this.PbxCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(23, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 121;
            this.label6.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSearch.Location = new System.Drawing.Point(108, 322);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(471, 26);
            this.TxtSearch.TabIndex = 7;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(212, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 22);
            this.label2.TabIndex = 120;
            this.label2.Text = "Código cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(17, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 119;
            this.label1.Text = "Código:";
            // 
            // DgvCheckIns
            // 
            this.DgvCheckIns.AllowUserToAddRows = false;
            this.DgvCheckIns.AllowUserToDeleteRows = false;
            this.DgvCheckIns.AllowUserToResizeColumns = false;
            this.DgvCheckIns.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvCheckIns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCheckIns.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCheckIns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCheckIns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCheckIns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PLACA,
            this.NUMEROPARQUEO,
            this.CLIENTE,
            this.TIPO_PARQUEO,
            this.FECHAYHORA,
            this.ESTADO});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCheckIns.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvCheckIns.Location = new System.Drawing.Point(24, 357);
            this.DgvCheckIns.Name = "DgvCheckIns";
            this.DgvCheckIns.ReadOnly = true;
            this.DgvCheckIns.RowHeadersVisible = false;
            this.DgvCheckIns.RowHeadersWidth = 62;
            this.DgvCheckIns.RowTemplate.Height = 28;
            this.DgvCheckIns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCheckIns.Size = new System.Drawing.Size(902, 313);
            this.DgvCheckIns.TabIndex = 8;
            this.DgvCheckIns.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCheckIns_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // PLACA
            // 
            this.PLACA.HeaderText = "NO. PLACA";
            this.PLACA.MinimumWidth = 8;
            this.PLACA.Name = "PLACA";
            this.PLACA.ReadOnly = true;
            this.PLACA.Width = 120;
            // 
            // NUMEROPARQUEO
            // 
            this.NUMEROPARQUEO.HeaderText = "NÚMERO DE PARQUEO";
            this.NUMEROPARQUEO.MinimumWidth = 8;
            this.NUMEROPARQUEO.Name = "NUMEROPARQUEO";
            this.NUMEROPARQUEO.ReadOnly = true;
            this.NUMEROPARQUEO.Width = 70;
            // 
            // CLIENTE
            // 
            this.CLIENTE.HeaderText = "CLIENTE";
            this.CLIENTE.MinimumWidth = 8;
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.ReadOnly = true;
            this.CLIENTE.Width = 150;
            // 
            // TIPO_PARQUEO
            // 
            this.TIPO_PARQUEO.HeaderText = "TIPO DE PARQUEO";
            this.TIPO_PARQUEO.MinimumWidth = 8;
            this.TIPO_PARQUEO.Name = "TIPO_PARQUEO";
            this.TIPO_PARQUEO.ReadOnly = true;
            this.TIPO_PARQUEO.Width = 230;
            // 
            // FECHAYHORA
            // 
            this.FECHAYHORA.HeaderText = "FECHA Y HORA";
            this.FECHAYHORA.MinimumWidth = 8;
            this.FECHAYHORA.Name = "FECHAYHORA";
            this.FECHAYHORA.ReadOnly = true;
            this.FECHAYHORA.Width = 120;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "ESTADO";
            this.ESTADO.MinimumWidth = 8;
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            this.ESTADO.Width = 90;
            // 
            // TxtClientCode
            // 
            this.TxtClientCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClientCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtClientCode.Location = new System.Drawing.Point(216, 92);
            this.TxtClientCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClientCode.Multiline = true;
            this.TxtClientCode.Name = "TxtClientCode";
            this.TxtClientCode.Size = new System.Drawing.Size(211, 30);
            this.TxtClientCode.TabIndex = 0;
            this.TxtClientCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtClientCode_KeyDown);
            // 
            // TxtCheckInCode
            // 
            this.TxtCheckInCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCheckInCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCheckInCode.Enabled = false;
            this.TxtCheckInCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtCheckInCode.Location = new System.Drawing.Point(21, 92);
            this.TxtCheckInCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCheckInCode.Multiline = true;
            this.TxtCheckInCode.Name = "TxtCheckInCode";
            this.TxtCheckInCode.ReadOnly = true;
            this.TxtCheckInCode.Size = new System.Drawing.Size(176, 30);
            this.TxtCheckInCode.TabIndex = 117;
            // 
            // PbxSearchClient
            // 
            this.PbxSearchClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearchClient.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearchClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearchClient.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearchClient.Image")));
            this.PbxSearchClient.Location = new System.Drawing.Point(434, 92);
            this.PbxSearchClient.Name = "PbxSearchClient";
            this.PbxSearchClient.Size = new System.Drawing.Size(31, 30);
            this.PbxSearchClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxSearchClient.TabIndex = 129;
            this.PbxSearchClient.TabStop = false;
            this.PbxSearchClient.Click += new System.EventHandler(this.PbxSearchClient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(17, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 22);
            this.label5.TabIndex = 133;
            this.label5.Text = "Observaciones:";
            // 
            // TxtObservations
            // 
            this.TxtObservations.BackColor = System.Drawing.SystemColors.Control;
            this.TxtObservations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtObservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtObservations.Location = new System.Drawing.Point(21, 232);
            this.TxtObservations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtObservations.Multiline = true;
            this.TxtObservations.Name = "TxtObservations";
            this.TxtObservations.Size = new System.Drawing.Size(594, 59);
            this.TxtObservations.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(21, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 22);
            this.label7.TabIndex = 135;
            this.label7.Text = "Seleccionar tipo de parqueo:";
            // 
            // CmbParkingTypes
            // 
            this.CmbParkingTypes.BackColor = System.Drawing.SystemColors.Control;
            this.CmbParkingTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.CmbParkingTypes.FormattingEnabled = true;
            this.CmbParkingTypes.Location = new System.Drawing.Point(24, 165);
            this.CmbParkingTypes.Name = "CmbParkingTypes";
            this.CmbParkingTypes.Size = new System.Drawing.Size(358, 28);
            this.CmbParkingTypes.TabIndex = 3;
            this.CmbParkingTypes.TextChanged += new System.EventHandler(this.CmbParkingTypes_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(723, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 22);
            this.label8.TabIndex = 137;
            this.label8.Text = "Coste tarifa:";
            // 
            // TxtPrice
            // 
            this.TxtPrice.BackColor = System.Drawing.SystemColors.Control;
            this.TxtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPrice.Enabled = false;
            this.TxtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtPrice.Location = new System.Drawing.Point(727, 163);
            this.TxtPrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtPrice.Multiline = true;
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.ReadOnly = true;
            this.TxtPrice.Size = new System.Drawing.Size(197, 30);
            this.TxtPrice.TabIndex = 136;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label9.Location = new System.Drawing.Point(482, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 22);
            this.label9.TabIndex = 139;
            this.label9.Text = "Nombre cliente:";
            // 
            // TxtClientName
            // 
            this.TxtClientName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtClientName.Location = new System.Drawing.Point(486, 92);
            this.TxtClientName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClientName.Multiline = true;
            this.TxtClientName.Name = "TxtClientName";
            this.TxtClientName.ReadOnly = true;
            this.TxtClientName.Size = new System.Drawing.Size(211, 30);
            this.TxtClientName.TabIndex = 138;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label10.Location = new System.Drawing.Point(711, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 22);
            this.label10.TabIndex = 141;
            this.label10.Text = "Teléfono cliente:";
            // 
            // TxtVehiclePlate
            // 
            this.TxtVehiclePlate.BackColor = System.Drawing.SystemColors.Control;
            this.TxtVehiclePlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVehiclePlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtVehiclePlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtVehiclePlate.Location = new System.Drawing.Point(632, 232);
            this.TxtVehiclePlate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtVehiclePlate.MaxLength = 10;
            this.TxtVehiclePlate.Multiline = true;
            this.TxtVehiclePlate.Name = "TxtVehiclePlate";
            this.TxtVehiclePlate.Size = new System.Drawing.Size(292, 30);
            this.TxtVehiclePlate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(628, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 22);
            this.label3.TabIndex = 131;
            this.label3.Text = "Placa del vehículo:";
            // 
            // MskClientPhone
            // 
            this.MskClientPhone.BackColor = System.Drawing.SystemColors.Control;
            this.MskClientPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MskClientPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.MskClientPhone.Location = new System.Drawing.Point(715, 95);
            this.MskClientPhone.Mask = "0000-0000";
            this.MskClientPhone.Name = "MskClientPhone";
            this.MskClientPhone.Size = new System.Drawing.Size(211, 26);
            this.MskClientPhone.TabIndex = 142;
            // 
            // FrmCheckIn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(946, 675);
            this.Controls.Add(this.MskClientPhone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtClientName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbParkingTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtObservations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtVehiclePlate);
            this.Controls.Add(this.PbxSearchClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbParkingSpaces);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PbxSearch);
            this.Controls.Add(this.PbxCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvCheckIns);
            this.Controls.Add(this.TxtClientCode);
            this.Controls.Add(this.TxtCheckInCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCheckIn";
            this.Load += new System.EventHandler(this.FrmCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckIns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearchClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbParkingSpaces;
        private System.Windows.Forms.PictureBox PbxClose;
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
        private System.Windows.Forms.PictureBox PbxSearch;
        private System.Windows.Forms.PictureBox PbxCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvCheckIns;
        private System.Windows.Forms.TextBox TxtClientCode;
        private System.Windows.Forms.TextBox TxtCheckInCode;
        private System.Windows.Forms.PictureBox PbxSearchClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtObservations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbParkingTypes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtClientName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtVehiclePlate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox MskClientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLACA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMEROPARQUEO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PARQUEO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAYHORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
    }
}