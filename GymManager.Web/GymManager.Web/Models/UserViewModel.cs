using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }


        [EmailAddress]
        [Required]
        [StringLength(258)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        [Phone]
        public string PhoneNumber { get; set; }

        
        [Required]
        [StringLength(64, MinimumLength = 5)]
        [RegularExpression(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])(?=\w*[~,.`*_+?¿!¡´'#$%\-])\S{5,64}$", ErrorMessage = "Password must contain at least: one uppercase letter, one lowercase letter, one symbol and be between 5 and 25 characters long")]
        public string Password { get; set; }


    }
}
