using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;

namespace pgso
{
    internal class Class_Pdf_Generator
    {
        public void CreatePdf(string filePath, DataTable dataTable)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException(nameof(dataTable), "The data table cannot be null.");
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("The file path cannot be null or empty.", nameof(filePath));
            }

            try
            {
                // Create a new PDF document
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Add a logo
                string logoPath = "C:\\Users\\sese\\Documents\\pgso\\images\\LOGO.png"; // Replace with the actual path to your logo image
                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(80f, 80f);
                    logo.Alignment = Element.ALIGN_CENTER;
                    document.Add(logo);
                }

                // Add a title
                Paragraph title1 = new Paragraph("PROVINCIAL GENERAL SERVICES OFFICE", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(title1);

                Paragraph title2 = new Paragraph("Activity Logs", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(title2);

                Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"), FontFactory.GetFont(FontFactory.HELVETICA, 12))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                document.Add(date);

                document.Add(new Paragraph(" ")); // Add an empty line

                // Create a table with the same number of columns as the DataTable
                PdfPTable table = new PdfPTable(dataTable.Columns.Count)
                {
                    WidthPercentage = 100
                };

                // Set the widths of the columns
                //ALPHABETICALLY ARRANGED DAPAT ITO!!!!!!!!
                float[] columnWidths = new float[dataTable.Columns.Count];
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    switch (dataTable.Columns[i].ColumnName)
                    {
                        case "UserName":
                            columnWidths[i] = 1f; // Adjust width as needed
                            break;
                        case "UserType":
                            columnWidths[i] = 1f; // Adjust width as needed
                            break;
                        case "Action":
                            columnWidths[i] = 2f; // Adjust width as needed
                            break;
                        case "LogTime":
                            columnWidths[i] = 2f; // Adjust width as needed
                            break;
                        default:
                            columnWidths[i] = 1f; // Default width
                            break;
                    }
                }
                table.SetWidths(columnWidths);






                // Add the headers from the DataTable
                foreach (DataColumn column in dataTable.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName ?? string.Empty, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BackgroundColor = BaseColor.LIGHT_GRAY
                    };
                    table.AddCell(cell);
                }

                // Add the rows from the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var cellValue in row.ItemArray)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(cellValue?.ToString() ?? string.Empty, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        table.AddCell(cell);
                    }


                }

                document.Add(table);
                document.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating PDF: " + ex.Message);
            }
        }


    }
}
