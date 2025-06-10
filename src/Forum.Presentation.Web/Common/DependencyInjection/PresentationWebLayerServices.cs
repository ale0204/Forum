using Forum.Presentation.Web.Common.Api;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Forum.Presentation.Web.Common.DependencyInjection;

public static class PresentationWebLayerServices
{
    public static IServiceCollection AddPresentationWebLayerServices(this IServiceCollection services)
    {
        services.AddHttpClient<IApiHttpClient, ApiHttpClient>();
        services.AddHttpContextAccessor();
        // configure cookie-based authentication
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(cookieAuthenticationOptions =>
            {
                // basic path configuration
                cookieAuthenticationOptions.LoginPath = "/auth/login";
                cookieAuthenticationOptions.LogoutPath = "/auth/logout";

                // cookie configuration
                cookieAuthenticationOptions.Cookie = new CookieBuilder
                {
                    Name = ".Forum.Auth", // unique name to avoid conflicts
                    HttpOnly = true,       // prevent JavaScript access
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.Always, // require HTTPS
                    Path = "/",            // make cookie available for all paths
                    IsEssential = true     // mark as essential for GDPR
                };

                // security settings
                cookieAuthenticationOptions.ExpireTimeSpan = TimeSpan.FromHours(24); // TODO: perhaps make it configurable by user?
                cookieAuthenticationOptions.SlidingExpiration = true;
            });
        services.AddSession(sessionOptions =>
        { 
            sessionOptions.IdleTimeout = TimeSpan.FromMinutes(30); // session expires after 30 minutes of inactivity
            sessionOptions.Cookie.HttpOnly = true; // prevent JavaScript access to session cookie, for security
            sessionOptions.Cookie.IsEssential = true; // mark session cookie as essential, for GDPR compliance

        });


        return services;
    }
}
