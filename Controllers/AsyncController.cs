using System;
using System.Collections.Generic;
using System.Linq;
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
            return new string[] { "value5", "value6" };
        }
    }
}
