using System;
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
    public partial class ListaProductosFrm : Form
    {
        public ListaProductosFrm()
        {
            InitializeComponent();
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoveWinsows moveWinsows = new MoveWinsows();
            moveWinsows.MoverVentana(this.Handle);

        }
    }
}
