using System.Collections.ObjectModel;

namespace RealEstate.CQRS.RequestModels
{
    public class Request
    {
        //This is a placeholder and to be redone
        private readonly IList<string> data = new List<string>();

        public IEnumerable<string> Data { get; }    
    }
}
