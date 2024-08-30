using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epht_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirthDefectsController : Controller
    {
        private readonly ILogger<BirthDefectsController> _logger;

        public BirthDefectsController(ILogger<BirthDefectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BirthDefects> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new BirthDefects
            {
                Id = Guid.NewGuid(),
                Rate = rng.Next(1, 55),
                IndividualRate = rng.Next(1, 55),
                Period = "2017-2022",
                ChartLabel = "ChartLabel"

            })
            .ToArray();
        }
    }
}
