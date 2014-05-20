using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Questions {
    public interface IQuestionsApi {
        Task<GetResult<IEnumerable<QuestionsModel>>> GetQuestions();
        Task<GetResult<QuestionsModel>> GetQuestion(int id);
        Task<PostResult<QuestionsModel>> CreateQuestion(IQuestionSubmissionModel model);
    }
}
