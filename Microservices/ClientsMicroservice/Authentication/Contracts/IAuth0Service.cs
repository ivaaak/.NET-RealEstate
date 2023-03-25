using RealEstate.Shared.Models.Entities.Identity;

namespace ClientsMicroservice.Authentication.Contracts
{
    /// <summary>
    /// Provides methods for authenticating users with Auth0.
    /// </summary>
    public interface IAuth0Service
    {
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <param name="accessToken">The access token obtained during the authentication process.</param>
        /// <returns>An <see cref="ApplicationUser"/> object containing information about the authenticated user.</returns>
        Task<ApplicationUser> GetUserInfo(string accessToken);

        /// <summary>
        /// Gets an access token using an authorization code.
        /// </summary>
        /// <param name="code">The authorization code obtained during the authentication process.</param>
        /// <param name="redirectUri">The redirect URI used during the authentication process.</param>
        /// <returns>A string containing the access token.</returns>
        Task<string> GetAccessToken(string code, string redirectUri);

        /// <summary>
        /// Gets the URL for the Auth0 authorization page.
        /// </summary>
        /// <param name="redirectUri">The redirect URI to use after the authentication process is completed.</param>
        /// <param name="state">An optional state parameter to include in the authorization URL.</param>
        /// <returns>A string containing the authorization URL.</returns>
        string GetAuthorizationUrl(string redirectUri, string state);

        /// <summary>
        /// Revokes an access token.
        /// </summary>
        /// <param name="accessToken">The access token to revoke.</param>
        Task RevokeAccessToken(string accessToken);

        /// <summary>
        /// Renews an access token using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token used to renew the access token.</param>
        /// <returns>A string containing the renewed access token.</returns>
        Task<string> RenewAccessToken(string refreshToken);

    }
}
