using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Questions {
    internal sealed class QuestionResponsesApi : IDisposable {

        private const string ApiBase = "api/students/alpha/questions";
        private readonly OAuthHttpClient client = null;

        public QuestionResponsesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<GetResult<IEnumerable<QuestionResponseModel>>> GetResponses(int questionId) {
            string resource = GetResourceLocation(questionId);
            return client.GetResource<IEnumerable<QuestionResponseModel>>(resource);
		}

        public Task<PostResult<QuestionResponseModel>> CreateResponse(int questionId, IQuestionSubmissionModel model) {
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