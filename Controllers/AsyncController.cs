using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AsyncController : Controller
    {
        [HttpGet()]
        public async Task<IEnumerable<string>> Get()
        {
            await Task.Delay(2000);
            return new string[] { "value1", "value2" };
        }
    }
}
