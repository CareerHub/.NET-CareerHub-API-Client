using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Authorization {
    internal sealed class TokenInfoModel {
        public string Audience { get; set; }
        public string User { get; set; }
    }
}
