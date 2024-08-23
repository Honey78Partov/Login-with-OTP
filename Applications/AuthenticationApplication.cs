using LoginWithOTP.Infrastructure.CacheManager;
using LoginWithOTP.Infrastructure.SmsService;
using LoginWithOTP.Models;
using LoginWithOTP.Models.Dto;
using LoginWithOTP.Models.Enums;
using LoginWithOTP.Utilities;
using Microsoft.AspNetCore.Identity;

namespace LoginWithOTP.Applications
{
    public class AuthenticationApplication(UserManager<IdentityUser> userManager,
        IOtpCacheManager cacheManager,
        ISmsServiceProvider smsService) : IAuthenticationApplication
    {

        public async Task<RegisterationFlowResultDto> RegisterationFlow(RegisterationFlow registerDto)
        {
            var registerFlow = EmailValidator.IsItEmail(registerDto.PhoneOrEmail) ? RegisterFlowEnum.Email : RegisterFlowEnum.PhoneNumber;


            if (registerFlow == RegisterFlowEnum.Email)
            {
                if (!EmailValidator.IsValid(registerDto.PhoneOrEmail))
                    throw new Exception("ایمیل غیر معتبر است");

                var user = userManager.Users.FirstOrDefault(p => p.Email.Equals(registerDto.PhoneOrEmail));
                if (user != null)
                {
                    return new RegisterationFlowResultDto(UserTypeEnum.Old);
                }

                return new RegisterationFlowResultDto(UserTypeEnum.New);
            }
            else
            {
                if (!PhoneNumberValidator.IsValid(registerDto.PhoneOrEmail))
                {
                    throw new Exception(" شماره تلفن غیر معتبر است");
                }

                var user = userManager.Users.FirstOrDefault(p => p.PhoneNumber.Equals(registerDto.PhoneOrEmail);
                if (user !=null)
                {
                    return new RegisterationFlowResultDto(UserTypeEnum.Old);
                }

                

                var mycode = OtpManager.GenerateNewCode();
                cacheManager.AddOtp(registerDto.PhoneOrEmail, mycode.ToString());
                await smsService.SendSms();

                return new RegisterationFlowResultDto(UserTypeEnum.New);

            }
        }

        public async Task RegisterUser(RegisterUserDto registerUserDto, CancellationToken token)
        {
            if (string.IsNullOrEmpty(registerUserDto.PhoneOrEmail))
            {
                throw new Exception(" مقدار ورودی غیر معتبر است");
            }


            if (string.IsNullOrEmpty(registerUserDto.Password) || string.IsNullOrEmpty(registerUserDto.ConfrimPassword) || !registerUserDto.Password.Equals(registerUserDto.ConfrimPassword))
            {
                throw new Exception("پسورد غیر مجاز است");
            }
             
            var newUser = new IdentityUser()
            {
                Email=registerUserDto.PhoneOrEmail,
                EmailConfirmed=false,
                PasswordHash=registerUserDto.Password,
                UserName=registerUserDto.PhoneOrEmail,
                NormalizedUserName=registerUserDto.PhoneOrEmail,
                NormalizedEmail=registerUserDto.PhoneOrEmail
            };
            await userManager.CreateAsync(newUser);
        }
    }
}
