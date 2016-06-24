using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Authorised.API.Questions.Models {
    public class QuestionSubmissionModel : IQuestionSubmissionModel {
        public string Text { get; set; }
        public string Topic { get; set; }
    }
}
