﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students.Questions {
    public class QuestionsModel {
        public int ID { get; set; }
        public DateTime Updated { get; set; }
        public string Text { get; set; }
        public string Topic { get; set; }
        public bool IsClosed { get; set; }
        public bool HasUnseenResponses { get; set; }
        public DateTime? AwaitingResponse { get; set; }

        public IEnumerable<QuestionResponseModel> Responses { get; set; }
    }
}
