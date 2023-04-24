using System.Text.Json.Serialization;

namespace RealEstate.Shared.MediatR.Contracts
{
    public class CommandResponse
    {
        [JsonInclude]
        public CommandStatus Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        public CommandResponse(CommandStatus Status = CommandStatus.Success)
        {
            this.Status = Status;
        }

        public CommandResponse(string Id, CommandStatus Status = CommandStatus.Success)
        {
            this.Status = Status;
            this.Id = Id;
        }
    }
}
