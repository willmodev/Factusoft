using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BLL;
using Entity;

namespace PulsacionesGUI
{
    public partial class ProductosFrm : Form
    {
        ProductService productService;
        
        public ProductosFrm()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            productService = new ProductService(connectionString);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Product product = MapOutProduct();
            MessageBox.Show(productService.Save(product));
        }

        private Product MapOutProduct()
        {
            Product product = new Product();

            product.ID = TxtID.Text;
            product.Name = TxtName.Text;
            product.UnitValue = decimal.Parse( TxtUnitValue.Text);
            product.UnitMeasure = CmbUnitMeasure.Text;
            product.Quantity = float.Parse(TxtQuantity.Text);
            product.IVA = decimal.Parse(TxtIVA.Text);

            return product;
        }
    }
}
