using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using ChurnZeroApiClient.Settings;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace ChurnZeroApiClient.Core
{
    internal class ApiClientHandler : IApiClientHandler
    {
        readonly HttpClient _httpClient = new HttpClient();

        public ApiClientHandler(IOptions<ApiSettings> apiSettings)
        {
            _httpClient.BaseAddress = apiSettings.Value.ApiBaseUrl;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

                return JsonConvert.DeserializeObject<TOut>(await responseMessage.Content.ReadAsStringAsync());
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

        public async Task<T> Get<T>(string requestUri) where T : class
        {
            try
            {
                var responseMessage = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri));

                await CheckResponse(requestUri, responseMessage);

                return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
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
    }
}
