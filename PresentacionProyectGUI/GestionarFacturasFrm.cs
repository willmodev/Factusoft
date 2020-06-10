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

            if(invoice != null)
            {
                TxtInvoiceType.Text = invoice.InvoiceType;
                FillClient(invoice);
                FillTableInvoice(ApplyDTO(invoice.InvoiceDetails));
                FillTotals(invoice);

            }

            MessageBox.Show(answer.Message);
        }

        private IList<InvoiceDetailDTO> ApplyDTO(IList<InvoiceDetail> invoiceDetails)
        {
            IList<InvoiceDetailDTO> invoiceDetailDTOs = new List<InvoiceDetailDTO>();
            foreach (var item in invoiceDetails)
            {
                InvoiceDetailDTO invoiceDTO = invoiceService.MapInvoiceDetailDTO(item.Product, item.Quantity, item.Discount);

                invoiceDetailDTOs.Add(invoiceDTO);
            }

            return invoiceDetailDTOs;
        }

        private void FillClient(Invoice invoice)
        {
            TxtCedulaClient.Text = invoice.Client.Cedula;
            TxtNameClient.Text = invoice.Client.FirstName;
            TxtLastNameClient.Text = invoice.Client.LastName;
        }

        private void FillTableInvoice(IList<InvoiceDetailDTO> invoiceDetailDTOs)
        {
            DgvInvoice.DataSource = null;
            DgvInvoice.DataSource = invoiceDetailDTOs;
            DgvInvoice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void FillTotals(Invoice invoice)
        {
            LblSubTotal.Text = $"{Decimal.Round(invoice.Subtotal, 1)} ";
            LblIVA.Text = $"{Decimal.Round(invoice.TotalIva, 1)}";
            LblTotalInvoice.Text = $"{Decimal.Round(invoice.Total, 1)}";
        }
    }
}
