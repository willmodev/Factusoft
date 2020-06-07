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
        private readonly ProductService productService;
        private readonly ClientService clientService;
        private Invoice invoice;
        private Product product;
        private Client client;
        public FacturaFrm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            invoiceService = new InvoiceService(connectionString);
            productService = new ProductService(connectionString);
            clientService = new ClientService(connectionString);
            invoice = new Invoice();
            client = new Client();
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

        private void BtnSearchClient_Click_1(object sender, EventArgs e)
        {

        }

        private void  MapOutProduct()
        {
            product = new Product();

            product.ID = TxtID.Text;
            product.Name = TxtName.Text;
            product.UnitValue = decimal.Parse(TxtUnitValue.Text);
            product.UnitMeasure = TxtUnitMeasure.Text;
            product.Quantity = float.Parse(TxtWarehouseQuantity.Text);
            product.IVA = decimal.Parse(TxtIVA.Text);

        }


       
        private void BtnSearchProduct_Click(object sender, EventArgs e)
        {

            if (TxtID.Text != "")
            {
                SearchProductAnswer answer = productService.Search(TxtID.Text);
                Product product = answer.Product;

                TxtID.Text = product.ID;
                TxtName.Text = product.Name;
                TxtUnitMeasure.Text = product.UnitMeasure;
                TxtWarehouseQuantity.Text = product.Quantity.ToString();
                TxtUnitValue.Text = product.UnitValue.ToString();
                TxtIVA.Text = product.IVA.ToString();

                TxtQuantity.Text = "0";
                TxtDiscount.Text = "0";


                MessageBox.Show(answer.Message);
            }
            else
            {
                MessageBox.Show("Debe ingrasar un codigo de producto para realizar la busqueda!");
                TxtID.Focus();
            }
               
            

        }

       

        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            if(CmbInvoiceType.Text != "")
            {
                if(client != null)
                {
                    invoice.Client = client;
                    invoice.Invoice_ID = int.Parse(LblInvoiceNumber.Text);
                    invoice.InvoiceType = CmbInvoiceType.Text;
                    MessageBox.Show("Ciente agregado a la factura!");
                }else
                {
                     MessageBox.Show("Debe oprimir el boton buscar para realizar la busqueda!");
                }
                
            }
            else
            {
                MessageBox.Show("Debe Escojer el tipo de factura primero!");
                CmbInvoiceType.DroppedDown = true;
            }
           
            
        }

        private void BtnAddInvoiceDetail_Click(object sender, EventArgs e)
        {
            float quantity = float.Parse(TxtQuantity.Text);
            float wareHouseQuantity = float.Parse(TxtWarehouseQuantity.Text);

            if(CmbInvoiceType.Text == "Venta" && (quantity <= wareHouseQuantity))
            {
                MapOutProduct();
                invoice.AgregarDetalleFactura
                (
                    int.Parse(LblInvoiceNumber.Text),
                    product,
                    decimal.Parse(TxtQuantity.Text),
                    decimal.Parse(TxtDiscount.Text),
                    product.IVA
                );

                FillTableInvoiceDetail();

                invoice.CalculateSubtotal();
                invoice.CalcularTotalIva();
                invoice.CalculaTeTotal();

                LblSubTotal.Text = $"{Decimal.Round(invoice.Subtotal, 1)} ";
                LblIVA.Text = $"{Decimal.Round(invoice.TotalIva, 1)}";
                LblTotalInvoice.Text = $"{Decimal.Round(invoice.Total, 1)}";

                MessageBox.Show("Detalle agregado a la factura!");
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("La cantidad a vender es mayor que la cantidad que tiene en bodega");
            }
          
        }

        public void FillTableInvoiceDetail()
        {
            DgvTableInvoiceDetail.Visible = true;
            DgvTableInvoiceDetail.DataSource = null;
            DgvTableInvoiceDetail.DataSource = invoice.InvoiceDetails;
            DgvTableInvoiceDetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            DgvTableInvoiceDetail.Columns[1].Visible = false;
        }

        private void BtnSearchClient_Click(object sender, EventArgs e)
        {
            
            if(TxtCedulaClient.Text != "")
            {
                SearchClienttAnswer answer = clientService.Search(TxtCedulaClient.Text);
                client = answer.Client;

                if(answer.Client != null)
                {
                    TxtCedulaClient.Text = client.Cedula;
                    TxtNameClient.Text = client.FirstName;
                    TxtLastNameClient.Text = client.LastName;
                }
               

                MessageBox.Show(answer.Message);
            }
            else
            {
                MessageBox.Show("Debe ingresar la cedula del cliente para realizar la busqueda!");
                TxtCedulaClient.Focus();
                
            }
        }

        public void ClearTextBoxes()
        {
            TxtID.Clear();
            TxtName.Clear();
            TxtUnitMeasure.Clear();
            TxtQuantity.Clear();
            TxtUnitValue.Clear();
            TxtIVA.Clear();
            TxtWarehouseQuantity.Clear();
            TxtDiscount.Clear();

            TxtID.Focus();
        }

        private void BtnCommitInvoice_Click(object sender, EventArgs e)
        {
            invoice.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            invoice.DueData = DateTime.Parse(invoice.SaleDate.AddMonths(2).ToShortDateString());

            SaveInvoiceAnswer answer = invoiceService.SaveInvoice(invoice);

            MessageBox.Show(answer.Message);

            //if (!answer.Error)
            //{
            //    MessageBox.Show("No hay error");
            //    PrincipalFrm principal = new PrincipalFrm();
            //    principal.AbrirFormHija(new FacturaFrm());
            //}

        }

       
    }
}
