using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Education {
    internal sealed class EducationApi : IDisposable, IEducationApi {

        private const string ApiBase = "api/jobseeker/v1/education";
        private readonly OAuthHttpClient client = null;

        public EducationApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<EducationModel>> GetEducation() {
            return client.GetResource<IEnumerable<EducationModel>>("");
		}

        public Task<EducationModel> GetEducation(int id) {
            return client.GetResource<EducationModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
    }    
}