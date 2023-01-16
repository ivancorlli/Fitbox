
using Api.src.Extension;
using Api.src.Routes;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Configure Services
services.UserContextInstaller();

var app = builder.Build();
// Configure Pipeline

// Configure Routes
app.ConfigureApiV1Router();
app.Run();

