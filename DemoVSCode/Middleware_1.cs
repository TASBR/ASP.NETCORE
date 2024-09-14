using Serilog;
using System.Diagnostics;

namespace DemoVSCode
{
    public class Middleware_1
    {
        private readonly RequestDelegate _next;

        public Middleware_1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvoekeAsync(HttpContext httpContext)
        {
            //Faz algo antes

            //Chama o próximo middleware no pipeline
            await _next(httpContext);

            //Fal algo depois
        }
    }

    public class LogTempoMiddleware
    {
        private readonly RequestDelegate _next;

        public LogTempoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvoekeAsync(HttpContext httpContext)
        {
            //Faz algo antes
            var sw = Stopwatch.StartNew();

            //Chama o próximo middleware no pipeline
            await _next(httpContext);

            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information($"A execução demorou {sw.Elapsed.TotalMilliseconds} ms ({sw.Elapsed.TotalSeconds} segundos)");

            //Fal algo depois
        }
    }

    public static class SerilogExtensions
    {
        public static void AddSerilog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();
            //
            //
            //
            //
            //
        }
    }

    public static class LogTempoMiddlewareExtensions
    {
        public static void UseLogTempo(this WebApplication app)
        {
            app.UseMiddleware<LogTempoMiddleware>();
        }
    }
}
