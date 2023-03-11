using RealEstate.Shared.Core.Constants;
using System.Security.Claims;
using System.Security.Principal;

namespace RealEstate.Shared.Core.Extensions
{
    public static class PrincipalExtension
    {
        /// <summary>
        /// Tries to get the tenantId from the authenticated principal.
        /// </summary>
        /// <param name="principal">the authenticated principal</param>
        /// <param name="tenantId">the principal's tenantId</param>
        /// <returns></returns>
        public static bool TryGetTenantId(this IPrincipal principal, out Guid tenantId)
        {
            if (principal is ClaimsPrincipal == false)
            {
                tenantId = Guid.Empty;

                return false;
            }

            Claim claim = (principal as ClaimsPrincipal).FindFirst(KnownClaimTypes.TenantId);

            return Guid.TryParse(claim?.Value, out tenantId);
        }

        /// <summary>
        /// Tries to get the userId from the authenticated principal
        /// </summary>
        /// <param name="principal">the authenticated principal</param>
        /// <param name="userId">the principal's userId</param>
        /// <returns></returns>
        public static bool TryGetUserId(this IPrincipal principal, out Guid userId)
        {
            if (principal is ClaimsPrincipal == false)
            {
                userId = Guid.Empty;

                return false;
            }

            Claim claim = (principal as ClaimsPrincipal).FindFirst(KnownClaimTypes.UserId);

            return Guid.TryParse(claim?.Value, out userId);
        }

        /// <summary>
        /// Tries to get the email from the authenticated principal
        /// </summary>
        /// <param name="principal">the authenticated principal</param>
        /// <param name="email">the principal's email</param>
        /// <returns></returns>
        public static bool TryGetEmail(this IPrincipal principal, out string email)
        {
            if (principal is ClaimsPrincipal == false)
            {
                email = null;

                return false;
            }

            Claim claim = (principal as ClaimsPrincipal).FindFirst(ClaimTypes.Email);

            if (claim == null || string.IsNullOrEmpty(claim.Value) == true)
            {
                email = null;

                return false;
            }

            email = claim.Value;

            return true;
        }
    }
}
