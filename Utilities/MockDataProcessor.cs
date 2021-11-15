using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;


namespace NewDesignMillionAndUpTest.Utilities
{
    class MockDataProcessor
    {
        
        public class Data
        {
            [JsonPropertyName("first_name")]
            public string FirstName { get; set; }

            [JsonPropertyName("last_name")]
            public string LastName { get; set; }

            [JsonPropertyName("email")]
            public string EmailAddress { get; set; }

            [JsonPropertyName("phone_number")]
            public string Phone { get; set; }
        }
        private static readonly HttpClient client = new HttpClient();
        public static async Task<List<Data>> ProcessData()
        {
            List<Data> data = null;
            string endPoint = new Constants().MockarooEndPoint;
            string jsonString=null;

            var response = await client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }
            else
            {
                jsonString = new Constants().MockDataAlternative;
            }
            data = JsonSerializer.Deserialize<List<Data>>(jsonString);

            return data;
        }

    }
}
