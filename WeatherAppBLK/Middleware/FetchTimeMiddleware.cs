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
        //if ((DateTime.Now - LastFetchTime.FetchTime).TotalMinutes <= 15)
        if ((DateTime.Now - LastFetchTime.FetchTime).TotalSeconds <= 10)
        {
            await context.Response.WriteAsync("End point have been called withing the last 15min (10sek for test)");
            context.Response.StatusCode = (int) HttpStatusCode.NotModified;
        }

        //Moves on to the next step in pipeline
        await _next(context);
    }
}