namespace LoginWithOTP.Models.Dto
{
    public record RegisterUserDto(string PhoneOrEmail,string Password,string ConfrimPassword);

    public record RegisterationFlow(string PhoneOrEmail);
}
