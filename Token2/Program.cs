using System;
using System.Net.Http;
using System.Text.Json;

    class Program
    {
        static void Main(string[] args)
        {
            string urlPath = "C:\\Users\\victo\\Desktop\\testfiles\\token2url.txt";
            string paramPath = "C:\\Users\\victo\\Desktop\\testfiles\\token2param.txt";
            string tokenURL = Methods.readFile(urlPath);
            string requestParameters = Methods.readFile(paramPath);
                 
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            HttpContent httpContent = new StringContent(requestParameters, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            string message = (Methods.postRequest(client, tokenURL, httpContent)).Result;

            Token token = JsonSerializer.Deserialize<Token>(message);
            string jsonString = JsonSerializer.Serialize(token);

            string accessToken = token.access_token;
            string vehiclesRequestURL = Methods.readFile("C:\\Users\\victo\\Desktop\\testfiles\\token2vehicles.txt");
            client.DefaultRequestHeaders.Accept.Clear();
            System.Net.Http.Headers.AuthenticationHeaderValue authenticationHeader = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Authorization = authenticationHeader;
            message = (Methods.getRequest(client, vehiclesRequestURL)).Result;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Vehicles));
            string xmldocpath = "C:\\Users\\victo\\Desktop\\testfiles\\vehiclesxml.xml";
            System.IO.File.WriteAllText(xmldocpath, message);
            System.IO.StringReader stringReader = new System.IO.StringReader(message);
            Vehicles vehicles = (Vehicles) serializer.Deserialize(stringReader);

            Methods.InsertVehiclesData(vehicles);
            Methods.readVehiclesData();
        }
    }
