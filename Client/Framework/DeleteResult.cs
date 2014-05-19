using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub.Client.Framework {
    public sealed class DeleteResult : IApiResult {
        internal DeleteResult() {}

        internal DeleteResult(string error) {
            this.Error = error;
        }

        public bool Success {
            get { return String.IsNullOrWhiteSpace(this.Error); }
        }

        public string Error { get; private set; }
    }
}