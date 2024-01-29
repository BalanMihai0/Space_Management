using System.ComponentModel.DataAnnotations;

namespace Individual_Sem2_Web.DTOs
{
    public class CreateGuestDTO
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Url]
        public string? ProfilePictureURL { get; set; }
    }
}
