namespace DentistsApp.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using DentistApp.Data.Models;
    using DentistApp.Web.Infrastructure.Mapping;

    public class RegisterViewModel : IMapFrom<DentistApp.Data.Models.User>
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "UIN")]
        public string Uin { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }
    }
}