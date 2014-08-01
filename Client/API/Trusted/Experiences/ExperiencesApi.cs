using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Trusted.Experiences {
    internal sealed class ExperiencesApi : IDisposable, IExperiencesApi {

        private const string ApiBase = "api/trusted/v1/experiences";
        private readonly OAuthHttpClient client = null;

        public ExperiencesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<ExpereinceTypeModel>> GetExperienceTypes() {
            return client.GetResource<IEnumerable<ExpereinceTypeModel>>("types");
        }

        public Task<IEnumerable<ExperienceModel>> GetExperiences(string studentId) {
            string resource = GetResourceUrl(studentId);
            return client.GetResource<IEnumerable<ExperienceModel>>(resource);
		}

        public Task<ExperienceModel> GetExperience(string studentId, int id) {
            string resource = GetResourceUrl(studentId, id);
            return client.GetResource<ExperienceModel>(resource);
        }

        public Task<ExperienceModel> CreateExperience(string studentId, IExperienceSubmissionModel model) {
            string resource = GetResourceUrl(studentId);
            return client.PostResource<IExperienceSubmissionModel, ExperienceModel>(resource, model);
        }

        public Task<ExperienceModel> UpdateExperience(string studentId, int id, IExperienceSubmissionModel model) {
            string resource = GetResourceUrl(studentId, id);
            return client.PutResource<IExperienceSubmissionModel, ExperienceModel>(resource, model);
        }

        private string GetResourceUrl(string studentId, int? id = null) {
            string resouce = studentId;

            if (id.HasValue) {
                resouce += "/" + id.ToString();
            }

            return resouce;
        }

        public void Dispose() {
            client.Dispose();
        }
    }    
}