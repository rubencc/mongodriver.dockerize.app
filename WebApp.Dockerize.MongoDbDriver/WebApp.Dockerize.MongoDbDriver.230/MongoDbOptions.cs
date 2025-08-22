namespace WebApp.Dockerize.MongoDbDriver._230;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public record MongoDbOptions
{
    public const string SECTION_KEY = "MongoDb";

    public string ConnectionString { get; init; }
}

public class ConfigureMongoDbOptions(IConfiguration configuration) : IConfigureOptions<MongoDbOptions>
{
    private readonly IConfiguration _configuration = configuration;

    public void Configure(MongoDbOptions options)
    {
        _configuration.GetSection(MongoDbOptions.SECTION_KEY)
            .Bind(options);
    }
}