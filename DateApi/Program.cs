using System.Net;

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

app.MapGet("/tankopedia", () =>
{
    var webRequest = WebRequest.Create(@"http://peabody28.com/data.json");

    using var response = webRequest.GetResponse();
    using var content = response.GetResponseStream();

    using (var reader = new StreamReader(content))
    {
        var strContent = reader.ReadToEnd();
        return Results.Json(strContent);
    }
})
.WithName("Tanks");

app.Run();

public class DateModel
{
    public DateTime Data { get; set; }
}