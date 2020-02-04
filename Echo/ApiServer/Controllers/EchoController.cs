using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EchoController : ControllerBase
    {
        private readonly IEchoService _echoService;

        public EchoController(IEchoService echoService)
        {
            _echoService = echoService;
        }

        [HttpGet]
        public string Echo(string s = "<null>")
        {
            return _echoService.Echo(s);
        }
    }
}
