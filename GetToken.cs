using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
public class GetToken
{
    public static async Task<string> postRequest(HttpClient client, string url, HttpContent content)
    {
        HttpResponseMessage response = await client.PostAsync(url, content);
        Console.WriteLine(response.ToString());
        string body = await response.Content.ReadAsStringAsync();
        return body;
    
    }

    public static void addVins(List<string> list, string path)
    {
           System.IO.StreamReader vinreader = new System.IO.StreamReader(path);
           string vin = vinreader.ReadLine();           
           while(true)
            {
                if(vinreader.Peek() == -1)
                {
                    break;
                }
                else
                {
                    list.Add(vin);
                    vin = vinreader.ReadLine();
                }
                
            }
            vinreader.Close();
    }


}