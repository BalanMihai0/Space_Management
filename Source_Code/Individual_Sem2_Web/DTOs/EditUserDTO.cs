using System.ComponentModel.DataAnnotations;

namespace Individual_Sem2_Web.DTOs
{
    public class EditUserDTO
    {
        [Required]
        public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
        [Required][EmailAddress] public string? Email { get; set; }
        public string? ProfilePictureUrl { get;set; }
        [Required] public DateTime BirthDate { get; set; }

    }
}
