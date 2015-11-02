using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    public sealed class EventModel {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
        public string Venue { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public bool IsBooked { get; set; }
        public bool BookingsEnabled { get; set; }
        public EventBookingSettingsModel BookingSettings { get; set; }
    }
}
