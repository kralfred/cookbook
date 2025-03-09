using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace CookBook.IdentityProvider.App
{
    public static class Config
    {

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
                {
                                
                new("roles") { UserClaims = new List<string> { "role" } },

                new ("cookbookapi", new List<string> { "ingredients" }),

                };

        public static IEnumerable<Client> Clients =>
            new Client[]
                { 

                new Client()
                {

                   

                    ClientName = "CookBook Client",
                    ClientId = "cookbookclient",
                    AllowOfflineAccess = true,
                    RequirePkce = true,
                    AllowedGrantTypes = new List<string> { GrantType.ClientCredentials,
                    GrantType.ResourceOwnerPassword,
                    GrantType.AuthorizationCode

                    },
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = new List<string> { "cookbookapi",
                        "roles",
                        IdentityServerConstants.StandardScopes.Profile, 
                        IdentityServerConstants.StandardScopes.OpenId,

                    },
                     RedirectUris = new List<string> { "https://oauth.pstmn.io/v1/callback",
                     "https://localhost:7011/signin-oidc" }     
                     

                }

                };
    }
}