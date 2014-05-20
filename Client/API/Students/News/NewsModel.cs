using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students.News {
    public class NewsModel {
        public int ID { get; set; }
        public string Byline { get; set; }
        public DateTime PublishUtc { get; set; }
        public DateTime Publish { get; set; }

        public string Headline { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Topics { get; set; }
    }
}
