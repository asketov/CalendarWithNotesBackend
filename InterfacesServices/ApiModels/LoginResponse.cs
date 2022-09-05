using Core;

namespace InterfacesServices.ApiModels
{
    public class LoginResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public LoginResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Token = token;
        }
    }
}
