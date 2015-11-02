using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CareerHub.Client.Framework.Exceptions {
    public class CareerHubApiHttpException : Exception {

        public HttpStatusCode Status { get; private set; }

        public CareerHubApiHttpException(string error, HttpStatusCode status)
            : base(error) {
                this.Status = status;
        }
    }
}
