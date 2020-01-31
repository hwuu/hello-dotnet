namespace ApiServer
{
    public class EchoServiceImpl2 : IEchoService
    {
        public string Echo(string s)
        {
            return "[2] " + s;
        }
    }
}
