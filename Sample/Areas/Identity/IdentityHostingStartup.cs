using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Sample.Areas.Identity.IdentityHostingStartup))]
namespace Sample.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SampleIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("SampleIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<SampleIdentityDbContext>();
                // services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
                //     {
                //         microsoftOptions.ClientId = context.Configuration.GetValue<string>("Microsoft:ClientId");
                //         microsoftOptions.ClientSecret = context.Configuration.GetValue<string>("Microsoft:ClientSecret");
                //         microsoftOptions.TokenEndpoint = $"https://login.microsoftonline.com/{context.Configuration.GetValue<string>("Microsoft:TenantId")}/oauth2/v2.0/token";
                //         microsoftOptions.AuthorizationEndpoint = $"https://login.microsoftonline.com/{context.Configuration.GetValue<string>("Microsoft:TenantId")}/oauth2/v2.0/authorize";
                //     });
            });
        }
    }
}