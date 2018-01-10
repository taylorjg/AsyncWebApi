using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace AsyncWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AsyncController : Controller
    {
        ILogger<AsyncController> _logger;

        public AsyncController(ILogger<AsyncController> logger)
        {
            _logger = logger;
        }

        private const string remoteUrl1 = "http://httpbin.org/delay/1";
        private const string remoteUrl2 = "http://httpbin.org/bytes/10000";

        [HttpGet()]
        public async Task<int> Get()
        {
            var httpClient = new HttpClient();


            _logger.LogInformation($"Before GET {remoteUrl1}");
            await httpClient.GetAsync(remoteUrl1);
            
            _logger.LogInformation($"Before GET {remoteUrl2}");
            var bytes = await httpClient.GetByteArrayAsync(remoteUrl2);
            
            return bytes.GetLength(0);
        }
    }
}
