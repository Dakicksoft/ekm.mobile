using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Ekm.Mobile.Extensions;
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
                httpClient = new HttpClient();
            }

            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public Task<Auth> Refresh()
        {
            throw new NotImplementedException();
        }

        public async Task<Auth> Token()
        {
            var code = await Xamarin.Essentials.SecureStorage.GetAsync(Helpers.StorageKey.AuthorizationCode).ConfigureAwait(false);

            var builder = new UriBuilder(Helpers.AppConstants.GatewayUrl)
            {
                Path = "connect/token",
            };
            var uri = builder.ToString();


            var encodedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id",Helpers.AppConstants.ClientKey),
                new KeyValuePair<string, string>("client_secret",Helpers.AppConstants.ClientSecret),
                new KeyValuePair<string, string>(nameof(code),code),
                new KeyValuePair<string, string>("grant_type","authorization_code"),
                new KeyValuePair<string, string>("redirect_uri",Helpers.AppConstants.RedirectUri)
            });

            HttpResponseMessage response = await httpClient.PostAsync(uri, encodedContent).ConfigureAwait(false);

            await HandleResponse(response);

            var data = await response.Content.ReadAsJsonAsync<Auth>();


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
