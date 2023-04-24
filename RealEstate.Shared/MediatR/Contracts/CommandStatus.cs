using System.Runtime.Serialization;

namespace RealEstate.Shared.MediatR.Contracts
{
    public enum CommandStatus
    {
        [EnumMember(Value = "Success")] Success,
        [EnumMember(Value = "Failed")] Failed
    }
}
