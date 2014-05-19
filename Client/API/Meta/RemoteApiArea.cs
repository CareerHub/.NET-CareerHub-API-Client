using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Meta {
    public sealed class RemoteApiArea {
        public string Name { get; set; }
        public string LatestVersion { get; set; }
        public IEnumerable<string> SupportedVersions { get; set; }
    }
}
