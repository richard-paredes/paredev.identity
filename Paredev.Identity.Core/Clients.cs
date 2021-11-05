using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Paredev.Identity.Core
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = new[] {OidcConstants.GrantTypes.ClientCredentials},
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                    AllowedScopes = new List<string> {"api1.read"}
                }
            };
        }
    }
}