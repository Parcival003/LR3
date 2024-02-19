using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<ITimeOfDayService, TimeOfDayService>(); 
builder.Services.AddSingleton<CalcService>();
var app = builder.Build();


app.MapGet("/time", ([FromServices] ITimeOfDayService timeOfDayService) => timeOfDayService.GetTimeOfDay());

app.MapGet("/add/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
{
    var result = calcService.Add(a, b);
    return result.ToString();
});

app.MapGet("/subtract/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
{
    var result = calcService.Subtract(a, b);
    return result.ToString();
});

app.MapGet("/multiply/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
{
    var result = calcService.Multiply(a, b);
    return result.ToString();
});

app.MapGet("/divide/{a}/{b}", ([FromServices] CalcService calcService, int a, int b) =>
{
    var result = calcService.Divide(a, b);
    return result.ToString();
});

app.MapGet("/", ([FromServices] ITimeOfDayService timeOfDayService, [FromServices] CalcService calcService) =>
{
    var message = $"The time of day is: {timeOfDayService.GetTimeOfDay()}";
    return message;
});

app.Run();
