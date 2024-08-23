namespace LoginWithOTP.Infrastructure.SmsService
{
    public interface ISmsServiceProvider
    {
        Task SendSms();
    }
}
