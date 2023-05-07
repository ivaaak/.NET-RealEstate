#nullable disable
namespace RealEstate.Shared.Orchestration.DTO
{
    public class ProcessDefinition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Version { get; set; }
        public string StartFormKey { get; set; }

        public override string ToString() => $"ProcessDefinition [Id={Id}, Key={Key}, Name={Name}]";
    }
}
