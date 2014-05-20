using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students.Questions {
    public interface IQuestionSubmissionModel {
        string Text { get; }
        string Topic { get; }
    }
}
