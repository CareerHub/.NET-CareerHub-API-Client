using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Education {
    internal sealed class EducationApi : IDisposable, IEducationApi {

        private const string ApiBase = "api/students/alpha/education";
        private readonly OAuthHttpClient client = null;

        public EducationApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<GetResult<IEnumerable<EducationModel>>> GetEducation() {
            return client.GetResource<IEnumerable<EducationModel>>("");
		}

        public Task<GetResult<EducationModel>> GetEducation(int id) {
            return client.GetResource<EducationModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
    }    
}