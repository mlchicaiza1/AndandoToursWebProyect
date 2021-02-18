using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Services
{
    public class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        
        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }
        // Key paypal y clientSecret
        // Create the configuration map that contains mode and other optional configuration details.
        public static Dictionary<string, string> GetConfig()
        {
            // ConfigManager.Instance.GetProperties(); // it doesn't work on ASPNET 5
            return new Dictionary<string, string>() {
                { "clientId", "ARqsLyHHsb9iXlU8wqGhRm1JFOdKNj4KOu0X7Kl7tE3RBX5rjPoXEdlFsSZtA7E7mRIZ3OxRiC59zJhW" },
                { "clientSecret", "EB1C7mJ_aDxADEmvZ7bpfa5CehB4atE_d-A56DMM9Vwze6vsz_01UYwqFXl8cinczRAvL4rMMiUYapNI" }
            };
        }

        // Create accessToken
        private static string GetAccessToken()
        {
            // ###AccessToken
            // Retrieve the access token from OAuthTokenCredential by passing in
            // ClientID and ClientSecret
            // It is not mandatory to generate Access Token on a per call basis.
            // Typically the access token can be generated once and reused within the expiry window                
            string accessToken = new OAuthTokenCredential
                (ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        // Returns APIContext object
        public static APIContext GetAPIContext(string accessToken = "")
        {
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            var apiContext = new APIContext(string.IsNullOrEmpty(accessToken) ?
                GetAccessToken() : accessToken);
            apiContext.Config = GetConfig();

            return apiContext;
        }
    }
}
