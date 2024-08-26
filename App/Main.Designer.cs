namespace App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxCUIT = new TextBox();
            labelCUIT = new Label();
            comboBoxDetalle = new ComboBox();
            labelDetalle = new Label();
            labelCantidad = new Label();
            textBoxCantidad = new TextBox();
            labelPrecioTotal = new Label();
            textBoxPrecioTotal = new TextBox();
            buttonCrearFactura = new Button();
            labelTitle = new Label();
            textBoxCelular = new TextBox();
            labelCelular = new Label();
            labelCondIVA = new Label();
            comboBoxCondicionIVA = new ComboBox();
            dataGridViewClients = new DataGridView();
            labelSearchClients = new Label();
            textBoxSearchClients = new TextBox();
            splitContainer1 = new SplitContainer();
            labelTitleClients = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCUIT.Location = new Point(113, 105);
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(276, 23);
            textBoxCUIT.TabIndex = 2;
            // 
            // labelCUIT
            // 
            labelCUIT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCUIT.AutoSize = true;
            labelCUIT.Location = new Point(72, 108);
            labelCUIT.Name = "labelCUIT";
            labelCUIT.Size = new Size(35, 15);
            labelCUIT.TabIndex = 1;
            labelCUIT.Text = "CUIT:";
            // 
            // comboBoxDetalle
            // 
            comboBoxDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxDetalle.FormattingEnabled = true;
            comboBoxDetalle.Items.AddRange(new object[] { "GASTO DE ALMUERZO", "GASTO DE CENA", "GASTO DE COMIDA", "GASTO DE ALMUERZO Y CENA" });
            comboBoxDetalle.Location = new Point(113, 134);
            comboBoxDetalle.Name = "comboBoxDetalle";
            comboBoxDetalle.Size = new Size(276, 23);
            comboBoxDetalle.TabIndex = 3;
            // 
            // labelDetalle
            // 
            labelDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelDetalle.AutoSize = true;
            labelDetalle.Location = new Point(61, 137);
            labelDetalle.Name = "labelDetalle";
            labelDetalle.Size = new Size(46, 15);
            labelDetalle.TabIndex = 3;
            labelDetalle.Text = "Detalle:";
            // 
            // labelCantidad
            // 
            labelCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCantidad.AutoSize = true;
            labelCantidad.Location = new Point(49, 172);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(58, 15);
            labelCantidad.TabIndex = 4;
            labelCantidad.Text = "Cantidad:";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCantidad.Location = new Point(113, 169);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(276, 23);
            textBoxCantidad.TabIndex = 4;
            // 
            // labelPrecioTotal
            // 
            labelPrecioTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPrecioTotal.AutoSize = true;
            labelPrecioTotal.Location = new Point(7, 205);
            labelPrecioTotal.Name = "labelPrecioTotal";
            labelPrecioTotal.Size = new Size(100, 15);
            labelPrecioTotal.TabIndex = 6;
            labelPrecioTotal.Text = "Precio Total ($$$):";
            // 
            // textBoxPrecioTotal
            // 
            textBoxPrecioTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPrecioTotal.Location = new Point(113, 202);
            textBoxPrecioTotal.Name = "textBoxPrecioTotal";
            textBoxPrecioTotal.Size = new Size(276, 23);
            textBoxPrecioTotal.TabIndex = 5;
            // 
            // buttonCrearFactura
            // 
            buttonCrearFactura.Anchor = AnchorStyles.Top;
            buttonCrearFactura.FlatStyle = FlatStyle.Popup;
            buttonCrearFactura.Font = new Font("Segoe UI", 11F);
            buttonCrearFactura.Location = new Point(141, 262);
            buttonCrearFactura.Name = "buttonCrearFactura";
            buttonCrearFactura.Size = new Size(145, 30);
            buttonCrearFactura.TabIndex = 7;
            buttonCrearFactura.Text = "Crear Factura";
            buttonCrearFactura.UseVisualStyleBackColor = true;
            buttonCrearFactura.Click += buttonCrearFactura_Click;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16F);
            labelTitle.Location = new Point(141, 11);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(108, 30);
            labelTitle.TabIndex = 9;
            labelTitle.Text = "AFIP Auto";
            // 
            // textBoxCelular
            // 
            textBoxCelular.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCelular.Location = new Point(113, 233);
            textBoxCelular.Name = "textBoxCelular";
            textBoxCelular.Size = new Size(276, 23);
            textBoxCelular.TabIndex = 6;
            // 
            // labelCelular
            // 
            labelCelular.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCelular.AutoSize = true;
            labelCelular.Location = new Point(43, 236);
            labelCelular.Name = "labelCelular";
            labelCelular.Size = new Size(64, 15);
            labelCelular.TabIndex = 10;
            labelCelular.Text = "N° Celular:";
            // 
            // labelCondIVA
            // 
            labelCondIVA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCondIVA.AutoSize = true;
            labelCondIVA.Location = new Point(22, 76);
            labelCondIVA.Name = "labelCondIVA";
            labelCondIVA.Size = new Size(85, 15);
            labelCondIVA.TabIndex = 12;
            labelCondIVA.Text = "Condición IVA:";
            // 
            // comboBoxCondicionIVA
            // 
            comboBoxCondicionIVA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCondicionIVA.FormattingEnabled = true;
            comboBoxCondicionIVA.Items.AddRange(new object[] { "CONSUMIDOR FINAL", "IVA RESPONSABLE INSCRIPTO", "IVA EXCENTO" });
            comboBoxCondicionIVA.Location = new Point(113, 73);
            comboBoxCondicionIVA.Name = "comboBoxCondicionIVA";
            comboBoxCondicionIVA.Size = new Size(276, 23);
            comboBoxCondicionIVA.TabIndex = 1;
            // 
            // dataGridViewClients
            // 
            dataGridViewClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Location = new Point(22, 107);
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.Size = new Size(539, 287);
            dataGridViewClients.TabIndex = 13;
            dataGridViewClients.CellDoubleClick += dataGridViewClients_CellDoubleClick;
            // 
            // labelSearchClients
            // 
            labelSearchClients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSearchClients.AutoSize = true;
            labelSearchClients.Location = new Point(22, 73);
            labelSearchClients.Name = "labelSearchClients";
            labelSearchClients.Size = new Size(45, 15);
            labelSearchClients.TabIndex = 14;
            labelSearchClients.Text = "Buscar:";
            // 
            // textBoxSearchClients
            // 
            textBoxSearchClients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSearchClients.Location = new Point(73, 70);
            textBoxSearchClients.Name = "textBoxSearchClients";
            textBoxSearchClients.Size = new Size(488, 23);
            textBoxSearchClients.TabIndex = 8;
            textBoxSearchClients.TextChanged += textBoxSearchClients_TextChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(labelTitle);
            splitContainer1.Panel1.Controls.Add(labelCondIVA);
            splitContainer1.Panel1.Controls.Add(textBoxCUIT);
            splitContainer1.Panel1.Controls.Add(comboBoxCondicionIVA);
            splitContainer1.Panel1.Controls.Add(labelCUIT);
            splitContainer1.Panel1.Controls.Add(textBoxCelular);
            splitContainer1.Panel1.Controls.Add(comboBoxDetalle);
            splitContainer1.Panel1.Controls.Add(labelCelular);
            splitContainer1.Panel1.Controls.Add(labelDetalle);
            splitContainer1.Panel1.Controls.Add(labelCantidad);
            splitContainer1.Panel1.Controls.Add(buttonCrearFactura);
            splitContainer1.Panel1.Controls.Add(textBoxCantidad);
            splitContainer1.Panel1.Controls.Add(textBoxPrecioTotal);
            splitContainer1.Panel1.Controls.Add(labelPrecioTotal);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(labelTitleClients);
            splitContainer1.Panel2.Controls.Add(dataGridViewClients);
            splitContainer1.Panel2.Controls.Add(labelSearchClients);
            splitContainer1.Panel2.Controls.Add(textBoxSearchClients);
            splitContainer1.Size = new Size(1000, 406);
            splitContainer1.SplitterDistance = 407;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 16;
            // 
            // labelTitleClients
            // 
            labelTitleClients.Anchor = AnchorStyles.Top;
            labelTitleClients.AutoSize = true;
            labelTitleClients.Font = new Font("Segoe UI", 16F);
            labelTitleClients.Location = new Point(250, 11);
            labelTitleClients.Name = "labelTitleClients";
            labelTitleClients.Size = new Size(89, 30);
            labelTitleClients.TabIndex = 13;
            labelTitleClients.Text = "Clientes";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 406);
            Controls.Add(splitContainer1);
            Name = "Main";
            Text = "AFIP Auto";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxCUIT;
        private Label labelCUIT;
        private ComboBox comboBoxDetalle;
        private Label labelDetalle;
        private Label labelCantidad;
        private TextBox textBoxCantidad;
        private Label labelPrecioTotal;
        private TextBox textBoxPrecioTotal;
        private Button buttonCrearFactura;
        private Label labelTitle;
        private TextBox textBoxCelular;
        private Label labelCelular;
        private Label labelCondIVA;
        private ComboBox comboBoxCondicionIVA;
        private DataGridView dataGridViewClients;
        private Label labelSearchClients;
        private TextBox textBoxSearchClients;
        private SplitContainer splitContainer1;
        private Label labelTitleClients;
    }
}
