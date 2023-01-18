
using Api.src.Extension;
using Api.src.Routes;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Configure Services
services.UserContextInstaller();
services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());

var app = builder.Build();
// Configure Pipeline

// Configure Routes
app.ConfigureApiV1Router();
app.Run();

