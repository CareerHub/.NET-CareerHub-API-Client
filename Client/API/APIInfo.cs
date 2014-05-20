using CareerHub.Client.API.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API {
    public class APIInfo {
        public APIInfo() {
            this.SupportedComponents = new List<string>();
        }

        public string BaseUrl { get; set; }
        public string Version { get; set; }
        public IEnumerable<string> SupportedComponents { get; set; }

        public static async Task<APIInfo> GetFromRemote(string baseUrl, ApiArea area) {
            var metaApi = new MetaApi(baseUrl);

            var result = await metaApi.GetAPIInfo();
            if (!result.Success) {
                throw new ApplicationException(result.Error);
            }
            
            var remoteInfo = result.Content;

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
