using Microsoft.EntityFrameworkCore;
using ShotUrl.Model;
using ShotUrl.Repository;
using ShotUrl.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IEntityUrlRepository, EntityUrlRepository>();

var connectionStr = builder.Configuration.GetConnectionString("CONNECTION");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql((connectionStr)));

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/{id}", async(string id, IEntityUrlRepository _entityUrl) =>
{
    
    var uri = await _entityUrl.GetUrl(id);
    return Results.Redirect(uri);
});

app.MapPost("/createUrl", async (string principalUrl, IEntityUrlRepository _entityUrl, IHttpContextAccessor _acessor) =>
{
    var request = _acessor.HttpContext.Request;
    var shortId = await _entityUrl.CreateShotUrl(principalUrl);
    return Results.Ok($"{request.Scheme}://{request.Host}{request.PathBase}/{shortId}");
    
});

app.Run();
