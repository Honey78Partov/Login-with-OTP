using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LoginWithOTP.Context
{
    public class DataBaseContext(DbContextOptions<DataBaseContext> options):IdentityDbContext(options)
    {
    }
}
