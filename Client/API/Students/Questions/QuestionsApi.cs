using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Questions {
    internal sealed class QuestionsApi : IDisposable, IQuestionsApi {

        private const string ApiBase = "api/students/alpha/questions";
        private readonly OAuthHttpClient client = null;

        public QuestionsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<GetResult<IEnumerable<QuestionsModel>>> GetQuestions() {
            return client.GetResource<IEnumerable<QuestionsModel>>("");
		}

        public Task<GetResult<QuestionsModel>> GetQuestion(int id) {
            return client.GetResource<QuestionsModel>(id.ToString());
        }

        public Task<PostResult<QuestionsModel>> CreateQuestion(IQuestionSubmissionModel model) {
            return client.PostResource<IQuestionSubmissionModel, QuestionsModel>("", model);
        }
        
        public void Dispose() {
            client.Dispose();
        }
    }    
}