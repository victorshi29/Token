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

    public static async Task<string> getRequest(HttpClient client, string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        Console.WriteLine(response.ToString());
        string body = await response.Content.ReadAsStringAsync();
        return body;
    }

    public static string readFile(string path)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(path);
        return reader.ReadToEnd();
    }

    public static void InsertVehiclesData(Vehicles VehiclesObject)
    {
        string connectionString = "Server=localhost; Database=Vehicles; User Id=sa; Password=password";
        //string connectionString = "Server=localhost; Database=test; Integrated Security=True;";
        //^ this is for when u want to do windows login into server

        string udi = "";
        string value = "";

        string vehicleID = "";
        string vin = "";
        string serialNumber = "";        
        string vehicleNumber = "";

        string insertParameters = "";

        for (int i = 0; i < VehiclesObject.Vehicle.Count; i++)
        {
            for (int j = 0; j < VehiclesObject.Vehicle[i].Datum.Count; j++)
            {
                udi = VehiclesObject.Vehicle[i].Datum[j].UDI;
                value = VehiclesObject.Vehicle[i].Datum[j].Value;

                if(udi.Equals("10")) vehicleID = value;
                else if(udi.Equals("20")) vin = value;
                else if(udi.Equals("30")) serialNumber = value;
                else if(udi.Equals("40")) vehicleNumber = value;
            }
            insertParameters += string.Format("('{0}', '{1}', '{2}', '{3}'),", vehicleID, vin, serialNumber, vehicleNumber);
        }

        insertParameters = insertParameters.Remove(insertParameters.Length-1); //removes the extra comma at the end  
        string insertString = string.Format("INSERT INTO dbo.Vehicle (VehicleID, VIN, SerialNumber, VehicleNumber) VALUES {0};", insertParameters);  
        
        System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
        sqlConnection.Open();

        System.Data.SqlClient.SqlCommand insertCommand = new System.Data.SqlClient.SqlCommand(insertString);
        insertCommand.Connection = sqlConnection;
        Console.WriteLine("Rows changed: {0}", insertCommand.ExecuteNonQuery());
        sqlConnection.Close();
    }


    public static void readVehiclesData()
    {
        string connectionString = "Server=localhost; Database=Vehicles; User Id=sa; Password=password";
        System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
        sqlConnection.Open();
        string sqlQuery = "SELECT TOP (1000) [VehicleID], [VIN], [SerialNumber], [VehicleNumber] FROM [Vehicles].[dbo].[Vehicle];";
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlQuery);
        command.Connection = sqlConnection;
        System.Data.SqlClient.SqlDataReader sqlreader = command.ExecuteReader();
        while(sqlreader.Read())
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", sqlreader.GetSqlString(0), sqlreader.GetSqlString(1), sqlreader.GetSqlString(2), sqlreader.GetSqlString(3));
        }
        sqlreader.Close();
    }
    public static void readVehiclesData(int column_number)
    {
        string connectionString = "Server=localhost; Database=Vehicles; User Id=sa; Password=password";
        System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
        sqlConnection.Open();
        string sqlQuery = "SELECT TOP (1000) [VehicleID], [VIN], [SerialNumber], [VehicleNumber] FROM [Vehicles].[dbo].[Vehicle];";
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlQuery);
        command.Connection = sqlConnection;
        System.Data.SqlClient.SqlDataReader sqlreader = command.ExecuteReader();
        while(sqlreader.Read())
        {        
            Console.WriteLine(sqlreader.GetSqlString(column_number));
            
        }
        sqlreader.Close();
    }
    
}
