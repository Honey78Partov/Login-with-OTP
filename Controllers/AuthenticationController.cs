using LoginWithOTP.Applications;
using LoginWithOTP.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithOTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationApplication authentication) : ControllerBase
    {
        [HttpPost]
        public async Task<RegisterationFlowResultDto> RegisterationFlow(RegisterationFlow registerDto,CancellationToken token)
        {
            return await authentication.RegisterationFlow(registerDto)
        }



        [HttpPost]
        public async Task RegisterUser(RegisterUserDto registerUserDto, CancellationToken token)
        {
            await authentication.RegisterUser(registerUserDto, token);
        }
    }
}
