using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    public sealed class EventBookingSettingsModel {
        public bool CanBook { get; set; }

        public int? BookingLimit { get; set; }
        public int? PlacesRemaining { get; set; }
        public DateTime? BookingsOpenUtc { get; set; }
        public DateTime BookingsCloseUtc { get; set; }
    }
}
