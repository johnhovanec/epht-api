using epht_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace epht_api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BirthDefectsController : Controller
    {
        private readonly epht_apiContext _context;

        public BirthDefectsController(epht_apiContext context)
        {
            _context = context;
        }

        // GET api/BirthDefects/000/2017-2021
        [HttpGet("/api/[controller]/{county}/{dateRange}")]
        public async Task<IActionResult> GetRate(string county, string dateRange)
        {
            // Define the output parameter
            var jsonOutput = new SqlParameter
            {
                ParameterName = "@jsonOutput",
                SqlDbType = SqlDbType.NVarChar,
                Size = -1, // Use -1 for nvarchar(MAX)
                Direction = ParameterDirection.Output
            };

            // Define the input parameters
            var countyParameter = new SqlParameter
            {
                ParameterName = "@Countycode",
                SqlDbType = SqlDbType.NVarChar,
                Size = 3, // nvarchar(3)
                Value = county
            };
            var dateParameter = new SqlParameter
            {
                ParameterName = "@Daterange",
                SqlDbType = SqlDbType.NVarChar,
                Size = 15, // nvarchar(15)
                Value = dateRange
            };

            // Execute the stored procedure
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [epht].[BirthDefects_GetRate] @Countycode, @Daterange, @JsonOutput OUTPUT",
                countyParameter,
                dateParameter,
                jsonOutput
            );

            // Retrieve the output JSON string
            var jsonData = jsonOutput.Value as string;

            // Return the response as JSON
            return Content(jsonData, "application/json");
        }
    }
}
