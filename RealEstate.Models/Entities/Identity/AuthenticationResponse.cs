namespace RealEstate.Models.Entities.Identity
{
    public class AuthenticationResponse
    {
        public string ResponseId { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
