using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace CustomFeature.TwitterApi
{
    public class TwitterApiClient : IDisposable
    {
        private const string DefaultConsumerKey = "24fMXFi4f6edMUwxOkopRoglE";
        private const string DefaultConsumerSecret = "DUKLBS5mfkHUU8FST59WYNp6okaxpSEPkTlErrIajl8QIRc0Mj";
        private string InputConsumerKey { get; set; }
        private string InputConsumerSecret { get; set; }
        private string ConsumerKey { get { return String.IsNullOrEmpty(InputConsumerKey) ? DefaultConsumerKey : InputConsumerKey; } }
        private string ConsumerSecret { get { return String.IsNullOrEmpty(InputConsumerSecret) ? DefaultConsumerSecret : InputConsumerSecret; } }
        private string BearerTokenCredentials
        {
            get
            {
                string encodedKey = HttpUtility.UrlEncode(ConsumerKey);
                string encodedSecret = HttpUtility.UrlEncode(ConsumerSecret);
                string token = $"{encodedKey}:{encodedSecret}";
                string encodedToken = token.Base64Encode();
                return encodedToken;
            }
        }
        private int Attempts { get; set; }
        private const int MaxAttemts = 2;
        public TwitterApiToken Token { get; set; }
        public bool Authorized { get { return Token != null; } }
        public TwitterApiClient(string key = null, string secret = null)
        {
            InputConsumerKey = key;
            InputConsumerSecret = secret;
            Token = GetToken();
        }
        public TwitterData[] GetStatuses(TwitterApiSearchType type)
        {
            TwitterData[] statuses = null;
            try
            {
                if (Authorized)
                {
                    Attempts++;
                    bool retry = false;
                    using (HttpClient client = new HttpClient())
                    {
                        Dictionary<string, string> param = type.Parameters;
                        string baseUrl = type.Url;
                        string url = $"{baseUrl}?{String.Join("&", param.Select(i => $"{i.Key}={i.Value}"))}";
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {Token.AccessToken}");
                        HttpResponseMessage response = client.GetAsync(url).Result;
                        switch (response.StatusCode)
                        {
                            case System.Net.HttpStatusCode.OK:
                                statuses = TwitterData.RenderFromTimeline(response.Content.ReadAsAsync<JToken>(new[] { new JsonMediaTypeFormatter() }).Result);
                                break;
                            case System.Net.HttpStatusCode.Unauthorized:
                                TwitterApiError error = response.Content.ReadAsAsync<TwitterApiError>(new[] { new JsonMediaTypeFormatter() }).Result;
                                if (error?.Messages?.FirstOrDefault(i => i.Code == "89") != null)
                                    retry = true;
                                break;
                            default:
                                //response.Content.ReadAsStringAsync().Result
                                break;
                        }
                    }
                    if (retry && Attempts < MaxAttemts)
                    {
                        RefreshToken();
                        statuses = GetStatuses(type);
                    }
                }
                else
                {
                    //Token unavailable
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error at CreateToken : {0}", e.LastInnerException().Message);
            }
            return statuses;
        }
        private void RefreshToken()
        {
            InvalidateToken();
            Token = GetToken();
        }
        private TwitterApiToken GetToken()
        {
            TwitterApiToken token = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Dictionary<string, string> form = new Dictionary<string, string>
                    {
                        {"grant_type", "client_credentials"}
                    };
                    string url = "https://api.twitter.com/oauth2/token";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {BearerTokenCredentials}");
                    HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(form)).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        token = response.Content.ReadAsAsync<TwitterApiToken>(new[] { new JsonMediaTypeFormatter() }).Result;
                        token.AccessToken = HttpUtility.UrlDecode(token.AccessToken);
                    }
                    else
                    {
                        //response.Content.ReadAsStringAsync().Result
                    }
                }
            }
            catch (Exception e)
            {
                ////Console.WriteLine("Error at CreateToken : {0}", e.LastInnerException().Message);
            }
            return token;
        }
        private void InvalidateToken()
        {
            try
            {
                if (Authorized)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        Dictionary<string, string> form = new Dictionary<string, string>
                        {
                            {"access_token", Token.AccessToken}
                        };
                        string url = "https://api.twitter.com/oauth2/invalidate_token";
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {BearerTokenCredentials}");
                        HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(form)).Result;
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Token = null;
                        }
                        else
                        {
                            //response.Content.ReadAsStringAsync().Result
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ////Console.WriteLine("Error at InvalidateToken : {0}", e.LastInnerException().Message);
            }
        }
        public void Dispose()
        {
            InvalidateToken();
        }
    }
}