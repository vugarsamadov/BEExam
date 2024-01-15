using System.ComponentModel.DataAnnotations;

namespace BEExam.Web.Models.Auth
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Please enter your email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Please enter your password")]
        public string Password { get; set; }

    }
}
