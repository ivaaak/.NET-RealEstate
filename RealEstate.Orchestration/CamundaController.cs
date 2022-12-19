using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace RealEstate.Orchestration
{
    public class CamundaController : Controller
    {
        /*
        private readonly CamundaClient _camundaClient;

        public CamundaController(CamundaClient camundaClient)
        {
            _camundaClient = camundaClient;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(
            string processDefinitionKey,
            string businessKey,
            Dictionary<string, object> variables)
        {
            // Start the process instance.
            var processInstanceId = await _camundaClient.StartProcessInstanceAsync(processDefinitionKey, businessKey, variables);

            // Return the process instance ID.
            return Ok(new { processInstanceId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskVariable(string taskId, string variableName, object variableValue)
        {
            // Update the task variable.
            await _camundaClient.UpdateTaskVariableAsync(taskId, variableName, variableValue);

            // Return success.
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CompleteTask(string taskId, Dictionary<string, object> variables)
        {
            // Complete the task.
            await _camundaClient.CompleteTaskAsync(taskId, variables);

            // Return success.
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeToEvents(
            Action<string> onProcessInstanceCompleted,
            Action<string> onTaskCompleted)
        {
            // Subscribe to the events.
            await _camundaClient.SubscribeToEventsAsync(onProcessInstanceCompleted, onTaskCompleted);

            // Return success.
            return Ok();
        }
        */
    }
}
/*
To use the CamundaClient class in your web API, you can inject an instance of the CamundaClient into your 
controller or service classes using dependency injection. For example:

    private readonly CamundaClient _camundaClient;

    public CamundaControllerExample(CamundaClient _camundaClient)
    {
        CamundaClient = _camundaClient;
    }

To continue, you can use the CamundaClient class in your web API to start process instances, query and 
update task variables, and complete tasks.

For example, if you want to query and update a task variable in Camunda, you can use the TaskService class 
to query the task and the VariableInstanceService class to update the task variable:

In this example, the UpdateTaskVariableAsync method queries the task with the specified ID using the TaskService and then 
updates the task variable with the specified name using the VariableInstanceService. It sets the value of the variable to 
the specified variableValue and the type of the variable to String.

You can also use the TaskService to complete tasks in Camunda. For example:

In this example, the CompleteTaskAsync method uses the TaskService to complete the task with the specified ID and variables.

For more information about using the Camunda API in a.NET web API, please see the Camunda API documentation:

https://docs.camunda.org/manual/latest/reference/rest/overview/


To continue, you can use the CamundaClient class to integrate Camunda with your .NET web API.

For example, you can use the CamundaClient to start a process instance when a user submits a form in your web API, 
and to query and update task variables when the user interacts with the task in your web API.

You can also use the CamundaClient to receive notifications when a process instance or task is completed in Camunda, 
and to update your web API accordingly. For example, you can use the ExecutionService and TaskService classes to 
subscribe to the processInstance.completed and task.completed events in Camunda, and to execute a callback method in 
your web API when these events occur:
*/