namespace PulsacionesGUI
{
    partial class GestionarFacturasFrm
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
            this.label13 = new System.Windows.Forms.Label();
            this.TxtNumberInvoice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSearchInvoice = new FontAwesome.Sharp.IconButton();
            this.DgvInvoice = new System.Windows.Forms.DataGridView();
            this.BtnShowList = new FontAwesome.Sharp.IconButton();
            this.DgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LblSales = new System.Windows.Forms.Label();
            this.LblTotalPurchases = new System.Windows.Forms.Label();
            this.CmbTypeOfQuery = new System.Windows.Forms.ComboBox();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Invoice_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvoiceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(20, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 24);
            this.label13.TabIndex = 85;
            this.label13.Text = "Gestion de factura";
            // 
            // TxtNumberInvoice
            // 
            this.TxtNumberInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtNumberInvoice.Location = new System.Drawing.Point(383, 87);
            this.TxtNumberInvoice.Name = "TxtNumberInvoice";
            this.TxtNumberInvoice.Size = new System.Drawing.Size(92, 20);
            this.TxtNumberInvoice.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(190)))), ((int)(((byte)(161)))));
            this.label6.Location = new System.Drawing.Point(310, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "N° Factura:";
            // 
            // BtnSearchInvoice
            // 
            this.BtnSearchInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearchInvoice.BackColor = System.Drawing.Color.White;
            this.BtnSearchInvoice.FlatAppearance.BorderSize = 0;
            this.BtnSearchInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSearchInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.BtnSearchInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchInvoice.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnSearchInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchInvoice.ForeColor = System.Drawing.Color.Lime;
            this.BtnSearchInvoice.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.BtnSearchInvoice.IconColor = System.Drawing.Color.Lime;
            this.BtnSearchInvoice.IconSize = 30;
            this.BtnSearchInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchInvoice.Location = new System.Drawing.Point(490, 82);
            this.BtnSearchInvoice.Name = "BtnSearchInvoice";
            this.BtnSearchInvoice.Rotation = 0D;
            this.BtnSearchInvoice.Size = new System.Drawing.Size(89, 24);
            this.BtnSearchInvoice.TabIndex = 100;
            this.BtnSearchInvoice.Text = "Buscar";
            this.BtnSearchInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearchInvoice.UseVisualStyleBackColor = false;
            this.BtnSearchInvoice.Click += new System.EventHandler(this.BtnSearchInvoice_Click);
            // 
            // DgvInvoice
            // 
            this.DgvInvoice.AllowUserToAddRows = false;
            this.DgvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.DgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invoice_ID,
            this.InvoiceType,
            this.Cedula,
            this.FirstName,
            this.SubTotal,
            this.Total_IVA,
            this.Total_Invoice});
            this.DgvInvoice.Location = new System.Drawing.Point(24, 117);
            this.DgvInvoice.Name = "DgvInvoice";
            this.DgvInvoice.ReadOnly = true;
            this.DgvInvoice.Size = new System.Drawing.Size(555, 188);
            this.DgvInvoice.TabIndex = 141;
            this.DgvInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInvoice_CellClick);
            // 
            // BtnShowList
            // 
            this.BtnShowList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnShowList.BackColor = System.Drawing.Color.White;
            this.BtnShowList.FlatAppearance.BorderSize = 0;
            this.BtnShowList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnShowList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.BtnShowList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowList.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnShowList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(190)))), ((int)(((byte)(161)))));
            this.BtnShowList.IconChar = FontAwesome.Sharp.IconChar.List;
            this.BtnShowList.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(190)))), ((int)(((byte)(161)))));
            this.BtnShowList.IconSize = 30;
            this.BtnShowList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnShowList.Location = new System.Drawing.Point(134, 82);
            this.BtnShowList.Name = "BtnShowList";
            this.BtnShowList.Rotation = 0D;
            this.BtnShowList.Size = new System.Drawing.Size(149, 29);
            this.BtnShowList.TabIndex = 155;
            this.BtnShowList.Text = "Ver / Ocultar Lista";
            this.BtnShowList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnShowList.UseVisualStyleBackColor = false;
            this.BtnShowList.Click += new System.EventHandler(this.BtnShowList_Click);
            // 
            // DgvInvoiceDetail
            // 
            this.DgvInvoiceDetail.AllowUserToAddRows = false;
            this.DgvInvoiceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvInvoiceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvInvoiceDetail.BackgroundColor = System.Drawing.Color.White;
            this.DgvInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInvoiceDetail.Location = new System.Drawing.Point(24, 364);
            this.DgvInvoiceDetail.Name = "DgvInvoiceDetail";
            this.DgvInvoiceDetail.ReadOnly = true;
            this.DgvInvoiceDetail.Size = new System.Drawing.Size(555, 118);
            this.DgvInvoiceDetail.TabIndex = 156;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 24);
            this.label1.TabIndex = 157;
            this.label1.Text = "Ver Detalle Factura";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(607, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 142;
            this.label11.Text = "Total Compras:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(607, 259);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 145;
            this.label15.Text = "Total Ventas:";
            // 
            // LblSales
            // 
            this.LblSales.AutoSize = true;
            this.LblSales.Location = new System.Drawing.Point(693, 259);
            this.LblSales.Name = "LblSales";
            this.LblSales.Size = new System.Drawing.Size(0, 13);
            this.LblSales.TabIndex = 150;
            // 
            // LblTotalPurchases
            // 
            this.LblTotalPurchases.AutoSize = true;
            this.LblTotalPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalPurchases.Location = new System.Drawing.Point(702, 292);
            this.LblTotalPurchases.Name = "LblTotalPurchases";
            this.LblTotalPurchases.Size = new System.Drawing.Size(0, 13);
            this.LblTotalPurchases.TabIndex = 151;
            // 
            // CmbTypeOfQuery
            // 
            this.CmbTypeOfQuery.FormattingEnabled = true;
            this.CmbTypeOfQuery.Items.AddRange(new object[] {
            "Todo",
            "Venta",
            "Compra"});
            this.CmbTypeOfQuery.Location = new System.Drawing.Point(24, 87);
            this.CmbTypeOfQuery.Name = "CmbTypeOfQuery";
            this.CmbTypeOfQuery.Size = new System.Drawing.Size(79, 21);
            this.CmbTypeOfQuery.TabIndex = 158;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 300;
            this.lineShape1.X2 = 300;
            this.lineShape1.Y1 = 82;
            this.lineShape1.Y2 = 109;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(860, 512);
            this.shapeContainer1.TabIndex = 159;
            this.shapeContainer1.TabStop = false;
            // 
            // Invoice_ID
            // 
            this.Invoice_ID.HeaderText = "Invoice_ID";
            this.Invoice_ID.Name = "Invoice_ID";
            this.Invoice_ID.ReadOnly = true;
            this.Invoice_ID.Width = 84;
            // 
            // InvoiceType
            // 
            this.InvoiceType.HeaderText = "InvoiceType";
            this.InvoiceType.Name = "InvoiceType";
            this.InvoiceType.ReadOnly = true;
            this.InvoiceType.Width = 91;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cedula";
            this.Cedula.Name = "Cedula";
            this.Cedula.ReadOnly = true;
            this.Cedula.Width = 65;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 79;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 75;
            // 
            // Total_IVA
            // 
            this.Total_IVA.HeaderText = "Total_IVA";
            this.Total_IVA.Name = "Total_IVA";
            this.Total_IVA.ReadOnly = true;
            this.Total_IVA.Width = 79;
            // 
            // Total_Invoice
            // 
            this.Total_Invoice.HeaderText = "Total_Invoice";
            this.Total_Invoice.Name = "Total_Invoice";
            this.Total_Invoice.ReadOnly = true;
            this.Total_Invoice.Width = 97;
            // 
            // GestionarFacturasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 512);
            this.Controls.Add(this.CmbTypeOfQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvInvoiceDetail);
            this.Controls.Add(this.BtnShowList);
            this.Controls.Add(this.LblTotalPurchases);
            this.Controls.Add(this.LblSales);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DgvInvoice);
            this.Controls.Add(this.TxtNumberInvoice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSearchInvoice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionarFacturasFrm";
            this.Text = "GestionarFacturasFrm";
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvoiceDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtNumberInvoice;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton BtnSearchInvoice;
        private System.Windows.Forms.DataGridView DgvInvoice;
        private FontAwesome.Sharp.IconButton BtnShowList;
        private System.Windows.Forms.DataGridView DgvInvoiceDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LblSales;
        private System.Windows.Forms.Label LblTotalPurchases;
        private System.Windows.Forms.ComboBox CmbTypeOfQuery;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Invoice;
    }
}