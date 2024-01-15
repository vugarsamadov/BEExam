using System.ComponentModel.DataAnnotations;

namespace BEExam.Web.Models.Auth
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Please enter email")]
        [EmailAddress(ErrorMessage ="Email address invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Please enter password")]
        [Compare(nameof(RePassword),ErrorMessage ="Passwords should match!")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter password")]
        public string RePassword { get; set; }


    }
}
