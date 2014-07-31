using System;

namespace CareerHub.Client.API.Trusted.Experiences {
    public interface IExperienceSubmissionModel {
        string Title { get; }
        string Description { get; }
        string Organisation { get; }

        DateTime Start { get; }
        DateTime? End { get; }

        string ContactName { get; }
        string ContactEmail { get; }
        string ContactPhone { get; }

        int TypeID { get; }
        int? HoursID { get; }
    }
}
