using System.Threading.Tasks;

namespace ApiServer
{
    public class EchoGrain : Orleans.Grain, IEchoGrain
    {
        Task<string> IEchoGrain.Echo(string s)
        {
            string result = s;
            for (int i = 1; i < s.Length; i++)
            {
                result += " " + s.Substring(i);
            }
            return Task.FromResult(result);
        }
    }
}
