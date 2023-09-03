using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Report;
using PizzeriaImpulsMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
