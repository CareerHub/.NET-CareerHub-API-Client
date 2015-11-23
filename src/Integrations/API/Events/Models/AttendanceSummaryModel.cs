namespace CareerHub.Client.API.Integrations.Events.Models {
    public class AttendanceSummaryModel {
        public int Total { get; set; }
        public int Unspecified { get; set; }
        public int Absent { get; set; }
        public int Attended { get; set; }
    }
}