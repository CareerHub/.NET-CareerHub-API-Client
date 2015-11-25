using CareerHub.Client.API.Authorization;
using CareerHub.Client.API.Integrations.API.Forms;
using CareerHub.Client.Framework.API;
using CareerHub_API_ASPNET.Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub_API_ASPNET.Areas.Integrations.Framework.Services {
    public class FormReportsService : IFormReportsService {
        private readonly ICareerHubConfig chConfig;
        private readonly IApiFactory apiFactory;
        private readonly IAuthorizationApi authApi;

        public FormReportsService(ICareerHubConfig chConfig, IApiFactory apiFactory, IAuthorizationApi authApi) {
            this.chConfig = chConfig;
            this.apiFactory = apiFactory;
            this.authApi = authApi;
        }

        public async Task<FormReport> GetFormReportAsync(int formId, int reportId) {
            var result = await this.authApi.SendClientCredentialsRequestAsync(
                chConfig.BaseUrl,
                chConfig.ClientID,
                chConfig.ClientSecret,
                new string[] { "Integrations.Forms" },
                CancellationToken.None
            );

            var formReportsApi = apiFactory.GetApi<IFormReportsApi>(chConfig.BaseUrl, result.AccessToken);

            var data = await formReportsApi.GetAsync(formId, reportId);

            var headers = data.SelectMany(d => d.Keys).Distinct();

            return new FormReport {
                Headers = headers,
                Data = data
            };
        }
    }
}