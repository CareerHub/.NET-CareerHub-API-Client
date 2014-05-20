using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students.Questions {
    public class QuestionResponseModel {

        public int ID { get; private set; }
        public DateTime Date { get; private set; }
        public string Text { get; private set; }
        public IEnumerable<UploadFileModel> Files { get; set; }
    }
}
