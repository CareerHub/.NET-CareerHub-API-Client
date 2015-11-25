using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub_API_ASPNET.Areas.Integrations.Framework.Services {
    public interface IFormReportsService {
        Task<FormReport> GetFormReportAsync(int formId, int reportId);
    }
}