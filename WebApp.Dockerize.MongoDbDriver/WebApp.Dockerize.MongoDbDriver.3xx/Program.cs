using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApp.Dockerize.MongoDbDriver._3xx;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureMongoDbOptions>();

builder.Services.AddSingleton<IMongoClient>(provider =>
{
    var options = provider.GetRequiredService<IOptions<MongoDbOptions>>();
    return new MongoClient(options.Value.ConnectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.Run();