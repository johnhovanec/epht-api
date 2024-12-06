using epht_api.Converters;
using epht_api.Data;
using epht_api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
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



// Version using DbCommand
//[HttpGet("get-json-output")]
//public async Task<IActionResult> GetJsonOutput(string inputParam1, string inputParam2)
//{
//    // Validate inputs
//    if (string.IsNullOrWhiteSpace(inputParam1) || inputParam1.Length > 3)
//    {
//        return BadRequest("Input parameter 1 must be a non-empty string with a maximum length of 3.");
//    }

//    if (string.IsNullOrWhiteSpace(inputParam2) || inputParam2.Length > 3)
//    {
//        return BadRequest("Input parameter 2 must be a non-empty string with a maximum length of 3.");
//    }

//    // Open a database connection and create a command
//    using (var connection = _context.Database.GetDbConnection())
//    {
//        await connection.OpenAsync();

//        using (var command = connection.CreateCommand())
//        {
//            command.CommandText = "dbo.GetJsonData";
//            command.CommandType = CommandType.StoredProcedure;

//            // Define the input parameters
//            var inputParameter1 = command.CreateParameter();
//            inputParameter1.ParameterName = "@InputParam1";
//            inputParameter1.DbType = DbType.String;
//            inputParameter1.Size = 3; // NVARCHAR(3)
//            inputParameter1.Value = inputParam1;
//            command.Parameters.Add(inputParameter1);

//            var inputParameter2 = command.CreateParameter();
//            inputParameter2.ParameterName = "@InputParam2";
//            inputParameter2.DbType = DbType.String;
//            inputParameter2.Size = 3; // NVARCHAR(3)
//            inputParameter2.Value = inputParam2;
//            command.Parameters.Add(inputParameter2);

//            // Define the output parameter
//            var jsonOutputParameter = command.CreateParameter();
//            jsonOutputParameter.ParameterName = "@JsonOutput";
//            jsonOutputParameter.DbType = DbType.String;
//            jsonOutputParameter.Size = -1; // Use -1 for NVARCHAR(MAX)
//            jsonOutputParameter.Direction = ParameterDirection.Output;
//            command.Parameters.Add(jsonOutputParameter);

//            // Execute the command
//            await command.ExecuteNonQueryAsync();

//            // Retrieve the output parameter value
//            var jsonOutput = jsonOutputParameter.Value as string;

//            if (string.IsNullOrEmpty(jsonOutput))
//            {
//                return NotFound("No data found for the given parameters.");
//            }

//            // Deserialize JSON (optional) or return it directly
//            var result = JsonConvert.DeserializeObject<List<YourEntity>>(jsonOutput);

//            return Ok(result);
//        }
//    }
//}