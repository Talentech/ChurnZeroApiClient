using System.Threading.Tasks;

namespace ChurnZeroApiClient.Core
{
    internal interface IApiClientHandler
    {
        Task<TOut> Post<TOut, TIn>(string requestUri, TIn model) where TOut : class;
        Task<T> Get<T>(string requestUri) where T : class;
    }
}
