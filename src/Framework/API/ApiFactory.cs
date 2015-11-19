using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework.API {
    public class ApiFactory : IApiFactory {
        private readonly string baseUrl = null;
        private readonly string accessToken = null;
        private readonly IAuthenticatedHttpClientFactory handlerFactory;

        public ApiFactory(string baseUrl, string accessToken, IAuthenticatedHttpClientFactory handlerFactory = null) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(accessToken);

            this.baseUrl = baseUrl;
            this.accessToken = accessToken;
            this.handlerFactory = handlerFactory ?? new AuthenticatedHttpClientFactory();
        }

        public T GetApi<T>() {
            var client = handlerFactory.GetClientHandler(baseUrl, accessToken);

            //TODO: Check component

            return RestService.For<T>(client);
        }
    }
}
