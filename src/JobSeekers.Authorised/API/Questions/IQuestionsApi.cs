using CareerHub.Client.JobSeekers.Authorised.API.Questions.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Questions {
    public interface IQuestionsApi {
        [Get("api/jobseeker/v1/questions")]
        Task<IEnumerable<QuestionsModel>> GetQuestions();
        [Get("api/jobseeker/v1/questions/{id}")]
        Task<QuestionsModel> GetQuestion(int id);
        [Post("api/jobseeker/v1/questions")]
        Task<QuestionsModel> CreateQuestion([Body] IQuestionSubmissionModel model);
    }
}
