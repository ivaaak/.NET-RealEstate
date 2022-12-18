using RealEstate.Models.Entities.AuthUser;

namespace RealEstate.Microservices.Contracts
{
    public interface IAuth0AuthenticationService
    {
        // GET USER INFO
        Task<Auth0User> GetUserInfo(string accessToken);

        // GET ACCESS TOKEN
        Task<string> GetAccessToken(string code, string redirectUri);

        // GET AUTHORIZATION URL
        string GetAuthorizationUrl(string redirectUri, string state);

        // REVOKE ACCESS TOKEN
        Task RevokeAccessToken(string accessToken);

        // RENEW ACCESS TOKEN 
        Task<string> RenewAccessToken(string refreshToken);
    }
}
