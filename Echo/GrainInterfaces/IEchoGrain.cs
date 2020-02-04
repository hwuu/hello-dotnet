using System.Threading.Tasks;

namespace ApiServer
{
    public interface IEchoGrain : Orleans.IGrainWithGuidKey
    {
        Task<string> Echo(string s);
    }
}
