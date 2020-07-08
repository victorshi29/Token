using System.Collections.Generic;
public class Token
{
    public string token_type { get; set; }
    public string access_token { get; set;}
    public string expires_in { get; set;}
    public string ext_expires_in { get; set;}
    public string expires_on { get; set;}
    public string not_before { get; set;}
}

public class VinNumbers
{
    public List<string> vins { get; set; }
}   

public class Vin
{
    public List<Vehicle> vin { get; set; }
    public int recordcount { get; set; }
}

public class Vehicle
{
    public string vin { get; set; }
    public string deviceid { get; set; }
    public string updateddate { get; set; }
}
