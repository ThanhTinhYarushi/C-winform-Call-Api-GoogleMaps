using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System.Net.Http;

namespace MainProject
{
    public partial class Form1 : Form
    {
        private GMapOverlay markersOverlay;
        private GraphHopperService graphHopperService;
        private string apiKey = "88d49a17-f0ca-4b91-b3fc-e0d9e04e7676";


        public Form1()
        {
            InitializeComponent();

            // Cấu hình GMapControl
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            gMapControl1.Position = new PointLatLng(48.858844, 2.294351); // Paris, Eiffel Tower
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 13;
            gMapControl1.ShowCenter = false;

            // Tạo lớp overlay cho các marker và tuyến đường
            markersOverlay = new GMapOverlay("markers");
            gMapControl1.Overlays.Add(markersOverlay);
        }

        private async void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Lấy tọa độ từ TextBox
            string origin = txt_DiemDi.Text; // Ví dụ: "48.858844,2.294351"
            string destination = txt_DiemDen.Text; // Ví dụ: "48.8566,2.3522"

            try
            {
                // Gọi API để tính toán lộ trình
                var route = await GetRouteFromGraphHopper(origin, destination);

                if (route != null)
                {
                    // Hiển thị tuyến đường lên bản đồ
                    DrawRoute(route);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lộ trình.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }
        private async Task<PointLatLng[]> GetRouteFromGraphHopper(string origin, string destination)
        {
            string url = $"https://graphhopper.com/api/1/route?point={origin}&point={destination}&vehicle=car&points_encoded=false&key={apiKey}";

            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(url);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to get route from GraphHopper");
                }

                var response = await responseMessage.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(response);

                if (jsonResponse.paths != null && jsonResponse.paths.Count > 0)
                {
                    var path = jsonResponse.paths[0].points.coordinates;
                    PointLatLng[] routePoints = new PointLatLng[path.Count];

                    for (int i = 0; i < path.Count; i++)
                    {
                        var point = path[i];
                        routePoints[i] = new PointLatLng((double)point[1], (double)point[0]); // Đảo ngược lat/lon
                    }

                    return routePoints;
                }

                return null;
            }
        }

        // Hàm vẽ lộ trình lên bản đồ
        private void DrawRoute(PointLatLng[] routePoints)
        {
            // Xóa các tuyến đường và marker cũ
            markersOverlay.Routes.Clear();
            markersOverlay.Markers.Clear();

            // Thêm marker cho điểm bắt đầu
            var startMarker = new GMarkerGoogle(routePoints[0], GMarkerGoogleType.green_dot);
            markersOverlay.Markers.Add(startMarker);

            // Thêm marker cho điểm kết thúc
            var endMarker = new GMarkerGoogle(routePoints[routePoints.Length - 1], GMarkerGoogleType.red_dot);
            markersOverlay.Markers.Add(endMarker);

            // Vẽ tuyến đường
            var route = new GMapRoute(routePoints, "route");
            route.Stroke = new Pen(System.Drawing.Color.Blue, 3); // Đặt màu và độ rộng của đường
            markersOverlay.Routes.Add(route);

            // Tự động zoom map để hiển thị toàn bộ tuyến đường
            gMapControl1.ZoomAndCenterMarkers("markers");
        }
    }
}
