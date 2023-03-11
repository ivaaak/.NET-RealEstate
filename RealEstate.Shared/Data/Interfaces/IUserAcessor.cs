using System.Security.Claims;

namespace RealEstate.Shared.Data.Interfaces
{
    public interface IUserAccessor
    {
        ClaimsPrincipal User { get; }

        string UserId { get; }

        string Username { get; }
    }
}
