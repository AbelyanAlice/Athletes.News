using Athletes.News.Core.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Athletes.News.Api.Installer
{
    public class AuthInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment emv)
        {
            //Configure Jwt
            var jwtSettings = new JwtSetting();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            // Setup authentication
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret!)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = new TimeSpan(DateTime.UtcNow.AddMonths(6).Ticks)
            };

            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });


            services.AddSingleton(tokenValidationParameters);
        }
    }
}
