using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application.ViewModels.Report
{
    public class GeneratedSalesReportVm
    {
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
