using LoginWithOTP.Applications;
using LoginWithOTP.Context;
using LoginWithOTP.Infrastructure.CacheManager;
using LoginWithOTP.Infrastructure.SmsService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder .Services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
builder.Services.AddSingleton<IOtpCacheManager,OtpCacheManager>();
builder.Services.AddSingleton<ISmsServiceProvider,SmsServiceProvider>();
builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
