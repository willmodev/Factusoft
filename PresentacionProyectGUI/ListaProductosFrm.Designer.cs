namespace PulsacionesGUI
{
    partial class ListaProductosFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaProductosFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CerrarBtn = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CerrarBtn)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(190)))), ((int)(((byte)(161)))));
            this.panel1.Controls.Add(this.CerrarBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 36);
            this.panel1.TabIndex = 102;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // CerrarBtn
            // 
            this.CerrarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CerrarBtn.Image = ((System.Drawing.Image)(resources.GetObject("CerrarBtn.Image")));
            this.CerrarBtn.Location = new System.Drawing.Point(578, 9);
            this.CerrarBtn.Name = "CerrarBtn";
            this.CerrarBtn.Size = new System.Drawing.Size(15, 15);
            this.CerrarBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CerrarBtn.TabIndex = 103;
            this.CerrarBtn.TabStop = false;
            this.CerrarBtn.Click += new System.EventHandler(this.CerrarBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.iconButton1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(12, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 355);
            this.panel2.TabIndex = 103;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.White;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Lime;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconButton1.IconColor = System.Drawing.Color.Lime;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(71, 285);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(114, 30);
            this.iconButton1.TabIndex = 104;
            this.iconButton1.Text = "Seleccionar";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(71, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 183);
            this.dataGridView1.TabIndex = 103;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Valor Unit.";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cantidad en bodega";
            this.Column4.Name = "Column4";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(67, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(181, 24);
            this.label13.TabIndex = 102;
            this.label13.Text = "Lista de productos";
            // 
            // ListaProductosFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(190)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(604, 409);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaProductosFrm";
            this.Text = "ListaProductosFrm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CerrarBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox CerrarBtn;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label13;
    }
}