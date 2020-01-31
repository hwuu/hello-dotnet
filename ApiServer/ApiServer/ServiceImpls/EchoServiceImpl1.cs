namespace ApiServer
{
    public class EchoServiceImpl1 : IEchoService
    {
        public string Echo(string s)
        {
            return "[1] " + s;
        }
    }
}
