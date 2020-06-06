using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Configuration;
using Entity;

namespace PulsacionesGUI
{
    public partial class FacturaFrm : Form
    {
        private readonly InvoiceService invoiceService;
        public FacturaFrm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            invoiceService = new InvoiceService(connectionString);
            AssingInvoiceNumber();
        }

       
        
        private void BtnVerlista_Click(object sender, EventArgs e)
        {

            ListaProductosFrm listaProductosFrm = new ListaProductosFrm();
            this.AddOwnedForm(listaProductosFrm);
            listaProductosFrm.ShowDialog();
            
        }

        private void  AssingInvoiceNumber()
        {
            InvoiceCountAnswer answer = invoiceService.InvoiceCount;

            LblInvoiceNumber.Text = (++answer.Count).ToString("0000");
            if (answer.Error) MessageBox.Show(answer.Message);

            
        }

        private Product MapOutProduct()
        {
            Product product = new Product();

            product.ID = TxtID.Text;
            product.Name = TxtName.Text;
            product.UnitValue = decimal.Parse(TxtUnitValue.Text);
            product.UnitMeasure = TxtUnitMeasure.Text;
            product.Quantity = float.Parse(TxtWarehouseQuantity.Text);
            product.IVA = decimal.Parse(TxtIVA.Text);

            return product;
        }

        private InvoiceDetail MapOutInvoiceDetail()
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail();
            Product product = MapOutProduct();
            invoiceDetail.Product = product;
            invoiceDetail.Invoice_ID = LblInvoiceNumber.Text;
            invoiceDetail.Quantity = decimal.Parse(TxtQuantity.Text);
            invoiceDetail.IVA = product.IVA;
            invoiceDetail.Discount = decimal.Parse(TxtDiscount.Text);

            return invoiceDetail;
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                InvoiceDetail invoiceDetail = MapOutInvoiceDetail();
                invoiceDetail.CalculateTotalDetail();
                TxtTotalDetail.Text = invoiceDetail.TolalDetail.ToString();
            }
        }
    }
}
