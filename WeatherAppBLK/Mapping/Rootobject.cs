using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherAppBLK.Mapping;


//TODO: add JsonPropertyName 
public class Rootobject
{
    public Data data { get; set; }
}

public class Data
{
    public Request[] request { get; set; }
    public Current_Condition[] current_condition { get; set; }
}

public class Request
{
    public string type { get; set; }
    public string query { get; set; }
}

public class Current_Condition
{
    public string observation_time { get; set; }
    public string temp_C { get; set; }
    public string temp_F { get; set; }
}
