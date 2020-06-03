using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Entity;
using System.IO;

namespace Infrastructure
{
    public class DocumentPDF
    {
        public void savePDF(IList<Product> products, string path)
        {
            FileStream fileStream = new FileStream(path,FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER,40,40,40,40);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document,fileStream);

            document.AddAuthor("Aplicacion Factusoft");
            document.Open();
            document.Add(new Paragraph("INFORME DE LA LISTA DE PRODUCTOS"));
            document.Add(new Paragraph("\n"));
            document.Add(FillTable(products));
            document.Close();
        }

        private PdfPTable FillTable(IList<Product> products)
        {
            PdfPTable pdfPTable = new PdfPTable(6);
            pdfPTable.AddCell(new Paragraph("ID"));
            pdfPTable.AddCell(new Paragraph("Name"));
            pdfPTable.AddCell(new Paragraph("InitValue"));
            pdfPTable.AddCell(new Paragraph("InitMeasure"));
            pdfPTable.AddCell(new Paragraph("Quantity"));
            pdfPTable.AddCell(new Paragraph("IVA"));

            foreach (var item in products)
            {
                pdfPTable.AddCell(new Paragraph(item.ID));
                pdfPTable.AddCell(new Paragraph(item.Name));
                pdfPTable.AddCell(new Paragraph(item.UnitValue.ToString()));
                pdfPTable.AddCell(new Paragraph(item.UnitMeasure));
                pdfPTable.AddCell(new Paragraph(item.Quantity.ToString()));
                pdfPTable.AddCell(new Paragraph(item.IVA.ToString()));
            }

            return pdfPTable;
        }
    }
}
