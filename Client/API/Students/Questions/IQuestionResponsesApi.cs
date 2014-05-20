using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Questions {
    public interface IQuestionResponsesApi {
        Task<PostResult<QuestionResponseModel>> CreateResponse(int questionId, IQuestionSubmissionModel model);
        Task<GetResult<IEnumerable<QuestionResponseModel>>> GetResponses(int questionId);
    }
}
