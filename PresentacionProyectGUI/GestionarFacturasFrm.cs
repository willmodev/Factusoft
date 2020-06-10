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
            if (!answer.Error)
            {
                DgvInvoiceDetail.DataSource = null;
                DgvInvoice.Rows.Clear();

                if (invoice != null)
                {
                    DgvInvoice.Rows.Add(invoice.Invoice_ID, invoice.Client.Cedula, invoice.Client.FirstName,
                                        invoice.Subtotal, invoice.TotalIva, invoice.Total);
                }
                DgvInvoice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }

            MessageBox.Show(answer.Message);
        }

        private void BtnShowList_Click(object sender, EventArgs e)
        {
            InvoiceConsultAnswer answer = invoiceService.ConsultInvoices();
            invoices = answer.Invoices;

            
            if (!answer.Error)
            {
                DgvInvoiceDetail.DataSource = null;
                DgvInvoice.Rows.Clear();

                foreach (var item in invoices)
                {
                    DgvInvoice.Rows.Add(item.Invoice_ID, item.Client.Cedula, item.Client.FirstName,
                                        item.Subtotal, item.TotalIva, item.Total);
                }
            }
            DgvInvoice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            MessageBox.Show(answer.Message);
        }

        int RowIndex = 0;
        private void DgvInvoiceDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = (DgvInvoice.RowCount == 1) ? (int.Parse(TxtNumberInvoice.Text) - 1) : RowIndex = DgvInvoice.CurrentCell.RowIndex;

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
                    FillTableInvoice(ApplyDTO(answer.invoiceDetails));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se encuentra ninguna factura aqui!");
            }

            

           


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

       
        private void FillTableInvoice(IList<InvoiceDetailDTO> invoiceDetailDTOs)
        {
            DgvInvoiceDetail.DataSource = null;
            DgvInvoiceDetail.DataSource = invoiceDetailDTOs;
            DgvInvoiceDetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        //private void FillTotals(Invoice invoice)
        //{
        //    LblSubTotal.Text = $"{Decimal.Round(invoice.Subtotal, 1)} ";
        //    LblIVA.Text = $"{Decimal.Round(invoice.TotalIva, 1)}";
        //    LblTotalInvoice.Text = $"{Decimal.Round(invoice.Total, 1)}";
        //}

        //private void BtnShowList_Click(object sender, EventArgs e)
        //{




        //}
    }
}
