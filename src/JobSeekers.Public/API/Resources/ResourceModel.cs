using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Public.API.Resources {
    public class ResourceModel {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public string By { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public string TextContent { get; set; }

        public string Url { get; set; }
    }
}
