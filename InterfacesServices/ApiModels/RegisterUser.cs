using System.ComponentModel.DataAnnotations;
using Core;


namespace InterfacesServices.ApiModels
{
    public class RegisterUser
    {
        [EmailAddress(ErrorMessage="Email не валиден")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Пароль не валиден")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
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
