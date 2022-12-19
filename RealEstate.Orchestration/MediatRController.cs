using MediatR;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace RealEstate.Orchestration
{
    public class MediatorController : Controller
    {
        private readonly IMediator _mediator;

        public MediatorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /*
        [HttpPost]
        public async Task<IActionResult> SubmitForm(SubmitFormRequest request)
        {
            // Send the request to the Camunda API using the mediator.
            var response = await _mediator.Send(request);

            // Return the response.
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskVariable(UpdateTaskVariableRequest request)
        {
            // Send the request to the Camunda API using the mediator.
            await _mediator.Send(request);

            // Return success.
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CompleteTask(CompleteTaskRequest request)
        {
            // Send the request to the Camunda API using the mediator.
            await _mediator.Send(request);

            // Return success.
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeToEvents(SubscribeToEventsRequest request)
        {
            // Send the request to the Camunda API
        }
        */
    }
}
