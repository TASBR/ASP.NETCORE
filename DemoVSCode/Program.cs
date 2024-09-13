//Configuração do Builder
var builder = WebApplication.CreateBuilder(args);

//Configuração do Pipeline

//Midlewares

//Services


//Configuração de comportamentos da App
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
