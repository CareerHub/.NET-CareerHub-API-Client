using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Experiences {
    internal sealed class ExperiencesApi : IDisposable, IExperiencesApi {

        private const string ApiBase = "api/students/alpha/experiences";
        private readonly OAuthHttpClient client = null;

        public ExperiencesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}
        
        public Task<GetResult<IEnumerable<ExperienceModel>>> GetExperiences() {
            return client.GetResource<IEnumerable<ExperienceModel>>("");
		}

        public Task<GetResult<ExperienceModel>> GetExperience(int id) {
            return client.GetResource<ExperienceModel>(id.ToString());
        }

        public Task<PostResult<ExperienceModel>> CreateExperience(IExperienceSubmissionModel model) {
            return client.PostResource<IExperienceSubmissionModel, ExperienceModel>("", model);
        }

        public Task<PostResult<ExperienceModel>> UpdateExperience(int id, IExperienceSubmissionModel model) {
            return client.PutResource<IExperienceSubmissionModel, ExperienceModel>(id.ToString(), model);
        }

        public void Dispose() {
            client.Dispose();
        }
    }    
}