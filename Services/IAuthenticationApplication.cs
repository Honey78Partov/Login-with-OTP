using LoginWithOTP.Models.Dto;

namespace LoginWithOTP.Services
{
    public interface IAuthenticationApplication
    {
        Task RegisterUser(RegisterUserDto registerUserDto, CancellationToken token);


    }
    public class AuthenticationApplication : IAuthenticationApplication
    {
        public Task RegisterUser(RegisterUserDto registerUserDto, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
