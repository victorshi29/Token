using System.Collections.Generic;
using System.Xml.Serialization;
public class Token
{
    public string access_token { get; set; }
    public int expires_in { get; set; }
    public string token_type { get; set; }
    public string refresh_token { get; set; }
}
	
[XmlRoot(ElementName = "Vehicle")]
public class Vehicle
{
    [XmlElement(ElementName = "Datum")]
    public List<Datum> Datum { get; set; }
}

[XmlRoot(ElementName = "Vehicles")]
public class Vehicles
{
    [XmlElement(ElementName = "UserInfo")]
    public UserInfo UserInfo { get; set; }

    [XmlElement(ElementName = "Vehicle")]
    public List<Vehicle> Vehicle { get; set; }
    
    [XmlAttribute(AttributeName = "TransactionTimestamp")]
    public string TransactionTimestamp { get; set; }
}

public class Datum
{
    [XmlAttribute(AttributeName = "UDI")]
    public string UDI { get; set; }

    [XmlAttribute(AttributeName = "Description")]
    public string Description { get; set; }

    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }

    [XmlAttribute(AttributeName = "Units")]
    public string Units { get; set; }

    [XmlAttribute(AttributeName = "LastTimestamp")]
    public string LastTimestamp { get; set; }
}

public class UserInfo
{
    [XmlAttribute(AttributeName = "CompanyId")]
    public string CompanyId { get; set; }
}
