using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.Meta.API {
    public sealed class RemoteAPIInfo {
        public IEnumerable<RemoteApiArea> Areas { get; set; }
        public IEnumerable<string> Components { get; set; }
    }
}
