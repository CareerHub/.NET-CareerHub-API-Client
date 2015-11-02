using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Questions {
    public interface IQuestionResponsesApi {
        Task<QuestionResponseModel> CreateResponse(int questionId, IQuestionSubmissionModel model);
        Task<IEnumerable<QuestionResponseModel>> GetResponses(int questionId);
    }
}
