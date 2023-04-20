using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace pandora_intelligence_assignment.ApiKey
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        const string API_KEY = "2dd2d536-6097-46a2-8b5a-f4eb24e3fb75";
        public bool IsValid(string apiKey)
        {
            if (apiKey == API_KEY) return true;
            return false;
        }
    }

  
}
