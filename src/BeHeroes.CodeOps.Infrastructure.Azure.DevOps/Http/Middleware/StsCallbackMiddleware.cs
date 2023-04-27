using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Caching;
using BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Http.Middleware
{
    public sealed class StsCallbackMiddleware : IMiddleware
    {
        private readonly IMemoryCache _cache;
        private readonly IOptions<AdoClientOptions> _options;
        private readonly HttpClient _httpClient;

        public StsCallbackMiddleware(IMemoryCache cache, IOptions<AdoClientOptions> options, HttpClient client)
        {
            _cache = cache;
            _options = options;
            _httpClient = client;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.Value == _options.Value.RedirectUri?.AbsolutePath)
            {
                if (!context.Request.QueryString.HasValue || !context.Request.QueryString.Value.Contains("code"))
                {
                    throw new Exception("Missing code query param in oauth2 callback");
                }

                Microsoft.Extensions.Primitives.StringValues? oauthCodes = null;

                try
                {
                    var queryCodes = QueryHelpers.ParseQuery(context.Request.QueryString.Value)["code"];

                    if(queryCodes != Microsoft.Extensions.Primitives.StringValues.Empty)
                        oauthCodes = queryCodes;
                }
                catch(KeyNotFoundException exp){
                    throw new AdoClientException(exp.Message, exp?.InnerException);
                }

                var formData = new Dictionary<string, string>();

                formData.Add("client_assertion", _options.Value.ClientSecret);
                formData.Add("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer");
                formData.Add("grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer");
                formData.Add("redirect_uri", _options.Value.RedirectUri.AbsoluteUri);

                if(oauthCodes.HasValue)
                    formData.Add("assertion", oauthCodes.Value.ToString());
                else
                    throw new AdoClientException("No valid assertion found in querystring");

                var stsResponse = await _httpClient.PostAsync(_options.Value.TokenService.AbsoluteUri, new FormUrlEncodedContent(formData));
                var stsResponseData = await stsResponse.Content.ReadAsStringAsync();
                var stsPayload = JsonSerializer.Deserialize<StsDto>(stsResponseData);
                var tokenHandler = new JwtSecurityTokenHandler();

                if (tokenHandler.CanReadToken(stsPayload?.AccessToken))
                {
                    var token = tokenHandler.ReadJwtToken(stsPayload?.AccessToken);

                    if (double.TryParse(stsPayload?.ExpiresIn, out double expires))
                    {
                        _cache.Set(CacheKeys.ClientSecretKey, token, TimeSpan.FromSeconds(expires));
                    }
                }
            }

            await next(context);
        }
    }
}
