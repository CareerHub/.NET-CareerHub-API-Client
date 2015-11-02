using CareerHub.Client.API;
using CareerHub.Client.API.Authorization;
using CareerHub.Client.API.Integrations;
using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Client.Meta;

namespace CareerHub.Client.ConsoleApiTester {
    public class WorkflowProgress : ConsoleCommand {
        private const string baseUrl = "http://localhost/careerhub/";
        
        private int? id;
        private string clientId;
        private string clientSecret;

        public WorkflowProgress() {
            IsCommand("workflowprogress", "Gets workflow progress for a workflow");
            HasOption("client-id=", "the api client id", id => clientId = id);
            HasOption("client-secret=", "the api client id", secret => clientSecret = secret);
            HasOption<int>("id=", "the workflow id", i => id = i);
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
                Console.Write("Workflow ID: ");
                string idString = Console.ReadLine();
                id = int.Parse(idString);
            }

			var info = await APIInfo.GetFromRemote(baseUrl, ApiArea.Integrations);
            
            var authApi = new AuthorizationApi(baseUrl, clientId, clientSecret);

			var authorization = authApi.RequestClientCredentialsAuth(new string[] { "Integrations.Workflows" });

            var factory = new IntegrationsApiFactory(info, authorization.AccessToken);
            var api = factory.GetWorkflowProgressApi();

            var result = await api.Get(id.Value);

            foreach (var student in result) {
                Console.WriteLine("{0}: {1} {2} ({3}) - {4} {5}", 
                    student.JobSeeker.EntityID, 
                    student.JobSeeker.FirstName,
                    student.JobSeeker.LastName,
                    student.JobSeeker.StudentID,
                    student.Status,
                    student.CompletedDate
                );
            }

            return 0;
        }

    }
}
