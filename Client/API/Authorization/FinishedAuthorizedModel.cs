using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Authorization {
    public sealed class FinishedAuthorizedModel {
        public string Audience { get; set; }
        public string User { get; set; }
        public string AccessToken { get; set; }
    }
}
