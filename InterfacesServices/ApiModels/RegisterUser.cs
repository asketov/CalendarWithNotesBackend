using System.ComponentModel.DataAnnotations;
using Core;


namespace InterfacesServices.ApiModels
{
    public class RegisterUser
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public User ToUser()
        {
            return new User()
            {
                Email = this.Email, Password = this.Password
            };
        }
    }
}
