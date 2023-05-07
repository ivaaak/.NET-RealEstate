#nullable disable
namespace RealEstate.Shared.MediatR.BehaviorModels.RequestModels
{
    public class Request
    {
        //This is a placeholder and to be redone
        private readonly IList<string> data = new List<string>();

        public IEnumerable<string> Data { get; }
    }
}
