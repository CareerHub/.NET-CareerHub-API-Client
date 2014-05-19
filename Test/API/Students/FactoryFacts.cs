using CareerHub.Client.API;
using CareerHub.Client.API.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CareerHub.Client.Tests.API.Students {
    public class FactoryFacts {
        private const string AccessToken = "blah";
        private const string BaseUrl = "http://localhost/careerhub/";

        [Fact]
        public void GetAppointments_Works() {
            Assert.DoesNotThrow(() => {
                var info = new APIInfo {
                    BaseUrl = BaseUrl,
                    SupportedComponents = new List<string> { "Appointments" },
                    Version = "alpha"
                };

                var factory = new StudentsApiFactory(info, AccessToken);

                factory.GetAppointmentBookingsApi();
            });
        }

        [Fact]
        public void GetAppointments_Throws_If_Component_Not_Enabled() {
            Assert.Throws<NotSupportedException>(() => {
                var info = new APIInfo {
                    BaseUrl = BaseUrl,
                    Version = "alpha"
                };

                var factory = new StudentsApiFactory(info, AccessToken);

                factory.GetAppointmentBookingsApi();
            });
        }
    }
}
