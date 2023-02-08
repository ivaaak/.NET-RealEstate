<<<<<<< Updated upstream
﻿using RealEstate.API.Authentication.Contracts;
<<<<<<< Updated upstream
using RealEstate.Microservices.Serializer;
=======
<<<<<<< Updated upstream
using RealEstate.Microservices.Utils.Serializer;
=======
using RealEstate.Microservices.Serializer;
=======
﻿using Newtonsoft.Json;
using RealEstate.API.Authentication.Contracts;
>>>>>>> Stashed changes
>>>>>>> Stashed changes
>>>>>>> Stashed changes
using RealEstate.Models.Entities.Identity;
using System.Net.Http.Headers;

namespace RealEstate.API.Authentication
{
    public class Auth0Service : IAuth0Service
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        //private readonly IJsonSerializer jsonSerializer;

        public Auth0Service(
            IHttpClientFactory clientFactory,
            IConfiguration configuration)
            //IJsonSerializer jsonSerializer)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            //this.jsonSerializer = jsonSerializer;
        }


        // GET USER INFO
        public async Task<ApplicationUser> GetUserInfo(string accessToken)
        {
            var client = clientFactory.CreateClient();
            var domain = configuration["Auth0:Domain"];
            var userInfoEndpoint = $"https://{domain}/userinfo";

            // Set the authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Make the request to the userinfo endpoint
            var response = await client.GetAsync(userInfoEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve user info");
            }

            // Deserialize the response into an ApplicationUser object
            var responseContent = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<ApplicationUser>(responseContent);
            return user;
        }


        // GET ACCESS TOKEN
        public async Task<string> GetAccessToken(string code, string redirectUri)
        {
            var client = clientFactory.CreateClient();
            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];
            var clientId = configuration["Auth0:ClientId"];
            var clientSecret = configuration["Auth0:ClientSecret"];
            var tokenEndpoint = $"https://{domain}/oauth/token";

            // Build the request body
            var requestBody = new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["client_id"] = clientId,
                ["client_secret"] = clientSecret,
                ["code"] = code,
                ["redirect_uri"] = redirectUri,
                ["audience"] = audience
            };

            // Set the request content and content type
            var requestContent = new FormUrlEncodedContent(requestBody);
            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

            // Make the request to the token endpoint
            var response = await client.PostAsync(tokenEndpoint, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve access token");
            }

            // Deserialize the response into a dictionary
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

            // Return the access token
            return responseDictionary["access_token"];
        }


        // GET AUTHORIZATION URL
        public string GetAuthorizationUrl(string redirectUri, string state)
        {
            var domain = configuration["Auth0:Domain"];
            var clientId = configuration["Auth0:ClientId"];
            var authorizationEndpoint = $"https://{domain}/authorize";

            // Build the query string
            var queryString = new Dictionary<string, string>
            {
                ["client_id"] = clientId,
                ["response_type"] = "code",
                ["redirect_uri"] = redirectUri,
                ["state"] = state
            };

            // Return the authorization URL
            return $"{authorizationEndpoint}{queryString}";
        }


        // REVOKE ACCESS TOKEN
        public async Task RevokeAccessToken(string accessToken)
        {
            var client = clientFactory.CreateClient();
            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];
            var tokenEndpoint = $"https://{domain}/oauth/revoke";
            var clientId = configuration["Auth0:ClientId"];
            var clientSecret = configuration["Auth0:ClientSecret"];

            // Build the request body
            var requestBody = new Dictionary<string, string>
            {
                ["client_id"] = clientId,
                ["client_secret"] = clientSecret,
                ["token"] = accessToken,
                ["token_type_hint"] = "access_token",
                ["audience"] = audience
            };

            // Set the request content and content type
            var requestContent = new FormUrlEncodedContent(requestBody);
            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

            // Make the request to the token endpoint
            var response = await client.PostAsync(tokenEndpoint, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to revoke access token");
            }
        }


        // RENEW ACCESS TOKEN 
        public async Task<string> RenewAccessToken(string refreshToken)
        {
            var client = clientFactory.CreateClient();
            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];
            var tokenEndpoint = $"https://{domain}/oauth/token";
            var clientId = configuration["Auth0:ClientId"];
            var clientSecret = configuration["Auth0:ClientSecret"];

            // Build the request body
            var requestBody = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["client_id"] = clientId,
                ["client_secret"] = clientSecret,
                ["refresh_token"] = refreshToken,
                ["audience"] = audience
            };

            // Set the request content and content type
            var requestContent = new FormUrlEncodedContent(requestBody);
            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

            // Make the request to the token endpoint
            var response = await client.PostAsync(tokenEndpoint, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to renew access token");
            }

            // Deserialize the response into a dictionary
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

            // Return the access token
            return responseDictionary["access_token"];
        }
    }
}
