namespace parking.Views.Administration.Clients
{
    partial class FrmClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.label1 = new System.Windows.Forms.Label();
            this.DgvClients = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGISTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtClientCode = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.MskPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.TxtDni = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(18, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 22);
            this.label5.TabIndex = 133;
            this.label5.Text = "Nombre:";
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtName.Location = new System.Drawing.Point(22, 154);
            this.TxtName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtName.Multiline = true;
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(262, 30);
            this.TxtName.TabIndex = 1;
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
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(557, 7);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 128;
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
            this.toolStrip1.Size = new System.Drawing.Size(593, 42);
            this.toolStrip1.TabIndex = 127;
            this.toolStrip1.Text = "toolStrip1";
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
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(504, 351);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(31, 30);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxSearch.TabIndex = 126;
            this.PbxSearch.TabStop = false;
            // 
            // PbxCancel
            // 
            this.PbxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxCancel.BackColor = System.Drawing.Color.Transparent;
            this.PbxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxCancel.Image = ((System.Drawing.Image)(resources.GetObject("PbxCancel.Image")));
            this.PbxCancel.Location = new System.Drawing.Point(547, 351);
            this.PbxCancel.Name = "PbxCancel";
            this.PbxCancel.Size = new System.Drawing.Size(31, 30);
            this.PbxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxCancel.TabIndex = 125;
            this.PbxCancel.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(12, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 124;
            this.label6.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSearch.Location = new System.Drawing.Point(97, 352);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(388, 26);
            this.TxtSearch.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 122;
            this.label1.Text = "Código:";
            // 
            // DgvClients
            // 
            this.DgvClients.AllowUserToAddRows = false;
            this.DgvClients.AllowUserToDeleteRows = false;
            this.DgvClients.AllowUserToResizeColumns = false;
            this.DgvClients.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.NOMBRE,
            this.DIRECCION,
            this.TELEFONO,
            this.USUARIO,
            this.REGISTRO});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvClients.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvClients.Location = new System.Drawing.Point(13, 385);
            this.DgvClients.Name = "DgvClients";
            this.DgvClients.ReadOnly = true;
            this.DgvClients.RowHeadersVisible = false;
            this.DgvClients.RowHeadersWidth = 62;
            this.DgvClients.RowTemplate.Height = 28;
            this.DgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvClients.Size = new System.Drawing.Size(568, 305);
            this.DgvClients.TabIndex = 121;
            this.DgvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClients_CellDoubleClick);
            // 
            // CODE
            // 
            this.CODE.HeaderText = "CÓDIGO";
            this.CODE.MinimumWidth = 8;
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.Width = 130;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.MinimumWidth = 8;
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 150;
            // 
            // DIRECCION
            // 
            this.DIRECCION.HeaderText = "DIRECCIÓN";
            this.DIRECCION.MinimumWidth = 8;
            this.DIRECCION.Name = "DIRECCION";
            this.DIRECCION.ReadOnly = true;
            this.DIRECCION.Width = 220;
            // 
            // TELEFONO
            // 
            this.TELEFONO.HeaderText = "TELÉFONO";
            this.TELEFONO.MinimumWidth = 8;
            this.TELEFONO.Name = "TELEFONO";
            this.TELEFONO.ReadOnly = true;
            this.TELEFONO.Width = 150;
            // 
            // USUARIO
            // 
            this.USUARIO.HeaderText = "USUARIO";
            this.USUARIO.MinimumWidth = 8;
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.ReadOnly = true;
            this.USUARIO.Width = 150;
            // 
            // REGISTRO
            // 
            this.REGISTRO.HeaderText = "REGISTRO";
            this.REGISTRO.MinimumWidth = 8;
            this.REGISTRO.Name = "REGISTRO";
            this.REGISTRO.ReadOnly = true;
            this.REGISTRO.Width = 150;
            // 
            // TxtClientCode
            // 
            this.TxtClientCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClientCode.Enabled = false;
            this.TxtClientCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtClientCode.Location = new System.Drawing.Point(19, 85);
            this.TxtClientCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClientCode.Multiline = true;
            this.TxtClientCode.Name = "TxtClientCode";
            this.TxtClientCode.ReadOnly = true;
            this.TxtClientCode.Size = new System.Drawing.Size(265, 30);
            this.TxtClientCode.TabIndex = 120;
            // 
            // TxtLastName
            // 
            this.TxtLastName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtLastName.Location = new System.Drawing.Point(310, 154);
            this.TxtLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtLastName.Multiline = true;
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(265, 30);
            this.TxtLastName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(306, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 133;
            this.label2.Text = "Apellido:";
            // 
            // TxtMail
            // 
            this.TxtMail.BackColor = System.Drawing.SystemColors.Control;
            this.TxtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtMail.Location = new System.Drawing.Point(19, 223);
            this.TxtMail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtMail.Multiline = true;
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(265, 30);
            this.TxtMail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(309, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 22);
            this.label3.TabIndex = 133;
            this.label3.Text = "Teléfono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(13, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 22);
            this.label4.TabIndex = 133;
            this.label4.Text = "Correo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(13, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 22);
            this.label7.TabIndex = 135;
            this.label7.Text = "Dirección:";
            // 
            // TxtAddress
            // 
            this.TxtAddress.BackColor = System.Drawing.SystemColors.Control;
            this.TxtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtAddress.Location = new System.Drawing.Point(17, 293);
            this.TxtAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtAddress.Multiline = true;
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(558, 49);
            this.TxtAddress.TabIndex = 5;
            // 
            // MskPhoneNumber
            // 
            this.MskPhoneNumber.BackColor = System.Drawing.SystemColors.Control;
            this.MskPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MskPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.MskPhoneNumber.Location = new System.Drawing.Point(313, 224);
            this.MskPhoneNumber.Mask = "0000-0000";
            this.MskPhoneNumber.Name = "MskPhoneNumber";
            this.MskPhoneNumber.Size = new System.Drawing.Size(262, 26);
            this.MskPhoneNumber.TabIndex = 4;
            // 
            // TxtDni
            // 
            this.TxtDni.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDni.Enabled = false;
            this.TxtDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDni.Location = new System.Drawing.Point(310, 85);
            this.TxtDni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDni.Multiline = true;
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(265, 30);
            this.TxtDni.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(306, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 22);
            this.label8.TabIndex = 122;
            this.label8.Text = "DNI:";
            // 
            // FrmClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(593, 698);
            this.Controls.Add(this.MskPhoneNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtMail);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PbxSearch);
            this.Controls.Add(this.PbxCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvClients);
            this.Controls.Add(this.TxtDni);
            this.Controls.Add(this.TxtClientCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClient";
            this.Load += new System.EventHandler(this.FrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvClients;
        private System.Windows.Forms.TextBox TxtClientCode;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.MaskedTextBox MskPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGISTRO;
        private System.Windows.Forms.TextBox TxtDni;
        private System.Windows.Forms.Label label8;
    }
}