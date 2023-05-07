using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/date", () =>
{
    return new DateModel { Data = DateTime.UtcNow };
})
.WithName("Date");

app.MapGet("/unixEpochDate", () =>
{
    return new DateModel { Data = DateTime.UnixEpoch };
})
.WithName("UnixEpochDate");

app.Run();

public class DateModel
{
    public DateTime Data { get; set; }
}