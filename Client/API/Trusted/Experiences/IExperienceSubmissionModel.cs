using System;

namespace CareerHub.Client.API.Trusted.Experiences {
    public interface IExperienceSubmissionModel {
        string Title { get; }
        string Description { get; }
        string Organisation { get; }

        DateTime StartDate { get; }
        DateTime? EndDate { get; }

        string ContactName { get; }
        string ContactEmail { get; }
        string ContactPhone { get; }
    }
}
