using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ekm.Mobile.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Ekm.Mobile.Services.RequestProvider
{
    /// <summary>
    /// https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
    /// http://jonathanpeppers.com/Blog/improving-http-performance-in-xamarin-applications
    /// </summary>
    public class RequestProvider : IRequestProvider
    {

        public RequestProvider()
        {
            _myHttpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            });

            _myHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _myHttpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            _myHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            //_serializerSettings = new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            //    NullValueHandling = NullValueHandling.Ignore
            //};
            //_serializerSettings.Converters.Add(new StringEnumConverter());

            _serializer = new JsonSerializer()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
            };

            _serializer.Converters.Add(new StringEnumConverter());

        }

        private readonly HttpClient _myHttpClient;
        private readonly JsonSerializer _serializer;

        //private readonly JsonSerializerSettings _serializerSettings;
        //public RequestProvider()
        //{
        //	_serializerSettings = new JsonSerializerSettings
        //	{
        //		ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //		DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        //		NullValueHandling = NullValueHandling.Ignore
        //	};
        //	_serializerSettings.Converters.Add(new StringEnumConverter());
        //}

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            var httpClient = CreateHttpClient(token);

            var response = await httpClient.GetAsync(uri);

            await HandleResponse(response);

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                TResult result = await Task.Run(() => _serializer.Deserialize<TResult>(json)).ConfigureAwait(false);
                return result;
            }

            //string serialized = await response.Content.ReadAsStringAsync();

            //TResult result = await Task.Run(() =>
            //  JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            //return result;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "")
        {
            HttpClient httpClient = CreateHttpClient(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            var content = new StringContent(JsonConvert.SerializeObject(data));
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                TResult result = await Task.Run(() => _serializer.Deserialize<TResult>(json)).ConfigureAwait(false);
                return result;
            }

            //string serialized = await response.Content.ReadAsStringAsync();

            //TResult result = await Task.Run(() =>
            //  JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            //return result;
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "", string header = "")
        {
            HttpClient httpClient = CreateHttpClient(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                TResult result = await Task.Run(() => _serializer.Deserialize<TResult>(json)).ConfigureAwait(false);
                return result;
            }

            //string serialized = await response.Content.ReadAsStringAsync();

            //TResult result = await Task.Run(() =>
            //  JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            //return result;
        }


        public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "")
        {
            HttpClient httpClient = CreateHttpClient(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            var content = new StringContent(JsonConvert.SerializeObject(data));
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);

            await HandleResponse(response);

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                TResult result = await Task.Run(() => _serializer.Deserialize<TResult>(json)).ConfigureAwait(false);
                return result;
            }

            //string serialized = await response.Content.ReadAsStringAsync();

            //TResult result = await Task.Run(() =>
            //  JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            //return result;
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string token = "", string header = "")
        {
            HttpClient httpClient = CreateHttpClient(token);

            if (!string.IsNullOrEmpty(header))
            {
                AddHeaderParameter(httpClient, header);
            }

            var content = new StringContent(JsonConvert.SerializeObject(data));
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);

            await HandleResponse(response);


            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                TResult result = await Task.Run(() => _serializer.Deserialize<TResult>(json)).ConfigureAwait(false);
                return result;
            }


            //string serialized = await response.Content.ReadAsStringAsync();

            //TResult result = await Task.Run(() =>
            //  JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            //return result;
        }


        public async Task DeleteAsync(string uri, string token = "")
        {
            HttpClient httpClient = CreateHttpClient(token);
            await httpClient.DeleteAsync(uri);
        }
        public async Task DeleteAsync<TRequest>(string uri, TRequest data, string token = "", string header = "")
        {
            HttpClient httpClient = CreateHttpClient(token);
            await httpClient.DeleteAsJsonAsync(uri, data);
        }

        private HttpClient CreateHttpClient(string token = "")
        {
            if (!string.IsNullOrEmpty(token))
            {
                _myHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return _myHttpClient;
        }

        private void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (httpClient == null)
                return;

            if (string.IsNullOrEmpty(parameter))
                return;

            httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }

        private void AddBasicAuthenticationHeader(HttpClient httpClient, string clientId, string clientSecret)
        {
            if (httpClient == null)
                return;

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
                return;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(clientId, clientSecret);
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
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

                throw httpRequestException;
            }
        }


    }
}
