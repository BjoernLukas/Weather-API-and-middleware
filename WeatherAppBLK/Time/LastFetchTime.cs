namespace WeatherAppBLK.Time
{
    public class LastFetchTime : IDateTime
    {
        public DateTime FetchTime { get; set; } = DateTime.MinValue;
    }
}
