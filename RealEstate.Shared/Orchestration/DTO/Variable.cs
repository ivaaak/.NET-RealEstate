#nullable disable
namespace RealEstate.Shared.Orchestration.DTO
{
    public class Variable
    {
        // lower case to generate JSON
        public string Type { get; set; }
        public object Value { get; set; }
        public object ValueInfo { get; set; }
    }
}
