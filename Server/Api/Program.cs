var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var get = app.MapGet("/index", () => "Hello World!");



app.Run();
