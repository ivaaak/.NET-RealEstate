using Camunda.Api.Client.Execution;
using Camunda.Api.Client.ProcessInstance;
using MediatR;
using Microsoft.Win32.TaskScheduler;
using System.Net.Http.Headers;
using System.Text;
using Task = System.Threading.Tasks.Task;

namespace RealEstate.Orchestration
{
    public class CamundaClient
    {
        /*
        private readonly ProcessInstanceService _processInstanceService;
        private readonly ExecutionService _executionService;
        private readonly TaskService _taskService;

        public CamundaClient(string baseUrl, string username, string password)
        {
            // Create an HTTP client with the specified base URL and credentials.
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")))
            }
            };

            // Create a process instance service with the HTTP client.
            _processInstanceService = new ProcessInstanceService(httpClient);
            // Create an execution service and a task service with the HTTP client.
            _executionService = new ExecutionService(httpClient);
            _taskService = new TaskService(httpClient);
        }

        public async Task<string> StartProcessInstanceAsync(string processDefinitionKey,
            string businessKey,
            Dictionary<string, object> variables)
        {
            // Start the process instance and return the process instance ID.
            return await _processInstanceService.StartProcessInstanceAsync(processDefinitionKey, businessKey, variables);
        }


        public async Task UpdateTaskVariableAsync(string taskId, string variableName, object variableValue)
        {
            // Query the task.
            var task = await _taskService.GetTaskAsync(taskId);

            // Update the task variable.
            await _variableInstanceService.UpdateVariableAsync(new VariableModification
            {
                Value = variableValue,
                Type = "String"
            }, task.ProcessInstanceId, variableName, true);
        }


        public async Task CompleteTaskAsync(string taskId, Dictionary<string, object> variables)
        {
            // Complete the task with the specified variables.
            await _taskService.CompleteTaskAsync(taskId, variables);
        }


        public async Task SubscribeToEventsAsync(Action<string> onProcessInstanceCompleted, Action<string> onTaskCompleted)
        {
            // Subscribe to the process instance completed event.
            await _executionService.SubscribeToEventsAsync(new EventSubscription
            {
                EventName = "processInstance.completed",
                TenantId = "*"
            }, async e =>
            {
                // Call the onProcessInstanceCompleted callback.
                onProcessInstanceCompleted(e.BusinessKey);
            });

            // Subscribe to the task completed event.
            await _taskService.SubscribeToEventsAsync(new EventSubscription
            {
                EventName = "task.completed",
                TenantId = "*"
            }, async e =>
            {
                // Call the onTaskCompleted callback.
                onTaskCompleted(e.BusinessKey);
            });
        }



        internal Task<TResponse> SendRequestAsync<T1, TResponse>(IRequest<TResponse> request)
        {
            throw new NotImplementedException();
        }

        internal System.Threading.Tasks.Task PublishEventAsync<TNotification>(TNotification notification) where TNotification : INotification
        {
            throw new NotImplementedException();
        }
        */
    }
}


/*
You can add Camunda to a .NET web API by installing the Camunda.Api.Client NuGet 
package and using the various classes and methods provided by the Camunda.Api.Client namespace.

For example, if you want to start a process instance in Camunda, you can create a CamundaClient 
class that uses the ProcessInstanceService class to start the process instance:

In this example, the CamundaClient class contains a constructor that accepts the base URL, username, and password 
of the Camunda API, and creates an HttpClient with the specified credentials. It also contains a 
StartProcessInstanceAsync method that uses the ProcessInstanceService to start a process instance with the 
specified process definition key, business key, and variables.
*/
