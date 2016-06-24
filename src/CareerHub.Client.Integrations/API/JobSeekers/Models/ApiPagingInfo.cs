using System;

namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class ApiPagingInfo {
        public string Token { get; set; }
        public DateTime ExpiresUtc { get; set; }

        public int Skipped { get; set; }
        public int Taken { get; set; }
        public int Total { get; set; }
    }
}