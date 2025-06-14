namespace parking.Views.Administration.BillingModule
{
    partial class FrmGenerateBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerateBill));
            this.PbxClose = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnGenerateBill = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtClientName = new System.Windows.Forms.TextBox();
            this.LblFullCharge = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.TxtParkingFee = new System.Windows.Forms.TextBox();
            this.TxtSubtotal = new System.Windows.Forms.TextBox();
            this.TxtCheckOutDate = new System.Windows.Forms.TextBox();
            this.TxtParkingNumber = new System.Windows.Forms.TextBox();
            this.TxtRTN = new System.Windows.Forms.TextBox();
            this.TxtISV = new System.Windows.Forms.TextBox();
            this.TxtTotalHours = new System.Windows.Forms.TextBox();
            this.TxtParkingType = new System.Windows.Forms.TextBox();
            this.TxtCheckInDate = new System.Windows.Forms.TextBox();
            this.TxtVehiclePlate = new System.Windows.Forms.TextBox();
            this.TxtCheckOutCode = new System.Windows.Forms.TextBox();
            this.TxtClientCode = new System.Windows.Forms.TextBox();
            this.GbxAutomaticDiscounts = new System.Windows.Forms.GroupBox();
            this.GbxOptionalDiscounts = new System.Windows.Forms.GroupBox();
            this.ChkClientFrequently = new System.Windows.Forms.CheckBox();
            this.ChkLengthOfStay = new System.Windows.Forms.CheckBox();
            this.ChkClaim = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.GbxAutomaticDiscounts.SuspendLayout();
            this.GbxOptionalDiscounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.Transparent;
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(802, 5);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 128;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GbxOptionalDiscounts);
            this.groupBox1.Controls.Add(this.GbxAutomaticDiscounts);
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.BtnGenerateBill);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TxtClientName);
            this.groupBox1.Controls.Add(this.LblFullCharge);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtDiscount);
            this.groupBox1.Controls.Add(this.TxtParkingFee);
            this.groupBox1.Controls.Add(this.TxtSubtotal);
            this.groupBox1.Controls.Add(this.TxtCheckOutDate);
            this.groupBox1.Controls.Add(this.TxtParkingNumber);
            this.groupBox1.Controls.Add(this.TxtRTN);
            this.groupBox1.Controls.Add(this.TxtISV);
            this.groupBox1.Controls.Add(this.TxtTotalHours);
            this.groupBox1.Controls.Add(this.TxtParkingType);
            this.groupBox1.Controls.Add(this.TxtCheckInDate);
            this.groupBox1.Controls.Add(this.TxtVehiclePlate);
            this.groupBox1.Controls.Add(this.TxtCheckOutCode);
            this.groupBox1.Controls.Add(this.TxtClientCode);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 624);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Facturación";
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Crimson;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancel.Location = new System.Drawing.Point(412, 544);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(185, 46);
            this.BtnCancel.TabIndex = 170;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnGenerateBill
            // 
            this.BtnGenerateBill.BackColor = System.Drawing.Color.Teal;
            this.BtnGenerateBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGenerateBill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnGenerateBill.Location = new System.Drawing.Point(207, 544);
            this.BtnGenerateBill.Name = "BtnGenerateBill";
            this.BtnGenerateBill.Size = new System.Drawing.Size(185, 46);
            this.BtnGenerateBill.TabIndex = 169;
            this.BtnGenerateBill.Text = "Generar Factura";
            this.BtnGenerateBill.UseVisualStyleBackColor = false;
            this.BtnGenerateBill.Click += new System.EventHandler(this.BtnGenerateBill_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label11.Location = new System.Drawing.Point(408, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 22);
            this.label11.TabIndex = 168;
            this.label11.Text = "Nombre Cliente:";
            // 
            // TxtClientName
            // 
            this.TxtClientName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClientName.Enabled = false;
            this.TxtClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtClientName.Location = new System.Drawing.Point(412, 71);
            this.TxtClientName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClientName.Multiline = true;
            this.TxtClientName.Name = "TxtClientName";
            this.TxtClientName.ReadOnly = true;
            this.TxtClientName.Size = new System.Drawing.Size(390, 36);
            this.TxtClientName.TabIndex = 167;
            // 
            // LblFullCharge
            // 
            this.LblFullCharge.AutoSize = true;
            this.LblFullCharge.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFullCharge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.LblFullCharge.Location = new System.Drawing.Point(19, 509);
            this.LblFullCharge.Name = "LblFullCharge";
            this.LblFullCharge.Size = new System.Drawing.Size(137, 22);
            this.LblFullCharge.TabIndex = 166;
            this.LblFullCharge.Text = "Total a pagar: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label8.Location = new System.Drawing.Point(153, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 22);
            this.label8.TabIndex = 165;
            this.label8.Text = "Descuento:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label15.Location = new System.Drawing.Point(607, 205);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 22);
            this.label15.TabIndex = 164;
            this.label15.Text = "Subtotal:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(408, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 22);
            this.label6.TabIndex = 164;
            this.label6.Text = "Tarifa aplicada:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label13.Location = new System.Drawing.Point(209, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 22);
            this.label13.TabIndex = 163;
            this.label13.Text = "Salida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label4.Location = new System.Drawing.Point(209, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 22);
            this.label4.TabIndex = 163;
            this.label4.Text = "Número parqueo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label2.Location = new System.Drawing.Point(209, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 162;
            this.label2.Text = "RTN:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label9.Location = new System.Drawing.Point(302, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 22);
            this.label9.TabIndex = 160;
            this.label9.Text = "ISV:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label7.Location = new System.Drawing.Point(11, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 22);
            this.label7.TabIndex = 159;
            this.label7.Text = "Total Horas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label5.Location = new System.Drawing.Point(607, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 22);
            this.label5.TabIndex = 158;
            this.label5.Text = "Tipo parqueo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label12.Location = new System.Drawing.Point(10, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 22);
            this.label12.TabIndex = 161;
            this.label12.Text = "Ingreso:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label14.Location = new System.Drawing.Point(408, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 22);
            this.label14.TabIndex = 161;
            this.label14.Text = "Placa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label3.Location = new System.Drawing.Point(10, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 22);
            this.label3.TabIndex = 161;
            this.label3.Text = "Código Salida:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 22);
            this.label1.TabIndex = 157;
            this.label1.Text = "Código Cliente:";
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.BackColor = System.Drawing.SystemColors.Control;
            this.TxtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDiscount.Enabled = false;
            this.TxtDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtDiscount.Location = new System.Drawing.Point(157, 316);
            this.TxtDiscount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDiscount.Multiline = true;
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.Size = new System.Drawing.Size(129, 41);
            this.TxtDiscount.TabIndex = 154;
            this.TxtDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDiscount_KeyUp);
            // 
            // TxtParkingFee
            // 
            this.TxtParkingFee.BackColor = System.Drawing.SystemColors.Control;
            this.TxtParkingFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtParkingFee.Enabled = false;
            this.TxtParkingFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtParkingFee.Location = new System.Drawing.Point(412, 236);
            this.TxtParkingFee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtParkingFee.Multiline = true;
            this.TxtParkingFee.Name = "TxtParkingFee";
            this.TxtParkingFee.ReadOnly = true;
            this.TxtParkingFee.Size = new System.Drawing.Size(191, 36);
            this.TxtParkingFee.TabIndex = 153;
            // 
            // TxtSubtotal
            // 
            this.TxtSubtotal.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSubtotal.Enabled = false;
            this.TxtSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSubtotal.Location = new System.Drawing.Point(611, 236);
            this.TxtSubtotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSubtotal.Multiline = true;
            this.TxtSubtotal.Name = "TxtSubtotal";
            this.TxtSubtotal.ReadOnly = true;
            this.TxtSubtotal.Size = new System.Drawing.Size(191, 36);
            this.TxtSubtotal.TabIndex = 153;
            // 
            // TxtCheckOutDate
            // 
            this.TxtCheckOutDate.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCheckOutDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCheckOutDate.Enabled = false;
            this.TxtCheckOutDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtCheckOutDate.Location = new System.Drawing.Point(213, 236);
            this.TxtCheckOutDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCheckOutDate.Multiline = true;
            this.TxtCheckOutDate.Name = "TxtCheckOutDate";
            this.TxtCheckOutDate.ReadOnly = true;
            this.TxtCheckOutDate.Size = new System.Drawing.Size(191, 36);
            this.TxtCheckOutDate.TabIndex = 152;
            // 
            // TxtParkingNumber
            // 
            this.TxtParkingNumber.BackColor = System.Drawing.SystemColors.Control;
            this.TxtParkingNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtParkingNumber.Enabled = false;
            this.TxtParkingNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtParkingNumber.Location = new System.Drawing.Point(213, 153);
            this.TxtParkingNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtParkingNumber.Multiline = true;
            this.TxtParkingNumber.Name = "TxtParkingNumber";
            this.TxtParkingNumber.ReadOnly = true;
            this.TxtParkingNumber.Size = new System.Drawing.Size(191, 36);
            this.TxtParkingNumber.TabIndex = 152;
            // 
            // TxtRTN
            // 
            this.TxtRTN.BackColor = System.Drawing.SystemColors.Control;
            this.TxtRTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtRTN.Location = new System.Drawing.Point(213, 71);
            this.TxtRTN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtRTN.MaxLength = 14;
            this.TxtRTN.Multiline = true;
            this.TxtRTN.Name = "TxtRTN";
            this.TxtRTN.Size = new System.Drawing.Size(191, 36);
            this.TxtRTN.TabIndex = 151;
            // 
            // TxtISV
            // 
            this.TxtISV.BackColor = System.Drawing.SystemColors.Control;
            this.TxtISV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtISV.Enabled = false;
            this.TxtISV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtISV.Location = new System.Drawing.Point(306, 316);
            this.TxtISV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtISV.Multiline = true;
            this.TxtISV.Name = "TxtISV";
            this.TxtISV.ReadOnly = true;
            this.TxtISV.Size = new System.Drawing.Size(129, 41);
            this.TxtISV.TabIndex = 150;
            // 
            // TxtTotalHours
            // 
            this.TxtTotalHours.BackColor = System.Drawing.SystemColors.Control;
            this.TxtTotalHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTotalHours.Enabled = false;
            this.TxtTotalHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtTotalHours.Location = new System.Drawing.Point(15, 316);
            this.TxtTotalHours.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTotalHours.Multiline = true;
            this.TxtTotalHours.Name = "TxtTotalHours";
            this.TxtTotalHours.ReadOnly = true;
            this.TxtTotalHours.Size = new System.Drawing.Size(129, 41);
            this.TxtTotalHours.TabIndex = 149;
            // 
            // TxtParkingType
            // 
            this.TxtParkingType.BackColor = System.Drawing.SystemColors.Control;
            this.TxtParkingType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtParkingType.Enabled = false;
            this.TxtParkingType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtParkingType.Location = new System.Drawing.Point(611, 153);
            this.TxtParkingType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtParkingType.Multiline = true;
            this.TxtParkingType.Name = "TxtParkingType";
            this.TxtParkingType.ReadOnly = true;
            this.TxtParkingType.Size = new System.Drawing.Size(191, 36);
            this.TxtParkingType.TabIndex = 148;
            // 
            // TxtCheckInDate
            // 
            this.TxtCheckInDate.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCheckInDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCheckInDate.Enabled = false;
            this.TxtCheckInDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtCheckInDate.Location = new System.Drawing.Point(14, 236);
            this.TxtCheckInDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCheckInDate.Multiline = true;
            this.TxtCheckInDate.Name = "TxtCheckInDate";
            this.TxtCheckInDate.ReadOnly = true;
            this.TxtCheckInDate.Size = new System.Drawing.Size(191, 36);
            this.TxtCheckInDate.TabIndex = 156;
            // 
            // TxtVehiclePlate
            // 
            this.TxtVehiclePlate.BackColor = System.Drawing.SystemColors.Control;
            this.TxtVehiclePlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVehiclePlate.Enabled = false;
            this.TxtVehiclePlate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtVehiclePlate.Location = new System.Drawing.Point(412, 153);
            this.TxtVehiclePlate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtVehiclePlate.Multiline = true;
            this.TxtVehiclePlate.Name = "TxtVehiclePlate";
            this.TxtVehiclePlate.ReadOnly = true;
            this.TxtVehiclePlate.Size = new System.Drawing.Size(191, 36);
            this.TxtVehiclePlate.TabIndex = 156;
            // 
            // TxtCheckOutCode
            // 
            this.TxtCheckOutCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCheckOutCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCheckOutCode.Enabled = false;
            this.TxtCheckOutCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtCheckOutCode.Location = new System.Drawing.Point(14, 153);
            this.TxtCheckOutCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtCheckOutCode.Multiline = true;
            this.TxtCheckOutCode.Name = "TxtCheckOutCode";
            this.TxtCheckOutCode.ReadOnly = true;
            this.TxtCheckOutCode.Size = new System.Drawing.Size(191, 36);
            this.TxtCheckOutCode.TabIndex = 156;
            // 
            // TxtClientCode
            // 
            this.TxtClientCode.BackColor = System.Drawing.SystemColors.Control;
            this.TxtClientCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClientCode.Enabled = false;
            this.TxtClientCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtClientCode.Location = new System.Drawing.Point(14, 71);
            this.TxtClientCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClientCode.Multiline = true;
            this.TxtClientCode.Name = "TxtClientCode";
            this.TxtClientCode.ReadOnly = true;
            this.TxtClientCode.Size = new System.Drawing.Size(191, 36);
            this.TxtClientCode.TabIndex = 147;
            // 
            // GbxAutomaticDiscounts
            // 
            this.GbxAutomaticDiscounts.Controls.Add(this.ChkLengthOfStay);
            this.GbxAutomaticDiscounts.Controls.Add(this.ChkClientFrequently);
            this.GbxAutomaticDiscounts.Location = new System.Drawing.Point(15, 375);
            this.GbxAutomaticDiscounts.Name = "GbxAutomaticDiscounts";
            this.GbxAutomaticDiscounts.Size = new System.Drawing.Size(399, 107);
            this.GbxAutomaticDiscounts.TabIndex = 171;
            this.GbxAutomaticDiscounts.TabStop = false;
            this.GbxAutomaticDiscounts.Text = "Descuentos aplicados automáticamente:";
            // 
            // GbxOptionalDiscounts
            // 
            this.GbxOptionalDiscounts.Controls.Add(this.ChkClaim);
            this.GbxOptionalDiscounts.Location = new System.Drawing.Point(433, 375);
            this.GbxOptionalDiscounts.Name = "GbxOptionalDiscounts";
            this.GbxOptionalDiscounts.Size = new System.Drawing.Size(369, 107);
            this.GbxOptionalDiscounts.TabIndex = 172;
            this.GbxOptionalDiscounts.TabStop = false;
            this.GbxOptionalDiscounts.Text = "Descuentos opcionales:";
            // 
            // ChkClientFrequently
            // 
            this.ChkClientFrequently.AutoSize = true;
            this.ChkClientFrequently.Enabled = false;
            this.ChkClientFrequently.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.ChkClientFrequently.Location = new System.Drawing.Point(13, 34);
            this.ChkClientFrequently.Name = "ChkClientFrequently";
            this.ChkClientFrequently.Size = new System.Drawing.Size(193, 26);
            this.ChkClientFrequently.TabIndex = 164;
            this.ChkClientFrequently.Text = "Cliente Frecuente";
            this.ChkClientFrequently.UseVisualStyleBackColor = true;
            // 
            // ChkLengthOfStay
            // 
            this.ChkLengthOfStay.AutoSize = true;
            this.ChkLengthOfStay.Enabled = false;
            this.ChkLengthOfStay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.ChkLengthOfStay.Location = new System.Drawing.Point(13, 67);
            this.ChkLengthOfStay.Name = "ChkLengthOfStay";
            this.ChkLengthOfStay.Size = new System.Drawing.Size(200, 26);
            this.ChkLengthOfStay.TabIndex = 165;
            this.ChkLengthOfStay.Text = "Tiempo de estadía";
            this.ChkLengthOfStay.UseVisualStyleBackColor = true;
            // 
            // ChkClaim
            // 
            this.ChkClaim.AutoSize = true;
            this.ChkClaim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.ChkClaim.Location = new System.Drawing.Point(17, 29);
            this.ChkClaim.Name = "ChkClaim";
            this.ChkClaim.Size = new System.Drawing.Size(115, 26);
            this.ChkClaim.TabIndex = 166;
            this.ChkClaim.Text = "Reclamo";
            this.ChkClaim.UseVisualStyleBackColor = true;
            this.ChkClaim.CheckedChanged += new System.EventHandler(this.ChkClaim_CheckedChanged);
            // 
            // FrmGenerateBill
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(835, 680);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PbxClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGenerateBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGenerateBill";
            this.Load += new System.EventHandler(this.FrmGenerateBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GbxAutomaticDiscounts.ResumeLayout(false);
            this.GbxAutomaticDiscounts.PerformLayout();
            this.GbxOptionalDiscounts.ResumeLayout(false);
            this.GbxOptionalDiscounts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRTN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnGenerateBill;
        public System.Windows.Forms.TextBox TxtDiscount;
        public System.Windows.Forms.TextBox TxtSubtotal;
        public System.Windows.Forms.TextBox TxtParkingNumber;
        public System.Windows.Forms.TextBox TxtISV;
        public System.Windows.Forms.TextBox TxtTotalHours;
        public System.Windows.Forms.TextBox TxtParkingType;
        public System.Windows.Forms.TextBox TxtCheckOutCode;
        public System.Windows.Forms.TextBox TxtClientCode;
        public System.Windows.Forms.TextBox TxtClientName;
        public System.Windows.Forms.TextBox TxtCheckOutDate;
        public System.Windows.Forms.TextBox TxtCheckInDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox TxtParkingFee;
        public System.Windows.Forms.TextBox TxtVehiclePlate;
        public System.Windows.Forms.Label LblFullCharge;
        private System.Windows.Forms.CheckBox ChkLengthOfStay;
        private System.Windows.Forms.CheckBox ChkClientFrequently;
        private System.Windows.Forms.CheckBox ChkClaim;
        public System.Windows.Forms.GroupBox GbxAutomaticDiscounts;
        public System.Windows.Forms.GroupBox GbxOptionalDiscounts;
    }
}