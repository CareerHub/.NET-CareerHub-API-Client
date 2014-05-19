using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Meta {
    public sealed class RemoteAPIInfo {
        public IEnumerable<RemoteApiArea> Areas { get; set; }
        public IEnumerable<string> Components { get; set; }
    }
}
