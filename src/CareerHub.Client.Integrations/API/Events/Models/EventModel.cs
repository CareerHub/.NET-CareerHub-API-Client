using CareerHub.Client.API.Integrations.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations.Events.Models {
    public sealed class EventModel {
        public int EntityID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Publish { get; set; }
        public DateTime? Expire { get; set; }

        public string Summary { get; set; }
        public string Details { get; set; }

        public string Venue { get; set; }

        public EventBookingType BookingType { get; set; }
        public EventBookingSettingsModel BookingSettings { get; set; }

        public int? WorkGroupId { get; set; }

        public ProvidersModel Providers { get; set; }

        public AttendanceSummaryModel Attendance { get; set; }

        public CategoriesModel Categories { get; set; }
    }
}
