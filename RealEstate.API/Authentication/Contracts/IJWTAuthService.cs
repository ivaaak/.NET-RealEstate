using RealEstate.Shared.Models.Entities.Identity;

namespace RealEstate.API.Authentication.Contracts
{
    /// <summary>
    /// Provides methods for working with JWT Tokens
    /// </summary>
    public interface IJWTAuthService
    {
        /// <summary>
        /// Generates a JWT token from an AuthenticationRequest object.
        /// </summary>
        /// <param name="request">The AuthenticationRequest object containing authentication information.</param>
        /// <returns>A JWT token generated from the authentication information.</returns>

        AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request);
    }
}
