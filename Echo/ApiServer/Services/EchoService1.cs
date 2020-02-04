namespace ApiServer
{
    public class EchoService1 : IEchoService
    {
        public string Echo(string s)
        {
            string result = s;
            for (int i = 1; i < s.Length; i++)
            {
                result += " " + s.Substring(i);
            }
            return result;
        }
    }
}
