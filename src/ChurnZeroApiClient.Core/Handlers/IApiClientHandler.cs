using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChurnZeroApiClient.Lib")]
namespace ChurnZeroApiClient.Core
{
    internal interface IApiClientHandler
    {
        Task<TOut> Post<TOut, TIn>(string requestUri, TIn model) where TOut : class;
        Task<T> Get<T>(string requestUri) where T : class;
    }
}
