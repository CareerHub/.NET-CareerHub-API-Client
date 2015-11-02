using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Questions {
    internal sealed class QuestionResponsesApi : IDisposable, IQuestionResponsesApi {

        private const string ApiBase = "api/jobseeker/v1/questions";
        private readonly OAuthHttpClient client = null;

        public QuestionResponsesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<QuestionResponseModel>> GetResponses(int questionId) {
            string resource = GetResourceLocation(questionId);
            return client.GetResource<IEnumerable<QuestionResponseModel>>(resource);
		}

        public Task<QuestionResponseModel> CreateResponse(int questionId, IQuestionSubmissionModel model) {
            string resource = GetResourceLocation(questionId);
            return client.PostResource<IQuestionSubmissionModel, QuestionResponseModel>(resource, model);
        }

        private string GetResourceLocation(int questionId) {
            return "/" + questionId + "/responses";
        }
        
        public void Dispose() {
            client.Dispose();
        }
    }    
}