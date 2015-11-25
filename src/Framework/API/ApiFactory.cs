using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework.API {
    public class ApiFactory : IApiFactory {
        private readonly IAuthenticatedHttpClientFactory handlerFactory;

        public ApiFactory(IAuthenticatedHttpClientFactory handlerFactory = null) {
            
            this.handlerFactory = handlerFactory ?? new AuthenticatedHttpClientFactory();
        }

        public T GetApi<T>(string baseUrl, string accessToken) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));

            var client = handlerFactory.GetClientHandler(baseUrl, accessToken);

            //TODO: Check component

            return RestService.For<T>(client);
        }
    }
}
