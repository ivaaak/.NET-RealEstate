namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    public class JwtSecrets
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecurityKey { get; set; }
    }
}
