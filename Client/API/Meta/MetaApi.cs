using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Exceptions;
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
		
		public async Task<RemoteAPIInfo> GetAPIInfo() {
            var uri = new Uri(baseUrl + "api/meta");

            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) {
                throw new CareerHubApiHttpException("Could not get the remote info", response.StatusCode);
            }

            var result = await response.Content.ReadAsAsync<RemoteAPIInfo>();
            return result;
		}
        
        public void Dispose() {
            httpClient.Dispose();
        }
	}
}