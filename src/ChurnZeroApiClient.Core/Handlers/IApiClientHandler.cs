using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChurnZeroApiClient.Lib")]
namespace ChurnZeroApiClient.Core
{
    internal interface IApiClientHandler
    {
        Task<TOut> Post<TOut, TIn>(string requestUri, TIn model) where TOut : class;
        Task<TOut> Get<TOut, TIn>(TIn model) where TOut : class;
        string ApiKey { get; }
    }
}
