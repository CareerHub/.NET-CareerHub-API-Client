using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Questions {
    public interface IQuestionResponsesApi {
        Task<QuestionResponseModel> CreateResponse(int questionId, IQuestionSubmissionModel model);
        Task<IEnumerable<QuestionResponseModel>> GetResponses(int questionId);
    }
}
