using EMailAPI.Domain.Interfaces;
using EMailAPI.Helper;

namespace EMailAPI.Settings;

public static class EmailServiceBuilder
{
    public static IServiceCollection EmailBuilder(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddTransient<IEmailSender, EmailHelper>();
        return Services;
    }
}