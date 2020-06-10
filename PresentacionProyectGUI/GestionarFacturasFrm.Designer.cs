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
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.DgvInvoice = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.BtnShowList = new FontAwesome.Sharp.IconButton();
            this.DgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Invoice_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LblIVA = new System.Windows.Forms.Label();
            this.LblTotalInvoice = new System.Windows.Forms.Label();
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
            this.TxtNumberInvoice.Location = new System.Drawing.Point(350, 79);
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
            this.label6.Location = new System.Drawing.Point(277, 82);
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
            this.BtnSearchInvoice.Location = new System.Drawing.Point(457, 74);
            this.BtnSearchInvoice.Name = "BtnSearchInvoice";
            this.BtnSearchInvoice.Rotation = 0D;
            this.BtnSearchInvoice.Size = new System.Drawing.Size(89, 34);
            this.BtnSearchInvoice.TabIndex = 100;
            this.BtnSearchInvoice.Text = "Buscar";
            this.BtnSearchInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearchInvoice.UseVisualStyleBackColor = false;
            this.BtnSearchInvoice.Click += new System.EventHandler(this.BtnSearchInvoice_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton3.BackColor = System.Drawing.Color.White;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.Lime;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButton3.IconColor = System.Drawing.Color.Lime;
            this.iconButton3.IconSize = 30;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(681, 464);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Rotation = 0D;
            this.iconButton3.Size = new System.Drawing.Size(89, 34);
            this.iconButton3.TabIndex = 102;
            this.iconButton3.Text = "Imprimir";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton4
            // 
            this.iconButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton4.BackColor = System.Drawing.Color.White;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton4.ForeColor = System.Drawing.Color.Crimson;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleUp;
            this.iconButton4.IconColor = System.Drawing.Color.Crimson;
            this.iconButton4.IconSize = 30;
            this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.Location = new System.Drawing.Point(675, 384);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Rotation = 0D;
            this.iconButton4.Size = new System.Drawing.Size(148, 38);
            this.iconButton4.TabIndex = 103;
            this.iconButton4.Text = "Devolver Producto";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton4.UseVisualStyleBackColor = false;
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
            this.DgvInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInvoiceDetail_CellClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(530, 413);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 144;
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.BackColor = System.Drawing.Color.White;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.Crimson;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.iconButton2.IconColor = System.Drawing.Color.Crimson;
            this.iconButton2.IconSize = 30;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(675, 428);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(128, 30);
            this.iconButton2.TabIndex = 148;
            this.iconButton2.Text = "Anular Factura";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.AutoSize = true;
            this.LblSubTotal.Location = new System.Drawing.Point(585, 352);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(0, 13);
            this.LblSubTotal.TabIndex = 149;
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
            this.BtnShowList.Location = new System.Drawing.Point(24, 70);
            this.BtnShowList.Name = "BtnShowList";
            this.BtnShowList.Rotation = 0D;
            this.BtnShowList.Size = new System.Drawing.Size(149, 42);
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
            // Invoice_ID
            // 
            this.Invoice_ID.HeaderText = "Invoice_ID";
            this.Invoice_ID.Name = "Invoice_ID";
            this.Invoice_ID.ReadOnly = true;
            this.Invoice_ID.Width = 84;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(617, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 142;
            this.label11.Text = "Total:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(617, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 143;
            this.label12.Text = "Subtotal:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(617, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 145;
            this.label15.Text = "IVA:";
            // 
            // LblIVA
            // 
            this.LblIVA.AutoSize = true;
            this.LblIVA.Location = new System.Drawing.Point(650, 112);
            this.LblIVA.Name = "LblIVA";
            this.LblIVA.Size = new System.Drawing.Size(0, 13);
            this.LblIVA.TabIndex = 150;
            // 
            // LblTotalInvoice
            // 
            this.LblTotalInvoice.AutoSize = true;
            this.LblTotalInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalInvoice.Location = new System.Drawing.Point(663, 139);
            this.LblTotalInvoice.Name = "LblTotalInvoice";
            this.LblTotalInvoice.Size = new System.Drawing.Size(0, 13);
            this.LblTotalInvoice.TabIndex = 151;
            // 
            // GestionarFacturasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvInvoiceDetail);
            this.Controls.Add(this.BtnShowList);
            this.Controls.Add(this.LblTotalInvoice);
            this.Controls.Add(this.LblIVA);
            this.Controls.Add(this.LblSubTotal);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DgvInvoice);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.TxtNumberInvoice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSearchInvoice);
            this.Controls.Add(this.label13);
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
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.DataGridView DgvInvoice;
        private System.Windows.Forms.Label label14;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label LblSubTotal;
        private FontAwesome.Sharp.IconButton BtnShowList;
        private System.Windows.Forms.DataGridView DgvInvoiceDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Invoice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LblIVA;
        private System.Windows.Forms.Label LblTotalInvoice;
    }
}