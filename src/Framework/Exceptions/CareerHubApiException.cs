using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CareerHub.Client.Framework.Exceptions {
    public class CareerHubApiException : Exception {

        public CareerHubApiException(string error)
            : base(error) {
        }
    }
}
