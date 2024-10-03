using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.SharedLibrary.DependencyInjection
{
    public static class JWTAuthenticationScheme
    {
        public static IServiceCollection AddJWTAuthenticationScheme(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Bearer", options =>
                {
                    //var key = Encoding.UTF8.GetBytes(config.GetSection("Authentication.Key").Value!);
                    //string issuer = config.GetSection("Authentication.Issuer").Value!;
                    //string audience = config.GetSection("Authentication.Audicence").Value!;
                    var key = Encoding.UTF8.GetBytes("qa12ed34TgH67JkiYK89LOF4Gf6Hy98Gtyuj7Ki34F");
                    string issuer = "http://localhost:5000";
                    string audience = "http://localhost:5000";

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)

                    };
                });
            return services;

        }
    }
}
