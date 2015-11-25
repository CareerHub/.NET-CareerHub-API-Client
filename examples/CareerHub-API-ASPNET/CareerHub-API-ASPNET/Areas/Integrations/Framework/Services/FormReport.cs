using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub_API_ASPNET.Areas.Integrations.Framework.Services {
    public class FormReport {
        public IEnumerable<string> Headers { get; set; }
        public IEnumerable<IReadOnlyDictionary<string, string>> Data { get; set; }
    }
}