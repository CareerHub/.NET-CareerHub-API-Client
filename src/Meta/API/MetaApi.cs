using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CareerHub.Client.Meta.API {
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

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<RemoteAPIInfo>();
            return result;
		}
        
        public void Dispose() {
            httpClient.Dispose();
        }
	}
}