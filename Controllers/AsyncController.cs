using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet()]
        public async Task<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Before Task.Delay");
            await Task.Delay(2000);
            _logger.LogInformation("After Task.Delay");
            
            return new string[] { "value1", "value2" };
        }
    }
}
