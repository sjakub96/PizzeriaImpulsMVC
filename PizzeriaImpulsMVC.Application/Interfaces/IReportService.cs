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
        ListGeneratedSalesReportVm GenerateSalesReport(GenerateSalesReportVm generateSalesReportVm);
    }
}
