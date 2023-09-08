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
using System.Text;
using System.Threading.Tasks;

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
