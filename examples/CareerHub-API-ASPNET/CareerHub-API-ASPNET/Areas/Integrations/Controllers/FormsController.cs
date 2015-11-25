using CareerHub_API_ASPNET.Areas.Integrations.Framework.Services;
using CareerHub_API_ASPNET.Areas.Integrations.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CareerHub_API_ASPNET.Areas.Integrations.Controllers {
    public class FormsController : Controller {
        private readonly IFormReportsService formReportsService;

        public FormsController(IFormReportsService formReportsService) {
            this.formReportsService = formReportsService;
        }

        public ActionResult Index() {
            return View();
        }
        public async Task<ActionResult> Report(int formId, int reportId) {
            var report = await formReportsService.GetFormReportAsync(formId, reportId);
            var model = new FormReportModel {
                FormID = formId,
                ReportID = reportId,
                Headers = report.Headers,
                Data = report.Data
            };

            return View(model);
        }
    }
}