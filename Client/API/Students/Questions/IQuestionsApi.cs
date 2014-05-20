using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Questions {
    public interface IQuestionsApi {
        Task<IEnumerable<QuestionsModel>> GetQuestions();
        Task<QuestionsModel> GetQuestion(int id);
        Task<QuestionsModel> CreateQuestion(IQuestionSubmissionModel model);
    }
}
