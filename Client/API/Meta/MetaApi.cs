using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Meta {
    public sealed class MetaApi : IDisposable {

        private readonly string baseUrl;
        private readonly HttpClient httpClient;

        public MetaApi(string baseUrl) {
            this.baseUrl = baseUrl.TrimEnd('/') + '/';
            httpClient = new HttpClient();
		}
		
		public async Task<GetResult<RemoteAPIInfo>> GetAPIInfo() {
            var uri = new Uri(baseUrl + "api/meta");

            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) {
                return new GetResult<RemoteAPIInfo>("Could not get the remote info. Status Code: " + response.StatusCode);
            } else {
                var result = await response.Content.ReadAsAsync<RemoteAPIInfo>();
                return new GetResult<RemoteAPIInfo>(result);
            }
		}
        
        public void Dispose() {
            httpClient.Dispose();
        }
	}
}