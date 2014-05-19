using CareerHub.Client.API.Students.Appointments;
using CareerHub.Client.API.Students.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students {
    public sealed class StudentsApiFactory {
        private readonly APIInfo info = null;
        private readonly string accessToken = null;

        public StudentsApiFactory(APIInfo info, string accessToken) {
            this.info = info;
            this.accessToken = accessToken;
        }

        //Appointments
        public IAppointmentBookingsApi GetAppointmentBookingsApi() {
            RequireComponent("Appointments");
            // Do versioning here
            return new AppointmentBookingsApi(info.BaseUrl, accessToken);
        }
        
        //Events
        public IEventsApi GetEvents() {
            // Do versioning here

            return new EventsApi(info.BaseUrl, accessToken);
        }

        public IEventBookingsApi GetEventBookings() {
            // Do versioning here
            return new EventBookingsApi(info.BaseUrl, accessToken);
        }

        private void RequireComponent(string name) {
            if (!info.SupportedComponents.Contains(name)) {
                throw new NotSupportedException("The component " + name + " is not supported by " + info.BaseUrl);
            }
        }
    }
}
