using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using ChurnZeroApiClient.Settings;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using ChurnZeroApiClient.Models.Response;
using ChurnZeroApiClient.Core.Extensions;

namespace ChurnZeroApiClient.Core
{
    internal class ApiClientHandler : IApiClientHandler
    {
        readonly HttpClient _httpClient = new HttpClient();
        readonly ApiSettings _apiSettings = new ApiSettings();

        public ApiClientHandler(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
            _httpClient.BaseAddress = apiSettings.ApiBaseUrl;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string ApiKey
        {
            get
            {
                return _apiSettings.AppKey;
            }
        }

        public async Task<TOut> Post<TOut, TIn>(string requestUri, TIn model) where TOut : class
        {
            try
            {
                var responseMessage = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                });

                await CheckResponse(requestUri, responseMessage);

                return (TOut)(object)new BaseResponse { Status = responseMessage.StatusCode };
            }
            catch (WebException ex)
            {
                throw new ChurnZeroApiClientException($"Error for getting Uri ({requestUri}) response message. " +
                    $"{nameof(WebExceptionStatus)}: {ex.Status}", ex, ((HttpWebResponse)ex.Response).StatusCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TOut> Get<TOut, TIn>(TIn model) where TOut : class
        {
            var requestUri = CreateQueryWithApiKeyAndModelParams(model);

            try
            {
                var responseMessage = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri));

                await CheckResponse(requestUri, responseMessage);

                return (TOut)(object)new BaseResponse { Status = responseMessage.StatusCode };
            }
            catch (WebException ex)
            {
                throw new ChurnZeroApiClientException($"Error for getting Uri ({requestUri}) response message. " +
                    $"{nameof(WebExceptionStatus)}: {ex.Status}", ex, ((HttpWebResponse)ex.Response).StatusCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task CheckResponse(string requestUri, HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                var responseContent = responseMessage.Content == null
                    ? string.Empty
                    : await responseMessage.Content.ReadAsStringAsync();

                throw new ChurnZeroApiClientException($"Error for getting Uri ({requestUri}) response message. " +
                    $"{nameof(HttpStatusCode)}: {responseMessage.StatusCode}", responseContent, responseMessage.StatusCode);
            }
        }

        private string CreateQueryWithApiKeyAndModelParams<T>(T model)
        {
            var appKey = _apiSettings.AppKey;
            return string.Empty.AddQueryParam(nameof(appKey), appKey).AddQueryParams(model);
        }
    }
}
