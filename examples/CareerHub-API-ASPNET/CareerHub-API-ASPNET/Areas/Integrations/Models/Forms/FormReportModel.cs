using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub_API_ASPNET.Areas.Integrations.Models.Forms {
    public class FormReportModel {
        public int FormID { get; internal set; }
        public int ReportID { get; internal set; }
        public IEnumerable<string> Headers { get; set; }
        public IEnumerable<IReadOnlyDictionary<string, string>> Data { get; internal set; }
    }
}