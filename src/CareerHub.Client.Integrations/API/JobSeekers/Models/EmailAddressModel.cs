namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class EmailAddressModel {
        public string Email { get; set; }

        public bool Confirmed { get; set; }

        public bool Deactivated { get; set; }

        public string DeactivationReason { get; set; }
    }
}