using System;
using System.Net.Http;
using System.Collections.Generic;

namespace TokenAuthentication
{
    class Program
    {     
        static void Main(string[] args)
        {
            //READS IN THE JSONTRING FROM PATH, READS IN URL FROM URLPATH
           
            string urlpath = "C:\\Users\\victo\\Desktop\\testfiles\\tokenurls.txt";
            System.IO.StreamReader urlreader = new System.IO.StreamReader(urlpath);
            string url = urlreader.ReadLine();

            string path = "C:\\Users\\victo\\Desktop\\testfiles\\tokenstr.txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            string jsonstring = reader.ReadToEnd();
            reader.Close();
            //Console.WriteLine(jsonstring);

            //CREATE HTTPCLIENT AND HTTPCONTENT AND NECESSARY HEADERS
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //Console.WriteLine(content.Headers.ToString());
            //Console.WriteLine(client.DefaultRequestHeaders.Accept.ToString());

            //HTTP POST RESPONSE ASYNC
            String message = (GetToken.postRequest(client, url, content)).Result;
            //Console.WriteLine(message);

            Token tokenobj = System.Text.Json.JsonSerializer.Deserialize<Token>(message);

            //////////////////////////////////////////////////
            //PART 2 OF TOKEN AUTHENTICATION
            //READ IN VIN FROM VINPATH, READ LINE OF TXT FILE FOR VIN STRING, ADD TO VINLIST
            string vinpath = "C:\\Users\\victo\\Desktop\\testfiles\\vins.txt";
            List<string> vinList = new List<string>();
            GetToken.addVins(vinList, vinpath);      
            
            string mappingURL = urlreader.ReadLine();
            urlreader.Close();
            string authorizationtoken = tokenobj.token_type + " " + tokenobj.access_token;
            //Console.WriteLine(authorizationtoken);

            VinNumbers vinobj = new VinNumbers{vins = vinList};
            string vinstring = System.Text.Json.JsonSerializer.Serialize(vinobj);
            HttpContent vincontent = new StringContent(vinstring, System.Text.Encoding.UTF8, "application/json");
           
            //Console.WriteLine(vinstring);
            client.DefaultRequestHeaders.Add("Authorization", authorizationtoken);
            client.DefaultRequestHeaders.Add("Version", "2");
            
            message = (GetToken.postRequest(client, mappingURL, vincontent)).Result;
            Console.WriteLine(message);

            Vin vindata = System.Text.Json.JsonSerializer.Deserialize<Vin>(message);
            String vindatastring = System.Text.Json.JsonSerializer.Serialize(vindata);
            //Console.WriteLine(vindatastring);
        }

    }
}
