using Microsoft.EntityFrameworkCore;
using ShotUrl.Model;
using ShotUrl.Repository;
using ShotUrl.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEntityUrlRepository, EntityUrlRepository>();

var connectionStr = builder.Configuration.GetConnectionString("CONNECTION");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql((connectionStr)));

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Hello World!");

app.MapGet("/{id}", async(string id, IEntityUrlRepository _entityUrl) =>
{
    var url = await _entityUrl.GetUrl(id);
    return Results.Redirect(url.OriginalUrl);
});

app.MapPost("/createUrl", async (string principalUrl, IEntityUrlRepository _entityUrl) =>
{

    await _entityUrl.CreateShotUrl(principalUrl);
    
});

app.Run();
