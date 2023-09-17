using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Report;
using PizzeriaImpulsMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;

namespace PizzeriaImpulsMVC.Application.Services
{

    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public ListGeneratedSalesReportVm GenerateSalesReport(DateTime datefrom, DateTime dateTo)
        {
            var generatedSalesReport = _reportRepository.GenerateSalesReport(datefrom, dateTo);

            var rowList = new List<GeneratedSalesReportVm>();

            foreach (var item in generatedSalesReport)
            {
                var row = new GeneratedSalesReportVm()
                {
                    OrderDate = item.OrderDate,
                    UserName = item.UserName,
                    TotalPrice = item.Total
                };

                rowList.Add(row);

            }

            var generatedSalesReportVm = new ListGeneratedSalesReportVm()
            {
                Rows = rowList
            };

            return generatedSalesReportVm;

        }

        public void GeneratePDF(DateTime dateFrom, DateTime dateTo)
        {
            var reportData = GenerateSalesReport(dateFrom, dateTo);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Paragraph titleParagraph = new Paragraph($"Sales report from {dateFrom} to {dateTo} generated from PizzeriaImpulsMVC Web Application",
                                                            new Font(Font.FontFamily.COURIER, 20));
                document.Add(titleParagraph);

                PdfPTable tableWithReportData = new PdfPTable(3);

                PdfPCell pdfDateCell = new PdfPCell(new Phrase("Date", new Font(Font.FontFamily.COURIER, 10)));
                pdfDateCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfDateCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER 

                PdfPCell pdfUserNameCell = new PdfPCell(new Phrase("UserName", new Font(Font.FontFamily.COURIER, 10)));
                PdfPCell pdfPriceCell = new PdfPCell(new Phrase("Price", new Font(Font.FontFamily.COURIER, 10)));



            }
        }

        
        public string GenerateCSV(DateTime dateFrom, DateTime dateTo)
        {
            var reportData = GenerateSalesReport(dateFrom, dateTo);

            var header = "date, userName, price";

            var path = $"../PizzeriaImpulsMVC.Web/Reports/CSVs/SalesReport{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}" +
                $"{DateTime.Now.Hour}_{DateTime.Now.Minute}.csv";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(header);

                foreach (var row in reportData.Rows)
                {
                    sw.WriteLine(row.OrderDate.ToString().Replace(' ', '_') + "," + row.UserName + "," + (row.TotalPrice.ToString().Replace(',', '.')));
                }
            }

            return path;
            
        }
        
    }
}
