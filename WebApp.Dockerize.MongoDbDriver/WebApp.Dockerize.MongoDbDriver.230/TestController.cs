using Microsoft.Extensions.Options;

namespace WebApp.Dockerize.MongoDbDriver._230;

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMongoClient _mongoClient;
    private readonly IOptions<MongoDbOptions> _options;
    
    public TestController(IMongoClient mongoClient, IOptions<MongoDbOptions> options)
    {
        _mongoClient = mongoClient;
        _options = options;
    }

    [HttpGet]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> TestConnection()
    {
        var values = new Dictionary<string, string>();
            
        values.Add("TargetFramework", AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName);
        values.Add("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        values.Add("ConnectionStringOnSettings", _options.Value.ConnectionString);
        values.Add("ConnectionStringOnDriver", _mongoClient.Settings.Server.ToString());
        values.Add("EndPoint", _mongoClient.Cluster.Description.Servers.First().EndPoint.ToString());
        
        try
        {
            await _mongoClient.ListDatabaseNamesAsync();
            values.Add("Connection", "Ok");
            return Ok(values);
        }
        catch (Exception ex)
        {
            values.Add("Error", ex.Message);
            return BadRequest(values);
        }
    }
}