using LoginWithOTP.Models.Dto;

namespace LoginWithOTP.Applications
{
    public interface IAuthenticationApplication
    {
        Task RegisterUser(RegisterUserDto registerUserDto, CancellationToken token);
        Task<RegisterationFlowResultDto> RegisterationFlow(RegisterationFlow registerDto);

    }
}
