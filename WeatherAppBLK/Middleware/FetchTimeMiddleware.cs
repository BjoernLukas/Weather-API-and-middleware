using System.Net;

namespace WeatherAppBLK.Middleware;

internal class FetchTimeMiddleware
{
    private readonly RequestDelegate _next;

    public FetchTimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        if (false)
        {
            context.Response.WriteAsync("End point have been called withing the last 15min (5sek for test)");
            context.Response.StatusCode = (int)HttpStatusCode.NotModified; 
        }

        await _next(context);
    }

}