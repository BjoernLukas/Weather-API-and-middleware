using WeatherAppBLK.Middleware;
using WeatherAppBLK.Time;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IDateTime, LastFetchTime>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello Dear Readers!");
//});

//app.Use(async (context, next) =>
//{
//    //Do work that does not write to the Response
//    await next.Invoke();
//    //Do logging or other work that does not write to the Response.
//});

//QUEST Turn this on/off
app.UseMiddleware<FetchTimeMiddleware>();
app.Run();


