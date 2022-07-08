using System.Net;
using WeatherAppBLK.Time;

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
        
        //TODO: Add time logic 
        if ((DateTime.Now - LastFetchTime.FetchTime ).TotalSeconds <= 10)
        {
            await context.Response.WriteAsync("End point have been called withing the last 15min (10sek for test)");
            context.Response.StatusCode = (int)HttpStatusCode.NotModified;
        }

        await _next(context);
    }

}