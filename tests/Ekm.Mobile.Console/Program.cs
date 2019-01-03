using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Flurl.Http;

namespace Ekm.Mobile.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = "https://api.ekm.net/connect/token"
                .SendUrlEncodedAsync(HttpMethod.Post, new
                {
                    client_id = "42d5671f-3549-4d67-be7e-1256b527fc0f",
                    client_secret = "9c3750c6-d009-41e7-8793-20119ea717bc",
                    code = "9b213a8c7f7200a380e3716f797fc84fcce98b2bbb35e7afcb4c183bdff0c682",
                    grant_type = "authorization_code",
                    redirect_uri = "http://www.dakicksoft.com"
                })
                .ReceiveJson<dynamic>().GetAwaiter().GetResult();



            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            ////client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


            //client.BaseAddress = new Uri("https://api.ekm.net");
            //var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token");

            //var keyValues = new List<KeyValuePair<string, string>>();
            //keyValues.Add(new KeyValuePair<string, string>("client_id", "42d5671f-3549-4d67-be7e-1256b527fc0f"));
            //keyValues.Add(new KeyValuePair<string, string>("client_secret", "9c3750c6-d009-41e7-8793-20119ea717bc"));
            //keyValues.Add(new KeyValuePair<string, string>("code", "9b213a8c7f7200a380e3716f797fc84fcce98b2bbb35e7afcb4c183bdff0c682"));
            //keyValues.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            //keyValues.Add(new KeyValuePair<string, string>("redirect_uri", "http://www.dakicksoft.com"));

            //request.Content = new FormUrlEncodedContent(keyValues);
            //var response =  client.SendAsync(request).GetAwaiter().GetResult();

            //var httpClient=new HttpClient();

            //var builder = new UriBuilder("https://api.ekm.net")
            //{
            //    Path = "connect/token",
            //};
            //var uri = builder.ToString();


            //var encodedContent = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string, string>("client_id","42d5671f-3549-4d67-be7e-1256b527fc0f"),
            //    new KeyValuePair<string, string>("client_secret","9c3750c6-d009-41e7-8793-20119ea717bc"),
            //    new KeyValuePair<string, string>("code","9b213a8c7f7200a380e3716f797fc84fcce98b2bbb35e7afcb4c183bdff0c682"),
            //    new KeyValuePair<string, string>("grant_type","authorization_code"),
            //    new KeyValuePair<string, string>("redirect_uri","http://www.dakicksoft.com")
            //});

            //var response = httpClient.PostAsync(uri, encodedContent).GetAwaiter().GetResult();

        }
    }
}
