using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations.Events.Models {
    public sealed class EventBookingSettingsModel {
        public int? BookingLimit { get; set; }
        public int? PlacesRemaining { get; set; }
        public DateTime? BookingsOpen { get; set; }
        public DateTime BookingsClose { get; set; }
    }
}
