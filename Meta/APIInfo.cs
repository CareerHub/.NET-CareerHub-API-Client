using CareerHub.Client.Meta.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Meta {
    public class APIInfo {
        public APIInfo() {
            this.SupportedComponents = new List<string>();
        }

        public string BaseUrl { get; set; }
        public string Version { get; set; }
        public IEnumerable<string> SupportedComponents { get; set; }

        public static async Task<APIInfo> GetFromRemote(string baseUrl, ApiArea area) {
            var metaApi = new MetaApi(baseUrl);

            var remoteInfo = await metaApi.GetAPIInfo();

            string areaname = area.ToString();

            var remoteArea = remoteInfo.Areas.SingleOrDefault(a => a.Name.Equals(areaname, StringComparison.OrdinalIgnoreCase));
            if (remoteArea == null) {
                return null;
            }

            return new APIInfo {
                BaseUrl = baseUrl,
                Version = remoteArea.LatestVersion,
                SupportedComponents = remoteInfo.Components
            };
        }
    }
}
