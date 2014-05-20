using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students.Questions {
    public class QuestionSubmissionModel : IQuestionSubmissionModel {
        public string Text { get; set; }
        public string Topic { get; set; }
    }
}
