//Configuração do Builder
using DemoVSCode;

var builder = WebApplication.CreateBuilder(args);

//Configuração do Pipeline
builder.AddSerilog();

builder.Services.AddControllersWithViews();

//Midlewares

//Services


//Configuração de comportamentos da App
var app = builder.Build();
app.UseLogTempo();


app.MapGet("/", () => "Hello World!");
app.MapGet("/teste", () =>
{
    Thread.Sleep(1500);
    return "Isso é um teste!";
});

app.Run();
