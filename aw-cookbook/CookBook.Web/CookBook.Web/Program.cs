using CookBook.Web.Api;
using CookBook.Web.Client.Pages;
using CookBook.Web.Components;


namespace CookBook.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddHttpClient();
            builder.Services.AddBff();
            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddAuthentication(options => {
                options.DefaultScheme = "cookie"; options.DefaultChallengeScheme = "oidc"; options.DefaultSignOutScheme = "oidc";
            }).AddCookie("cookie", options => {
                options.Cookie.Name = "__Host-blazor"; options.Cookie.SameSite = SameSiteMode.Strict;
            }).AddOpenIdConnect("oidc", options => {
                options.Authority = "https://localhost:5001"; options.ClientId = "cookbookclient";
                options.ClientSecret = "secret"; options.ResponseType = "code";
                options.ResponseMode = "query"; options.Scope.Clear();
                options.Scope.Add("openid"); options.Scope.Add("profile");
                options.Scope.Add("cookbookapi"); options.Scope.Add("offline_access");
                options.MapInboundClaims = false; options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
            });

            builder.Services.AddAuthorization();
            builder.Services.AddTransient<CookieAuthenticationHandler>();
            builder.Services.AddHttpClient("api")
             .AddHttpMessageHandler<CookieAuthenticationHandler>();

            builder.Services.AddScoped(serviceProvider =>
            {
                var httpClient = serviceProvider.GetService<IHttpClientFactory>().CreateClient("api");
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                return httpClient;
            });

            builder.Services.AddTransient<IIngredientsClient, IngredientsClient>();
            var app = builder.Build();
            


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
            app.UseAuthentication();
            app.UseBff();
            app.UseAuthorization();
            app.MapBffManagementEndpoints();

            app.Run();
        }
    }
}
