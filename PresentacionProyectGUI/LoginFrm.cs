﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
namespace PulsacionesGUI
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizarBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWinsows moveWinsows = new MoveWinsows();
            moveWinsows.MoverVentana(this.Handle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrincipalFrm principalFrm = new PrincipalFrm();
            this.Visible = false;
            principalFrm.Show();
            

        }
    }
}
