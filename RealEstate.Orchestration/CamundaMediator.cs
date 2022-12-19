using MediatR;
using Request = Camunda.Api.Client.Filter.FilterInfo.Request;

namespace RealEstate.Orchestration
{
    public class CamundaMediator //: IMediator
    {
        /*
        private readonly CamundaClient _camundaClient;

        public CamundaMediator(CamundaClient camundaClient)
        {
            _camundaClient = camundaClient;
        }

        async Task<TResponse> ISender.Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            // Send the request to the Camunda API and return the response.
            // The request and response types should be mapped to the corresponding Camunda API types.
            return await _camundaClient.SendRequestAsync<Request, TResponse>(request);
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            // Publish the notification to the Camunda API.
            // The notification type should be mapped to the corresponding Camunda API event.
            await _camundaClient.PublishEventAsync<TNotification>(notification);
        }




        Task<object?> ISender.Send(object request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        IAsyncEnumerable<TResponse> ISender.CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        IAsyncEnumerable<object?> ISender.CreateStream(object request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IPublisher.Publish(object notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        */
    }
}



/*
To combine Camunda with MediatR in a .NET web API, you can create a CamundaMediator class that uses 
MediatR to send and publish messages to the Camunda API.

For example, you can create a CamundaMediator class that contains a Send method that sends a request 
to the Camunda API and returns a response, and a Publish method that publishes an event to the Camunda API:

In this example, the CamundaMediator class implements the IMediator interface, and contains a Send method 
that sends a request to the Camunda API using the CamundaClient and returns the response, and a Publish 
method that publishes a notification to the Camunda API using the CamundaClient.

To use the CamundaMediator class in your web API, you can inject an instance of the CamundaMediator into 
your controller or service classes using dependency injection. 


To combine Camunda with MediatR in a .NET web API, you can create a CamundaMediator class that uses the
CamundaClient and IMediator classes to integrate Camunda with MediatR.

For example, you can create a CamundaMediator class that contains a Send method that sends a MediatR 
request to Camunda, and a Publish method that publishes a MediatR notification to Camunda:

In this example, the CamundaMediator class contains a Send method that sends a MediatR request to Camunda 
by starting a process instance with the request type name and full name as the process definition key and 
business key, respectively. It then sends the request to MediatR using the IMediator class, and completes 
the process instance after the request is handled. The Send method returns the response from MediatR.

The CamundaMediator class also contains a Publish method that publishes a MediatR notification to Camunda 
by starting a process instance with the notification type name and full name as the process definition key a
nd business key, respectively. It then publishes the notification to MediatR using the IMediator class, 
and completes the process instance after the notification is handled.

To use the CamundaMediator class in your web API, you can inject an instance of the CamundaMediator into 
your controller or service classes using dependency injection. For example:
*/