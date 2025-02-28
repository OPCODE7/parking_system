namespace parking.Views.Administration.Clients
{
    partial class FrmSearchClient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearchClient));
            this.label8 = new System.Windows.Forms.Label();
            this.DgvClients = new System.Windows.Forms.DataGridView();
            this.GrpCriterios = new System.Windows.Forms.GroupBox();
            this.RdbId = new System.Windows.Forms.RadioButton();
            this.RdbClientCode = new System.Windows.Forms.RadioButton();
            this.RdbNombre = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.PbxSearch = new System.Windows.Forms.PictureBox();
            this.PbxCancel = new System.Windows.Forms.PictureBox();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCIDENTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCDIRECCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCTELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbxClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvClients)).BeginInit();
            this.GrpCriterios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label8.Location = new System.Drawing.Point(16, 521);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 22);
            this.label8.TabIndex = 39;
            this.label8.Text = "Doble Click para seleccionar";
            // 
            // DgvClients
            // 
            this.DgvClients.AllowUserToAddRows = false;
            this.DgvClients.AllowUserToDeleteRows = false;
            this.DgvClients.AllowUserToResizeColumns = false;
            this.DgvClients.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DgvClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvClients.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.DCIDENTIDAD,
            this.DCNOMBRE,
            this.DCDIRECCION,
            this.DCTELEFONO});
            this.DgvClients.Location = new System.Drawing.Point(27, 121);
            this.DgvClients.Name = "DgvClients";
            this.DgvClients.RowHeadersVisible = false;
            this.DgvClients.RowHeadersWidth = 62;
            this.DgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvClients.Size = new System.Drawing.Size(845, 386);
            this.DgvClients.TabIndex = 38;
            this.DgvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClients_CellDoubleClick);
            // 
            // GrpCriterios
            // 
            this.GrpCriterios.Controls.Add(this.RdbId);
            this.GrpCriterios.Controls.Add(this.RdbClientCode);
            this.GrpCriterios.Controls.Add(this.RdbNombre);
            this.GrpCriterios.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpCriterios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.GrpCriterios.Location = new System.Drawing.Point(13, 25);
            this.GrpCriterios.Name = "GrpCriterios";
            this.GrpCriterios.Size = new System.Drawing.Size(338, 70);
            this.GrpCriterios.TabIndex = 33;
            this.GrpCriterios.TabStop = false;
            this.GrpCriterios.Text = "Seleccione el criterio de búsqueda";
            // 
            // RdbId
            // 
            this.RdbId.AutoSize = true;
            this.RdbId.Location = new System.Drawing.Point(228, 33);
            this.RdbId.Name = "RdbId";
            this.RdbId.Size = new System.Drawing.Size(110, 23);
            this.RdbId.TabIndex = 2;
            this.RdbId.Text = "Identidad";
            this.RdbId.UseVisualStyleBackColor = true;
            // 
            // RdbClientCode
            // 
            this.RdbClientCode.AutoSize = true;
            this.RdbClientCode.Location = new System.Drawing.Point(116, 33);
            this.RdbClientCode.Name = "RdbClientCode";
            this.RdbClientCode.Size = new System.Drawing.Size(92, 23);
            this.RdbClientCode.TabIndex = 1;
            this.RdbClientCode.Text = "Código";
            this.RdbClientCode.UseVisualStyleBackColor = true;
            // 
            // RdbNombre
            // 
            this.RdbNombre.AutoSize = true;
            this.RdbNombre.Checked = true;
            this.RdbNombre.Location = new System.Drawing.Point(6, 33);
            this.RdbNombre.Name = "RdbNombre";
            this.RdbNombre.Size = new System.Drawing.Size(98, 23);
            this.RdbNombre.TabIndex = 0;
            this.RdbNombre.TabStop = true;
            this.RdbNombre.Text = "Nombre";
            this.RdbNombre.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.label6.Location = new System.Drawing.Point(363, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 123;
            this.label6.Text = "Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.TxtSearch.Location = new System.Drawing.Point(448, 59);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(351, 26);
            this.TxtSearch.TabIndex = 122;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // PbxSearch
            // 
            this.PbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.PbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxSearch.Image = ((System.Drawing.Image)(resources.GetObject("PbxSearch.Image")));
            this.PbxSearch.Location = new System.Drawing.Point(806, 60);
            this.PbxSearch.Name = "PbxSearch";
            this.PbxSearch.Size = new System.Drawing.Size(31, 25);
            this.PbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxSearch.TabIndex = 125;
            this.PbxSearch.TabStop = false;
            this.PbxSearch.Click += new System.EventHandler(this.PbxSearch_Click);
            // 
            // PbxCancel
            // 
            this.PbxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxCancel.BackColor = System.Drawing.Color.Transparent;
            this.PbxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxCancel.Image = ((System.Drawing.Image)(resources.GetObject("PbxCancel.Image")));
            this.PbxCancel.Location = new System.Drawing.Point(843, 58);
            this.PbxCancel.Name = "PbxCancel";
            this.PbxCancel.Size = new System.Drawing.Size(29, 27);
            this.PbxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxCancel.TabIndex = 124;
            this.PbxCancel.TabStop = false;
            this.PbxCancel.Click += new System.EventHandler(this.PbxCancel_Click);
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.MinimumWidth = 8;
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.Width = 150;
            // 
            // DCIDENTIDAD
            // 
            this.DCIDENTIDAD.HeaderText = "IDENTIDAD";
            this.DCIDENTIDAD.MinimumWidth = 8;
            this.DCIDENTIDAD.Name = "DCIDENTIDAD";
            this.DCIDENTIDAD.Width = 130;
            // 
            // DCNOMBRE
            // 
            this.DCNOMBRE.HeaderText = "NOMBRE";
            this.DCNOMBRE.MinimumWidth = 8;
            this.DCNOMBRE.Name = "DCNOMBRE";
            this.DCNOMBRE.Width = 200;
            // 
            // DCDIRECCION
            // 
            this.DCDIRECCION.HeaderText = "DIRECCION";
            this.DCDIRECCION.MinimumWidth = 8;
            this.DCDIRECCION.Name = "DCDIRECCION";
            this.DCDIRECCION.Width = 300;
            // 
            // DCTELEFONO
            // 
            this.DCTELEFONO.HeaderText = "TELEFONO";
            this.DCTELEFONO.MinimumWidth = 8;
            this.DCTELEFONO.Name = "DCTELEFONO";
            this.DCTELEFONO.Width = 103;
            // 
            // PbxClose
            // 
            this.PbxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxClose.BackColor = System.Drawing.Color.Transparent;
            this.PbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxClose.Image = ((System.Drawing.Image)(resources.GetObject("PbxClose.Image")));
            this.PbxClose.Location = new System.Drawing.Point(868, 5);
            this.PbxClose.Name = "PbxClose";
            this.PbxClose.Size = new System.Drawing.Size(27, 26);
            this.PbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxClose.TabIndex = 126;
            this.PbxClose.TabStop = false;
            this.PbxClose.Click += new System.EventHandler(this.PbxClose_Click);
            // 
            // FrmSearchClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(902, 555);
            this.Controls.Add(this.PbxClose);
            this.Controls.Add(this.PbxSearch);
            this.Controls.Add(this.PbxCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DgvClients);
            this.Controls.Add(this.GrpCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSearchClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSearchClient";
            this.Load += new System.EventHandler(this.FrmSearchClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvClients)).EndInit();
            this.GrpCriterios.ResumeLayout(false);
            this.GrpCriterios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DgvClients;
        private System.Windows.Forms.GroupBox GrpCriterios;
        private System.Windows.Forms.RadioButton RdbId;
        private System.Windows.Forms.RadioButton RdbClientCode;
        private System.Windows.Forms.RadioButton RdbNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.PictureBox PbxSearch;
        private System.Windows.Forms.PictureBox PbxCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCIDENTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCNOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCDIRECCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCTELEFONO;
        private System.Windows.Forms.PictureBox PbxClose;
    }
}