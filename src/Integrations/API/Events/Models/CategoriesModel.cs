using System.Collections.Generic;

namespace CareerHub.Client.API.Integrations.Events.Models {
    public class CategoriesModel {
        public string EventType { get; set; }
        public IEnumerable<string> Campus { get; set; }
    }
}