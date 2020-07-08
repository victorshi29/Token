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
            Console.WriteLine(message);

            Token token = JsonSerializer.Deserialize<Token>(message);
            string jsonString = JsonSerializer.Serialize(token);
            Console.WriteLine(jsonString);
        }
    }
