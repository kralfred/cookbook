using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

namespace CookBook.Web;

public class CookieAuthenticationHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext is not null)
        {
            var userToken = await httpContext.GetUserAccessTokenAsync();
            if (userToken is not null)
            {
                request.Headers.Authorization = new(JwtBearerDefaults.AuthenticationScheme, userToken.AccessToken);
            }
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
