using Microsoft.IdentityModel.Tokens;
using RealEstate.API.Authentication.Contracts;
using RealEstate.Shared.Models.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.API.Authentication
{
    public class JWTAuthService : IJWTAuthService
    {
        public const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
        
        private const int JWT_TOKEN_VALIDITY_MINS = 20;

        private readonly IUserService userService;

        public JWTAuthService(IUserService _userService)
        {
            userService = _userService;
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.UserName) 
               || string.IsNullOrWhiteSpace(request.Password)) 
            { return null; }

            var user = userService.GetUserByUsernameAndPassword(request.UserName, request.Password).Result;
            if(user == null) { return null; };

            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, request.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = request.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
            };
        }
    }
}
