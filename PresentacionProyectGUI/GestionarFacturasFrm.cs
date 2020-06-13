using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PulsacionesGUI
{
    public partial class GestionarFacturasFrm : Form
    {
        private readonly InvoiceService invoiceService;
        IList<Invoice> invoices;

        public GestionarFacturasFrm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            invoiceService = new InvoiceService(connectionString);
        }

        private void BtnSearchInvoice_Click(object sender, EventArgs e)
        {
            InvoiceSearchAnswer answer = invoiceService.SearchInvoice(int.Parse(TxtNumberInvoice.Text));
            Invoice invoice = answer.Invoice;
            invoices = new List<Invoice>();

            if (!answer.Error)
            {
                if(invoice != null)
                {
                    invoices.Add(invoice);
                    FillInvoiceDetail();
                }
                    
            }

            MessageBox.Show(answer.Message);
        }

        private void BtnShowList_Click(object sender, EventArgs e)
        {
            InvoiceConsultAnswer answer = invoiceService.ConsultInvoices();
            if(CmbTypeOfQuery.Text != "")
            {
                if (!answer.Error)
                {
                    if (CmbTypeOfQuery.Text == "Todo")
                    {
                        invoices = answer.Invoices;
                        
                    }
                    else if (CmbTypeOfQuery.Text == "Compra")
                    {
                        invoices = invoiceService.FilerByType("Compra");
                    }
                    else
                    {
                        invoices = invoiceService.FilerByType("Venta");
                    }

                    FillInvoiceDetail();
                    CalculateTotals();
                    
                }else
                    MessageBox.Show(answer.Message);


            }
            else
            {
                MessageBox.Show("Primero debe seleccionar el tipo de busqueda!");
                CmbTypeOfQuery.DroppedDown = true;
            }
           
                     
        }

        private void FillInvoiceDetail()
        {
           
            DgvInvoiceDetail.DataSource = null;
            DgvInvoice.Rows.Clear();

            if (invoices.Count != 0)
            {
                foreach (var item in invoices)
                {
                    DgvInvoice.Rows.Add(item.Invoice_ID, item.InvoiceType, item.Client.Cedula, item.Client.FirstName,
                                        item.Subtotal, item.TotalIva, item.Total);
                }
            }
            else
                MessageBox.Show("No se encontraron registros");
               

            DgvInvoice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

        }

        int RowIndex = 0;
        private void DgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = (DgvInvoice.RowCount == 1) ? 0 : DgvInvoice.CurrentCell.RowIndex;

            ExtractInvoiceDetail();
        }

        public void ExtractInvoiceDetail()
        {
            Invoice invoice = null;
            try
            {
                 invoice = invoices.ElementAt(RowIndex);
                 InvoiceDetailConsultAnswer answer = invoiceService.ConsultInvoiceDetail(invoice.Invoice_ID);

                if (!answer.Error)
                {
                    FillTableInvoice(ApplyDTO(answer.invoiceDetails, invoice.InvoiceType));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"No se encuentra ninguna factura aqui! {e.Message}");
            }

            

           


        }

        private IList<InvoiceDetailDTO> ApplyDTO(IList<InvoiceDetail> invoiceDetails, string invoiceType)
        {
            IList<InvoiceDetailDTO> invoiceDetailDTOs = new List<InvoiceDetailDTO>();
            decimal price; 
            foreach (var item in invoiceDetails)
            {
               price = (invoiceType == "Venta") ? item.Product.SalePrice : item.Product.PurchasePrice;

               InvoiceDetailDTO invoiceDTO = invoiceService.MapInvoiceDetailDTO(item.Product, item.Quantity, item.Discount, price);
                
               invoiceDetailDTOs.Add(invoiceDTO);
            }

            return invoiceDetailDTOs;
        }

       
        private void FillTableInvoice(IList<InvoiceDetailDTO> invoiceDetailDTOs)
        {
            DgvInvoiceDetail.DataSource = null;
            DgvInvoiceDetail.DataSource = invoiceDetailDTOs;
            DgvInvoiceDetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }


        public void CalculateTotals()
        {
            decimal sales = invoiceService.TotalByType("Venta");
            decimal purchases =invoiceService.TotalByType("Compra");

            LblTotalPurchases.Text = $"{purchases.ToString("C")}";
            LblSales.Text = $"{sales.ToString("C")}";
        }
      
    }
}
