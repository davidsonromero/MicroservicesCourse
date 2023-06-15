﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> apiScopes = new List<ApiScope>()
        {
            new ApiScope("geek_shopping", "GeekShopping Server"),
            new ApiScope("read", "Read Data"),
            new ApiScope("write", "Write Data"),
            new ApiScope("delete", "Delete Data")
        };

        public static IEnumerable<Client> clients = new List<Client>()
        {
            new Client
            {
                ClientId = "Client",
                ClientSecrets = { new Secret("Laidnummetoansariemlap".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "read",
                    "write",
                    "profile"
                }
            },

            new Client
            {
                ClientId = "GeekShopping",
                ClientSecrets = { new Secret("Laidnummetoansariemlap".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "geek_shopping"
                }, 
                RedirectUris = 
                {
                    "https://localhost:4430/signin-oidc"
                },
                PostLogoutRedirectUris =
                {
                    "https://localhost:4430/signout-callback-oidc"
                }
            }
        };
    }
}
