using CareerHub.Client.API;
using CareerHub.Client.API.Authorization;
using CareerHub.Client.API.Integrations;
using CareerHub.Client.API.Integrations.Workflows;
using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Client.Meta;

namespace CareerHub.Client.Integration {
    public class Workflow : ConsoleCommand {
        private const string baseUrl = "http://localhost/careerhub/";
        
        private int? id;
        private string clientId;
        private string clientSecret;

        public Workflow() {
            IsCommand("workflow", "Gets workflow progress for a workflow");
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

                if (!String.IsNullOrWhiteSpace(idString)) {
                    id = int.Parse(idString);
                }
            }

			var info = await APIInfo.GetFromRemote(baseUrl, ApiArea.Integrations);
            
            var authApi = new AuthorizationApi(baseUrl, clientId, clientSecret);

			var authorization = authApi.RequestClientCredentialsAuth(new string[] { "Integrations.Workflows" });

            var factory = new IntegrationsApiFactory(info, authorization.AccessToken);
            var api = factory.GetWorkflowApi();

            var workflows = new List<WorkflowModel>();

            if (id.HasValue) {
                var workflow = await api.GetWorkflow(id.Value);
                workflows.Add(workflow);
            } else {
                var result = await api.GetWorkflows();
                workflows.AddRange(result);
            }

            foreach (var workflow in workflows) {
                Console.WriteLine("{1} ({0})",
                    workflow.ID,
                    workflow.Title
                );
                if (!String.IsNullOrWhiteSpace(workflow.Description)) {
                    Console.WriteLine(workflow.Description);
                }

                Console.WriteLine();
            }

            return 0;
        }

    }
}
