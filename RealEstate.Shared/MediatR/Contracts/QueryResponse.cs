using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RealEstate.Shared.MediatR.Contracts
{
    public class QueryResponse<T> where T : class
    {
        public T? Data { get; set; }

        public string? Message { get; set; }

        public QueryResponse(string message)
        {
            this.Message = message;
        }

        public QueryResponse(T Response)
        {
            this.Data = Response;
        }
        public QueryResponse()
        {
        }
    }
}
