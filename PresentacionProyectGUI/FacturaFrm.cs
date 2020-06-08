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
        private Client client = null;
        private IList<InvoiceDetailDTO> invoiceDetailDTOs = new List<InvoiceDetailDTO>();
        public FacturaFrm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            invoiceService = new InvoiceService(connectionString);
            productService = new ProductService(connectionString);
            clientService = new ClientService(connectionString);
            invoice = new Invoice();
            AssingInvoiceNumber();
        }

       
        
        private void BtnVerlista_Click(object sender, EventArgs e)
        {
            if(invoice.Client != null)
            {
                ListaProductosFrm listaProductosFrm = new ListaProductosFrm();
                this.AddOwnedForm(listaProductosFrm);
                listaProductosFrm.ShowDialog();
            }
            else
                MessageBox.Show("Primero debe agragarun cliente a la factura!");
        }

        private void  AssingInvoiceNumber()
        {
            InvoiceCountAnswer answer = invoiceService.InvoiceCount;
            LblInvoiceNumber.Text = (++answer.Count).ToString("0000");
            if (answer.Error) MessageBox.Show(answer.Message);

            
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
            if (invoice.Client != null)
            {
                if (TxtID.Text != "")
                {
                    SearchProductAnswer answer = productService.Search(TxtID.Text);
                    Product product = answer.Product;

                    if (answer.Product != null)
                    {
                        TxtID.Text = product.ID;
                        TxtName.Text = product.Name;
                        TxtUnitMeasure.Text = product.UnitMeasure;
                        TxtWarehouseQuantity.Text = product.Quantity.ToString();
                        TxtUnitValue.Text = product.UnitValue.ToString();
                        TxtIVA.Text = product.IVA.ToString();

                        TxtQuantity.Text = "0";
                        TxtDiscount.Text = "0";
                    }

                    MessageBox.Show(answer.Message);
                }
                else
                {
                    MessageBox.Show("Debe ingrasar un codigo de producto para realizar la busqueda!");
                    TxtID.Focus();
                }
            }
            else
                MessageBox.Show("Primero debe agragarun cliente a la factura!");
           
               
            

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

            if(CmbInvoiceType.Text == "Venta")
            {
                if (quantity <= wareHouseQuantity)
                    AddInvoiceDetail();
                else
                    MessageBox.Show("La cantidad a vender es mayor que la cantidad que tiene en bodega");
            }
            else
            {
                AddInvoiceDetail();
            }
          
        }

        private void AddInvoiceDetail()
        {
            MapOutProduct();
            invoice.Invoice_ID = int.Parse(LblInvoiceNumber.Text);
            invoice.AgregarDetalleFactura
            (
                product,
                float.Parse(TxtQuantity.Text),
                float.Parse(TxtDiscount.Text)
                
            );

            invoiceDetailDTOs.Add(

                invoiceService.MapInvoiceDetailDTO(

                product,
                float.Parse(TxtQuantity.Text),
                float.Parse(TxtDiscount.Text)
                )
                
                );
            FillTableInvoiceDetail();
            CalculateTotals();




            MessageBox.Show("Detalle agregado a la factura!");
            ClearTextBoxes();
        }

        public void CalculateTotals()
        {
            invoice.CalculateSubtotal();
            invoice.CalcularTotalIva();
            invoice.CalculaTeTotal();

            LblSubTotal.Text = $"{Decimal.Round(invoice.Subtotal, 1)} ";
            LblIVA.Text = $"{Decimal.Round(invoice.TotalIva, 1)}";
            LblTotalInvoice.Text = $"{Decimal.Round(invoice.Total, 1)}";
        }

        public void FillTableInvoiceDetail()
        {
            DgvTableInvoiceDetail.Visible = true;
            DgvTableInvoiceDetail.DataSource = null;
            DgvTableInvoiceDetail.DataSource = invoiceDetailDTOs;
            DgvTableInvoiceDetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //DgvTableInvoiceDetail.Columns[1].Visible = false;
        }

        private void BtnSearchClient_Click(object sender, EventArgs e)
        {
            
            if(TxtCedulaClient.Text != "")
            {
                SearchClienttAnswer answer = clientService.Search(TxtCedulaClient.Text);
                client = new Client();
                client = answer.Client;

                if(client != null)
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

            if (invoice.InvoiceDetails.Count > 0)
            {
                invoice.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                invoice.DueData = DateTime.Parse(invoice.SaleDate.AddMonths(2).ToShortDateString());

                SaveInvoiceAnswer answer = invoiceService.SaveInvoice(invoice);

                MessageBox.Show(answer.Message);
                if (!answer.Error)
                {
                    GeneratePDF();
                }
                ClearComponents();
                AssingInvoiceNumber();
            }
            else
                MessageBox.Show("Accion invalida, la factura se encuentra vacia!");
           



        }

        public void GeneratePDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            InvoiceSearchAnswer answer = invoiceService.SearchInvoice();
            MessageBox.Show(answer.Message);

            saveFileDialog.Title = "Guardar Factura";
            saveFileDialog.InitialDirectory = @"D:\University\Programacion III";
            saveFileDialog.DefaultExt = "pdf";

            string fileName = "";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                fileName = saveFileDialog.FileName;
            if (fileName != "" && answer.Invoice != null)
            {
                string message = productService.GeneratePDF(answer.Invoice, fileName);
                MessageBox.Show(message, "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se especifico una ruta o no hay datos para generar el reporte", "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClearComponents()
        {
            DgvTableInvoiceDetail.DataSource = null;
            DgvTableInvoiceDetail.Visible = false;
            CmbInvoiceType.Text = "";
            LblIVA.Text = "";
            LblSubTotal.Text = "";
            LblTotalInvoice.Text = "";
            client = null;
            product = null;
            invoice = new Invoice();

            foreach (var item in this.Controls)
            {
                if(item.GetType().Equals(typeof(TextBox)))
                {
                    TextBox textBox = item as TextBox;
                    textBox.Text = string.Empty;
                }
            }
            
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {

            invoice.InvoiceDetails.RemoveAt(CellValue);
            FillTableInvoiceDetail();
            CalculateTotals();

        }
        int CellValue = 0;
        private void DgvTableInvoiceDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellValue = DgvTableInvoiceDetail.CurrentCell.RowIndex;
        }

       
    }
}
