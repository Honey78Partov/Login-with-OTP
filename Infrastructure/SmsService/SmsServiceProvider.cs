namespace LoginWithOTP.Infrastructure.SmsService
{
    public class SmsServiceProvider : ISmsServiceProvider
    {
        public Task SendSms()
        {
            return Task.CompletedTask;
        }
    }
}
