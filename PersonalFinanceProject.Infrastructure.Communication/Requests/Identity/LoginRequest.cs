using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceProject.Infrastructure.Communication.Requests.Identity
{
    public record LoginRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
    }
}