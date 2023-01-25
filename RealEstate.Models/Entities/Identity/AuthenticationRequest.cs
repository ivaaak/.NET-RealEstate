namespace RealEstate.Models.Entities.Identity
{
    public class AuthenticationRequest
    {
        public string RequestId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
