#nullable disable
using System.Security.Claims;

namespace ClientsMicroservice.Data
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetLoggedInUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

            return new Guid(loggedInUserId);
        }

        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            // Keycloak.AuthServices sets NameClaimType = "preferred_username", so there is no ClaimTypes.Name claim
            return principal.Identity?.Name;
        }

        public static string GetLoggedInUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.Email).Value;
        }
    }
}
