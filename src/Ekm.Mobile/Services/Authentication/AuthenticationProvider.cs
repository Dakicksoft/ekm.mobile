using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ekm.Mobile.Services.RequestProvider;
using Newtonsoft.Json;

namespace Ekm.Mobile.Services.Authentication
{
    public class AuthenticationProvider : IAuthenticate
    {
        private readonly HttpClient httpClient;
        public AuthenticationProvider()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient(new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip,
                });
            }

            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            httpClient.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        }

        public Task<Auth> Refresh()
        {
            throw new NotImplementedException();
        }

        public async Task<Auth> Token()
        {
            var builder = new UriBuilder(Helpers.AppConstants.GatewayUrl)
            {
                Path = $"connect/token",
            };
            var uri = builder.ToString();

            var code = await Helpers.SecureStorage.Get(Helpers.StorageKey.AuthorizationCode).ConfigureAwait(false);

            var encodedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id",Helpers.AppConstants.ClientKey),
                new KeyValuePair<string, string>("client_secret",Helpers.AppConstants.ClientSecret),
                new KeyValuePair<string, string>("code",code),
                new KeyValuePair<string, string>("grant_type","authorization_code"),
                new KeyValuePair<string, string>("redirect_uri",Helpers.AppConstants.RedirectUri)
            });

            HttpResponseMessage response = await httpClient.PostAsync(uri, encodedContent).ConfigureAwait(false);

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(serialized);

            return null;
            //return new Auth
            //{
            //    AccessToken = data.access_token,
            //    ExpiresIn = data.expires_in,
            //    TokenType = data.token_type,
            //    RefreshToken = data.refresh_token
            //};
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            //response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                  response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var serviceAuthException = new ServiceAuthenticationException(content);

                    throw serviceAuthException;
                }

                var httpRequestException = new HttpRequestExceptionEx(response.StatusCode, content);

                //Microsoft.AppCenter.Crashes.Crashes.TrackError(httpRequestException);
                throw httpRequestException;
            }
        }
    }
}
