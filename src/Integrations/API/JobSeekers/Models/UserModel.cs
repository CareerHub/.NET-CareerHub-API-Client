using System;

namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class UserModel {
        public int ID { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}