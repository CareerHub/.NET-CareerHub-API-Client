using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.Framework.Results {
    public interface IApiResult {
        bool Success { get; }
        string Error { get; }
    }
}
