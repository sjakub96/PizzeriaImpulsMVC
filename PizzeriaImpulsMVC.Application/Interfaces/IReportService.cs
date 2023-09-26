using iTextSharp.text;
using PizzeriaImpulsMVC.Application.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.Interfaces
{
    public interface IReportService
    {
        ListGeneratedSalesReportVm GenerateSalesReport(DateTime datefrom, DateTime dateTo);
        byte[] GeneratePDF(DateTime dateFrom, DateTime dateTo);
        string GenerateCSV(DateTime dateFrom, DateTime dateTo);
        string GenerateXLSX(DateTime dateFrom, DateTime dateTo);
    }
}
