namespace RealEstate.Shared.Models.DTOs.Login
{
    public class LoginDTO
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}
