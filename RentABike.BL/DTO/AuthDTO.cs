using System;
using System.ComponentModel.DataAnnotations;

namespace RentAVehicle.BL.DTO
{
    public class AuthDTO
    {
        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string DriverLicenseNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
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
    }
}
