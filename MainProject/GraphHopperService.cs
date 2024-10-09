using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class GraphHopperService
    {
        private static readonly HttpClient client = new HttpClient();
        private string apiKey;
        
        public GraphHopperService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        // Phương thức để tính quãng đường giữa hai tọa độ
        public async Task<double?> CalculateDistance(string origin, string destination)
        {
            string url = $"https://graphhopper.com/api/1/route?point={origin}&point={destination}&vehicle=car&key={apiKey}";

            try
            {
                var response = await client.GetStringAsync(url);
                dynamic jsonResponse = JsonConvert.DeserializeObject(response);

                if (jsonResponse.paths.Count > 0)
                {
                    // Quãng đường trả về trong đơn vị mét
                    double distance = jsonResponse.paths[0].distance;
                    return distance;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi gọi API: {ex.Message}");
            }
        }
    }
}
