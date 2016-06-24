using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework.Http {
    public class AuthenticatedHttpClientFactory : IAuthenticatedHttpClientFactory {
        public HttpClient GetClientHandler(string baseUrl, string accessToken) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(baseUrl);
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(accessToken);

            var messageHandler = new AuthenticatedMessageHandler(accessToken); 
            var httpClient = new HttpClient(messageHandler) { 
                BaseAddress = new Uri(baseUrl) 
            };

            return httpClient;
        }
    }
}
