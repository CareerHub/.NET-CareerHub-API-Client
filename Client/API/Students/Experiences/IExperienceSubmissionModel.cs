using System;

namespace CareerHub.Client.API.Students.Experiences {
    public interface IExperienceSubmissionModel {
        string ContactEmail { get; set; }
        string ContactName { get; set; }
        string ContactPhone { get; set; }
        string Description { get; set; }
        DateTime? EndDate { get; set; }
        string Organisation { get; set; }
        DateTime StartDate { get; set; }
        string Title { get; set; }
    }
}
