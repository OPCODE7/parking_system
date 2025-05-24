namespace parking.Views.Administration.ParkingStructure
{
    partial class FrmCheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckOut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSearchCheckIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnGenerateBill = new System.Windows.Forms.ToolStripButton();
            this.TspBill = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPaperbin = new System.Windows.Forms.ToolStripButton();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCheckInCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPriceParkingFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtParkingType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtVehiclePlate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtISV = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DtpCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.DtpCheckOutTime = new System.Windows.Forms.DateTimePicker();
            this.PbxSearch = new System.Windows.Forms.PictureBox();
            this.PbxCancel = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.DgvCheckOuts = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLACA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMEROPARQUEO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_PARQUEO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAYHORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.TxtTotalTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtSubtotal = new System.Windows.Forms.TextBox();
            this.PbxDestroy = new System.Windows.Forms.PictureBox();
            this.PbxRecovery = new System.Windows.Forms.PictureBox();
            this.TtpRecovery = new System.Windows.Forms.ToolTip(this.components);
            this.TtpDestroy = new System.Windows.Forms.ToolTip(this.components);
            this.TlpSelectRow = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckOuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDestroy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxRecovery)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(912, 8);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 127;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnDelete,
            this.toolStripSeparator3,
            this.BtnSave,
            this.toolStripSeparator6,
            this.BtnCancel,
            this.toolStripSeparator5,
            this.BtnSearchCheckIn,
            this.toolStripSeparator4,
            this.BtnGenerateBill,
            this.TspBill,
            this.BtnPaperbin});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(946, 42);
            this.toolStrip1.TabIndex = 126;
            this.toolStrip1.Text = "toolStrip1";
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
            this.BtnSave.Size = new System.Drawing.Size(184, 37);
            this.BtnSave.Text = "Guardar y Facturar";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 42);
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
            // BtnSearchCheckIn
            // 
            this.BtnSearchCheckIn.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchCheckIn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSearchCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCheckIn.Image")));
            this.BtnSearchCheckIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSearchCheckIn.Name = "BtnSearchCheckIn";
            this.BtnSearchCheckIn.Size = new System.Drawing.Size(152, 37);
            this.BtnSearchCheckIn.Text = "Buscar Entrada";
            this.BtnSearchCheckIn.Click += new System.EventHandler(this.BtnSearchCheckIn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // BtnGenerateBill
            // 
            this.BtnGenerateBill.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerateBill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnGenerateBill.Image = ((System.Drawing.Image)(resources.GetObject("BtnGenerateBill.Image")));
            this.BtnGenerateBill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGenerateBill.Name = "BtnGenerateBill";
            this.BtnGenerateBill.Size = new System.Drawing.Size(101, 37);
            this.BtnGenerateBill.Text = "Facturar";
            this.BtnGenerateBill.Click += new System.EventHandler(this.BtnGenerateBill_Click);
            // 
            // TspBill
            // 
            this.TspBill.Name = "TspBill";
            this.TspBill.Size = new System.Drawing.Size(6, 42);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label9.Location = new System.Drawing.Point(228, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 22);
            this.label9.TabIndex = 146;
            this.label9.Text = "Nombre cliente:";
            // 
            // TxtClientName
            // 
            this.TxtClientName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtClientName.Location = new System.Drawing.Point(232, 87);
            this.TxtClientName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClientName.Multiline = true;
            this.TxtClientName.Name = "TxtClientName";
            this.TxtClientName.ReadOnly = true;
            this.TxtClientName.Size = new System.Drawing.Size(211, 30);
            this.TxtClientName.TabIndex = 145;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(26, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 22);
            this.label1.TabIndex = 142;
            this.label1.Text = "Código Entrada:";
            // 
            // TxtCheckInCode
            // 
            this.TxtCheckInCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCheckInCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCheckInCode.Enabled = false;
            this.TxtCheckInCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtCheckInCode.Location = new System.Drawing.Point(30, 87);
            this.TxtCheckInCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCheckInCode.Multiline = true;
            this.TxtCheckInCode.Name = "TxtCheckInCode";
            this.TxtCheckInCode.ReadOnly = true;
            this.TxtCheckInCode.Size = new System.Drawing.Size(176, 30);
            this.TxtCheckInCode.TabIndex = 141;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(698, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 22);
            this.label3.TabIndex = 148;
            this.label3.Text = "Coste Tarifa:";
            // 
            // TxtPriceParkingFee
            // 
            this.TxtPriceParkingFee.BackColor = System.Drawing.SystemColors.Control;
            this.TxtPriceParkingFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPriceParkingFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtPriceParkingFee.Location = new System.Drawing.Point(702, 87);
            this.TxtPriceParkingFee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtPriceParkingFee.Multiline = true;
            this.TxtPriceParkingFee.Name = "TxtPriceParkingFee";
            this.TxtPriceParkingFee.ReadOnly = true;
            this.TxtPriceParkingFee.Size = new System.Drawing.Size(211, 30);
            this.TxtPriceParkingFee.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(464, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 22);
            this.label4.TabIndex = 150;
            this.label4.Text = "Tipo parqueo:";
            // 
            // TxtParkingType
            // 
            this.TxtParkingType.BackColor = System.Drawing.SystemColors.Control;
            this.TxtParkingType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtParkingType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtParkingType.Location = new System.Drawing.Point(468, 87);
            this.TxtParkingType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtParkingType.Multiline = true;
            this.TxtParkingType.Name = "TxtParkingType";
            this.TxtParkingType.ReadOnly = true;
            this.TxtParkingType.Size = new System.Drawing.Size(211, 30);
            this.TxtParkingType.TabIndex = 149;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(25, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 22);
            this.label5.TabIndex = 152;
            this.label5.Text = "Placa del vehículo:";
            // 
            // TxtVehiclePlate
            // 
            this.TxtVehiclePlate.BackColor = System.Drawing.SystemColors.Control;
            this.TxtVehiclePlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVehiclePlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtVehiclePlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtVehiclePlate.Location = new System.Drawing.Point(29, 172);
            this.TxtVehiclePlate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtVehiclePlate.Multiline = true;
            this.TxtVehiclePlate.Name = "TxtVehiclePlate";
            this.TxtVehiclePlate.ReadOnly = true;
            this.TxtVehiclePlate.Size = new System.Drawing.Size(176, 30);
            this.TxtVehiclePlate.TabIndex = 151;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(227, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 22);
            this.label6.TabIndex = 154;
            this.label6.Text = "Hora y fecha entrada:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(463, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 22);
            this.label7.TabIndex = 156;
            this.label7.Text = "Hora y fecha salida:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(463, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 22);
            this.label8.TabIndex = 158;
            this.label8.Text = "ISV";
            // 
            // TxtISV
            // 
            this.TxtISV.BackColor = System.Drawing.SystemColors.Control;
            this.TxtISV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtISV.Enabled = false;
            this.TxtISV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtISV.Location = new System.Drawing.Point(467, 250);
            this.TxtISV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtISV.Multiline = true;
            this.TxtISV.Name = "TxtISV";
            this.TxtISV.ReadOnly = true;
            this.TxtISV.Size = new System.Drawing.Size(211, 30);
            this.TxtISV.TabIndex = 157;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label10.Location = new System.Drawing.Point(227, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 22);
            this.label10.TabIndex = 160;
            this.label10.Text = "Total Descuento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label12.Location = new System.Drawing.Point(697, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 22);
            this.label12.TabIndex = 164;
            this.label12.Text = "Total";
            // 
            // TxtTotal
            // 
            this.TxtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotal.Enabled = false;
            this.TxtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtTotal.Location = new System.Drawing.Point(702, 250);
            this.TxtTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTotal.Multiline = true;
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(211, 30);
            this.TxtTotal.TabIndex = 163;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label13.Location = new System.Drawing.Point(697, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 22);
            this.label13.TabIndex = 166;
            this.label13.Text = "Tiempo total:";
            // 
            // DtpCheckInTime
            // 
            this.DtpCheckInTime.Enabled = false;
            this.DtpCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCheckInTime.Location = new System.Drawing.Point(231, 176);
            this.DtpCheckInTime.Name = "DtpCheckInTime";
            this.DtpCheckInTime.Size = new System.Drawing.Size(211, 26);
            this.DtpCheckInTime.TabIndex = 167;
            // 
            // DtpCheckOutTime
            // 
            this.DtpCheckOutTime.Enabled = false;
            this.DtpCheckOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCheckOutTime.Location = new System.Drawing.Point(467, 176);
            this.DtpCheckOutTime.Name = "DtpCheckOutTime";
            this.DtpCheckOutTime.Size = new System.Drawing.Size(211, 26);
            this.DtpCheckOutTime.TabIndex = 168;
            // 
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(854, 312);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(26, 27);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxSearch.TabIndex = 174;
            this.PbxSearch.TabStop = false;
            this.PbxSearch.Click += new System.EventHandler(this.PbxSearch_Click);
            // 
            // PbxCancel
            // 
            this.PbxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxCancel.BackColor = System.Drawing.Color.Transparent;
            this.PbxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxCancel.Image = ((System.Drawing.Image)(resources.GetObject("PbxCancel.Image")));
            this.PbxCancel.Location = new System.Drawing.Point(887, 312);
            this.PbxCancel.Name = "PbxCancel";
            this.PbxCancel.Size = new System.Drawing.Size(26, 27);
            this.PbxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxCancel.TabIndex = 173;
            this.PbxCancel.TabStop = false;
            this.PbxCancel.Click += new System.EventHandler(this.PbxCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(29, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 172;
            this.label2.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSearch.Location = new System.Drawing.Point(114, 311);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(471, 26);
            this.TxtSearch.TabIndex = 170;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // DgvCheckOuts
            // 
            this.DgvCheckOuts.AllowUserToAddRows = false;
            this.DgvCheckOuts.AllowUserToDeleteRows = false;
            this.DgvCheckOuts.AllowUserToResizeColumns = false;
            this.DgvCheckOuts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvCheckOuts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCheckOuts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DgvCheckOuts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCheckOuts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PLACA,
            this.NUMEROPARQUEO,
            this.TIPO_PARQUEO,
            this.FECHAYHORA,
            this.ESTADO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCheckOuts.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCheckOuts.Location = new System.Drawing.Point(30, 350);
            this.DgvCheckOuts.Name = "DgvCheckOuts";
            this.DgvCheckOuts.ReadOnly = true;
            this.DgvCheckOuts.RowHeadersVisible = false;
            this.DgvCheckOuts.RowHeadersWidth = 62;
            this.DgvCheckOuts.RowTemplate.Height = 28;
            this.DgvCheckOuts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCheckOuts.Size = new System.Drawing.Size(883, 313);
            this.DgvCheckOuts.TabIndex = 171;
            this.TlpSelectRow.SetToolTip(this.DgvCheckOuts, "Doble click para seleccionar registro.");
            this.DgvCheckOuts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCheckOuts_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 110;
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
            this.NUMEROPARQUEO.Width = 150;
            // 
            // TIPO_PARQUEO
            // 
            this.TIPO_PARQUEO.HeaderText = "TIPO DE PARQUEO";
            this.TIPO_PARQUEO.MinimumWidth = 8;
            this.TIPO_PARQUEO.Name = "TIPO_PARQUEO";
            this.TIPO_PARQUEO.ReadOnly = true;
            this.TIPO_PARQUEO.Width = 220;
            // 
            // FECHAYHORA
            // 
            this.FECHAYHORA.HeaderText = "FECHA Y HORA";
            this.FECHAYHORA.MinimumWidth = 8;
            this.FECHAYHORA.Name = "FECHAYHORA";
            this.FECHAYHORA.ReadOnly = true;
            this.FECHAYHORA.Width = 150;
            // 
            // ESTADO
            // 
            this.ESTADO.HeaderText = "ESTADO";
            this.ESTADO.MinimumWidth = 8;
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            this.ESTADO.Width = 120;
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDiscount.Location = new System.Drawing.Point(231, 250);
            this.TxtDiscount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDiscount.Multiline = true;
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.ReadOnly = true;
            this.TxtDiscount.Size = new System.Drawing.Size(211, 30);
            this.TxtDiscount.TabIndex = 159;
            // 
            // TxtTotalTime
            // 
            this.TxtTotalTime.BackColor = System.Drawing.SystemColors.Control;
            this.TxtTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotalTime.Enabled = false;
            this.TxtTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtTotalTime.Location = new System.Drawing.Point(702, 168);
            this.TxtTotalTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTotalTime.Multiline = true;
            this.TxtTotalTime.Name = "TxtTotalTime";
            this.TxtTotalTime.ReadOnly = true;
            this.TxtTotalTime.Size = new System.Drawing.Size(211, 30);
            this.TxtTotalTime.TabIndex = 175;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label11.Location = new System.Drawing.Point(25, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 22);
            this.label11.TabIndex = 177;
            this.label11.Text = "Subtotal";
            // 
            // TxtSubtotal
            // 
            this.TxtSubtotal.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSubtotal.Enabled = false;
            this.TxtSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSubtotal.Location = new System.Drawing.Point(29, 250);
            this.TxtSubtotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSubtotal.Multiline = true;
            this.TxtSubtotal.Name = "TxtSubtotal";
            this.TxtSubtotal.ReadOnly = true;
            this.TxtSubtotal.Size = new System.Drawing.Size(177, 30);
            this.TxtSubtotal.TabIndex = 176;
            // 
            // PbxDestroy
            // 
            this.PbxDestroy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxDestroy.BackColor = System.Drawing.Color.Transparent;
            this.PbxDestroy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxDestroy.Image = ((System.Drawing.Image)(resources.GetObject("PbxDestroy.Image")));
            this.PbxDestroy.Location = new System.Drawing.Point(821, 312);
            this.PbxDestroy.Name = "PbxDestroy";
            this.PbxDestroy.Size = new System.Drawing.Size(26, 27);
            this.PbxDestroy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxDestroy.TabIndex = 179;
            this.PbxDestroy.TabStop = false;
            this.TtpDestroy.SetToolTip(this.PbxDestroy, "Destruir registro definitivamente de la base de datos");
            this.PbxDestroy.Visible = false;
            this.PbxDestroy.Click += new System.EventHandler(this.PbxDestroy_Click);
            // 
            // PbxRecovery
            // 
            this.PbxRecovery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxRecovery.BackColor = System.Drawing.Color.Transparent;
            this.PbxRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxRecovery.Image = ((System.Drawing.Image)(resources.GetObject("PbxRecovery.Image")));
            this.PbxRecovery.Location = new System.Drawing.Point(785, 312);
            this.PbxRecovery.Name = "PbxRecovery";
            this.PbxRecovery.Size = new System.Drawing.Size(26, 27);
            this.PbxRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxRecovery.TabIndex = 178;
            this.PbxRecovery.TabStop = false;
            this.TtpRecovery.SetToolTip(this.PbxRecovery, "Recuperar registro de la papelera");
            this.PbxRecovery.Visible = false;
            this.PbxRecovery.Click += new System.EventHandler(this.PbxRecovery_Click);
            // 
            // TtpRecovery
            // 
            this.TtpRecovery.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TtpRecovery.ToolTipTitle = "Recuperar ";
            // 
            // TtpDestroy
            // 
            this.TtpDestroy.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TtpDestroy.ToolTipTitle = "Destruir";
            // 
            // TlpSelectRow
            // 
            this.TlpSelectRow.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TlpSelectRow.ToolTipTitle = "Seleccionar";
            // 
            // FrmCheckOut
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(946, 675);
            this.Controls.Add(this.PbxDestroy);
            this.Controls.Add(this.PbxRecovery);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtSubtotal);
            this.Controls.Add(this.TxtTotalTime);
            this.Controls.Add(this.PbxSearch);
            this.Controls.Add(this.PbxCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.DgvCheckOuts);
            this.Controls.Add(this.DtpCheckOutTime);
            this.Controls.Add(this.DtpCheckInTime);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtDiscount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtISV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtVehiclePlate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtParkingType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPriceParkingFee);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtClientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCheckInCode);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCheckOut";
            this.Load += new System.EventHandler(this.FrmCheckOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckOuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDestroy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxRecovery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCheckInCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPriceParkingFee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtParkingType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtVehiclePlate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtISV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DtpCheckInTime;
        private System.Windows.Forms.DateTimePicker DtpCheckOutTime;
        private System.Windows.Forms.PictureBox PbxSearch;
        private System.Windows.Forms.PictureBox PbxCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.DataGridView DgvCheckOuts;
        private System.Windows.Forms.TextBox TxtDiscount;
        private System.Windows.Forms.TextBox TxtTotalTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtSubtotal;
        private System.Windows.Forms.ToolStripButton BtnSearchCheckIn;
        public System.Windows.Forms.ToolStripButton BtnGenerateBill;
        private System.Windows.Forms.PictureBox PbxDestroy;
        private System.Windows.Forms.PictureBox PbxRecovery;
        private System.Windows.Forms.ToolTip TtpRecovery;
        private System.Windows.Forms.ToolTip TtpDestroy;
        private System.Windows.Forms.ToolStripSeparator TspBill;
        private System.Windows.Forms.ToolStripButton BtnPaperbin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLACA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMEROPARQUEO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PARQUEO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAYHORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
        private System.Windows.Forms.ToolTip TlpSelectRow;
    }
}