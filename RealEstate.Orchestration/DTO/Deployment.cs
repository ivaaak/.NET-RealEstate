namespace RealEstate.Orchestration.DTO
{
    public class Deployment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }

        public override string ToString() => $"Deployment [Id={Id}, Name={Name}]";
    }
}
