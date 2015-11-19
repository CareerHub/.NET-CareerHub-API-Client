using CareerHub.Client.JobSeekers.Authorised.API.Questions.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Questions {
    public interface IQuestionResponsesApi {
        [Get("api/jobseeker/v1/questions/{questionid}/responses")]
        Task<IEnumerable<QuestionResponseModel>> GetResponses(int questionid);
        [Post("api/jobseeker/v1/questions/{questionid}/responses")]
        Task<QuestionResponseModel> CreateResponse(int questionid, [Body] IQuestionSubmissionModel model);
    }
}
