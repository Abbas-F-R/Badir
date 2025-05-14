using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ReactNative.Extensions;

public static class ApplicationSecurityExtension
{
    public static IServiceCollection AddSecurityExtension(this IServiceCollection services, IConfiguration config)
    {
        // تحميل متغيرات .env
        Env.Load();

        // تحميل القيم من متغيرات البيئة
        var secretKey = Environment.GetEnvironmentVariable("TOKEN");
        var googleClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
        var googleClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

        if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(googleClientId) || string.IsNullOrEmpty(googleClientSecret))
        {
            throw new InvalidOperationException("One or more environment variables (TOKEN, GOOGLE_CLIENT_ID, GOOGLE_CLIENT_SECRET) are not set.");
        }

        // Swagger Security
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = googleClientId;
                options.ClientSecret = googleClientSecret;
                options.CallbackPath = "/signin-google"; // مهم جداً يتطابق مع Google Console
                options.SaveTokens = true;
            });

        // إضافة الصلاحيات من Enum
        services.AddAuthorization(options =>
        {
            foreach (var permission in Enum.GetValues<PermissionType>())
            {
                options.AddPolicy(permission.ToString(), policy =>
                    policy.RequireClaim("Permission", permission.ToString()));
            }
        });

        services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

        return services;
    }
}
