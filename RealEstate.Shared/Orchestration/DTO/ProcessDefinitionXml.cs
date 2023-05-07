#nullable disable
namespace RealEstate.Shared.Orchestration.DTO
{
    public class ProcessDefinitionXml
    {
        public string Id { get; set; }
        public string Bpmn20Xml { get; set; }

        public override string ToString() => $"ProcessDefinitionXml [Id={Id}]";
    }

}
