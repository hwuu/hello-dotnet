namespace ApiServer
{
    public class EchoService2 : IEchoService
    {
        public string Echo(string s)
        {
            return "[2] " + s;
        }
    }
}
