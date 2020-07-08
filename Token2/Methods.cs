using System.Net.Http;
using System;
using System.Threading.Tasks;

public class Methods
{
    public static async Task<string> postRequest(HttpClient client, string url, HttpContent content)
    {
        HttpResponseMessage response = await client.PostAsync(url, content);
        Console.WriteLine(response.ToString());
        string body = await response.Content.ReadAsStringAsync();
        return body;
    
    }

    public static string readFile(string path)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(path);
        return reader.ReadToEnd();
    }
    
}
