namespace WeatherAppBLK.Time
{
    public class LastFetchTime : IDateTime
    {
       public static DateTime FetchTime { get; set; } = DateTime.MinValue;
    }
    
    
}
