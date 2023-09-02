using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.ViewModels.Report;
using System.Data;

namespace PizzeriaImpulsMVC.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult GenerateSalesReport()
        {
            return View(new GenerateSalesReportVm());
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult GenerateSalesReport(GenerateSalesReportVm generateSalesReportVm)
        {
            var generatedReport = _reportService.GenerateSalesReport(generateSalesReportVm);

            return View(generatedReport);
        }
    }
}
