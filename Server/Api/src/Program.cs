using Api.src.Extension;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.ConfigureUserAccountContext(builder.Configuration);

var app = builder.Build();

app.MapGet("/",()=> "Bienvenido a fitbox");

app.Run();
