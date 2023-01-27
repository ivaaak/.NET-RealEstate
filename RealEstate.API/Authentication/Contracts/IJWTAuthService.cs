using RealEstate.Models.Entities.Identity;

namespace RealEstate.API.Authentication.Contracts
{
    public interface IJWTAuthService
    {
        AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request);
    }
}
