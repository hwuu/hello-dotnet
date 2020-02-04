namespace ApiServer
{
    public class EchoService1 : IEchoService
    {
        public string Echo(string s)
        {
            return "[1] " + s;
        }
    }
}
