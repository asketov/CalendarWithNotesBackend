using Core;

namespace InterfacesServices.ApiModels
{
    public class LoginResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }

        public LoginResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            AccessToken = token;
        }
    }
}
