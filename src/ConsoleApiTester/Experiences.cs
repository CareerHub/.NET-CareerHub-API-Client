using CareerHub.Client.API;
using CareerHub.Client.API.Authorization;
using CareerHub.Client.JobSeekers.Trusted.API;
using CareerHub.Client.JobSeekers.Trusted.API.Experiences;
using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Client.Meta;

namespace CareerHub.Client.ConsoleApiTester {
    public class Experiences : ConsoleCommand {
        private const string baseUrl = "http://localhost/careerhub/";
        
        private int? id;
        private string clientId;
        private string clientSecret;

        public Experiences() {
            IsCommand("experiences", "Gets Experiences");
            HasOption("client-id=", "the api client id", id => clientId = id);
            HasOption("client-secret=", "the api client id", secret => clientSecret = secret);
        }

        public override int Run(string[] remainingArguments) {
            try {
                return RunAsync(remainingArguments).Result;
            } catch (Exception e) {
                Console.Error.WriteLine(e.ToString());
                return 1;
            }
        }

        public async Task<int> RunAsync(string[] remainingArguments) {
            if (String.IsNullOrWhiteSpace(clientId)) {
                Console.Write("Client ID: ");
                clientId = Console.ReadLine();
            }

            if (String.IsNullOrWhiteSpace(clientSecret)) {
                Console.Write("Client Secret: ");
                clientSecret = Console.ReadLine();
            }
            
			var info = await APIInfo.GetFromRemote(baseUrl, ApiArea.Integrations);
            
            var authApi = new AuthorizationApi(baseUrl, clientId, clientSecret);

			var authorization = authApi.RequestClientCredentialsAuth(new string[] { "Trusted.Experiences" });

            var factory = new TrustedApiFactory(info, authorization.AccessToken);
            var api = factory.GetExperiencesApi();

            var experiences = new List<ExperienceModel>();

            var result = await api.GetExperiences();
            experiences.AddRange(result);

            foreach (var experience in experiences) {
                Console.WriteLine("{1} ({0})",
                    experience.ID,
                    experience.Title
                );
            }

            return 0;
        }

    }
}
