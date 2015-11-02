using CareerHub.Client.API;
using CareerHub.Client.API.Authorization;
using CareerHub.Client.API.Integrations;
using CareerHub.Client.API.Integrations.Jobs;
using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Client.Meta;

namespace CareerHub.Client.ConsoleApiTester {
    public class Jobs : ConsoleCommand {
        private const string baseUrl = "http://localhost/careerhub/";
        
        private int? id;
        private string clientId;
        private string clientSecret;

        public Jobs() {
            IsCommand("jobs", "Gets jobs");
            HasOption("client-id=", "the api client id", id => clientId = id);
            HasOption("client-secret=", "the api client id", secret => clientSecret = secret);
            HasOption<int>("id=", "the job id", i => id = i);
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
            
            if (!id.HasValue) {
                Console.Write("Job ID: ");
                string idString = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(idString)) {
                    id = int.Parse(idString);
                }
            }

			var info = await APIInfo.GetFromRemote(baseUrl, ApiArea.Integrations);
            
            var authApi = new AuthorizationApi(baseUrl, clientId, clientSecret);

			var authorization = authApi.RequestClientCredentialsAuth(new string[] { "Integrations.Jobs" });

            var factory = new IntegrationsApiFactory(info, authorization.AccessToken);
            var api = factory.GetJobsApi();

            var jobs = new List<JobModel>();

            if (id.HasValue) {
                var job = await api.GetJob(id.Value);
                jobs.Add(job);
            } else {
                var result = await api.GetJobs();
                jobs.AddRange(result);
            }

            foreach (var job in jobs) {
                Console.WriteLine("{1} ({0})",
                    job.ID,
                    job.Title
                );
            }

            return 0;
        }

    }
}
