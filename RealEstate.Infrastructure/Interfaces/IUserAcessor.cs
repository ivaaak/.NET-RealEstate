using System.Security.Claims;

namespace RealEstate.Infrastructure.Interfaces
{
    public interface IUserAccessor
    {
        ClaimsPrincipal User { get; }

        string UserId { get; }

        string Username { get; }
    }
}
