using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ShotUrl.Model;
using ShotUrl.Repository;
using ShotUrl.Repository.Interfaces;
using ShotUrl.Services;
using ShotUrl.Services.Interfaces;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Allow", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IEntityUrlRepository, EntityUrlRepository>();
builder.Services.AddScoped<IEntityUrlService, EntityUrlService>();
builder.Services.AddScoped<IEntityUrlCache, EntityUrlCache>();


var connectionStr = builder.Configuration.GetConnectionString("CONNECTION");
var redisConfig = builder.Configuration.GetSection("Redis");


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql((connectionStr)));
builder.Services.AddSingleton<IConnectionMultiplexer>(ct =>
{
    var options = new ConfigurationOptions
    {
        EndPoints = { $"{redisConfig["Host"]}:{redisConfig["Port"]}" },
        User = redisConfig["User"],
        Password = redisConfig["Password"],
        Ssl = true,
        AbortOnConnectFail = false
    };
    return ConnectionMultiplexer.Connect(options);
});

var app = builder.Build();



app.UseCors("Allow");
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/{id}", async(string id, IEntityUrlService _entityUrl) =>
{
    
    var uri = await _entityUrl.GetUrl(id);
    return Results.Redirect(uri);
});

app.MapPost("/createUrl", async (string principalUrl, IEntityUrlService _entityUrl, IHttpContextAccessor _acessor) =>
{
    var request = _acessor.HttpContext.Request;
    var shortId = await _entityUrl.CreateUrl(principalUrl);
    return Results.Ok($"{request.Scheme}://{request.Host}{request.PathBase}/{shortId}");
    
});

app.Run();
