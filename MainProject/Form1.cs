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
using System.Diagnostics;

namespace MainProject
{
    public partial class Form1 : Form
    {
        private GMapOverlay markersOverlay;
        private GraphHopperService graphHopperService;
        private string apiKey = "88d49a17-f0ca-4b91-b3fc-e0d9e04e7676";

        private List<string> suggestions = new List<string>
        {
            "Hà Nội",
            "Hồ Chí Minh",
            "Đà Nẵng",
            "Nha Trang",
            "Huế",
            "Cần Thơ",
            "Hạ Long",
            "Vũng Tàu",
            "Phú Quốc",
            "Đà Lạt"
    // Thêm nhiều địa điểm khác nếu cần
        };

        public Form1()
        {
            InitializeComponent();

            // Cấu hình GMapControl
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            //gMapControl1.Position = new PointLatLng(48.858844, 2.294351); // Paris, Eiffel Tower
            gMapControl1.Position = new PointLatLng(10.7729, 106.7034);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 13;
            gMapControl1.ShowCenter = false;

            // Tạo lớp overlay cho các marker và tuyến đường
            markersOverlay = new GMapOverlay("markers");
            gMapControl1.Overlays.Add(markersOverlay);


            txt_DiemDi.Text = "Số 1 Đường Lê Duẩn, Phường Bến Nghé, Quận 1, Hồ Chí Minh";
            txt_DiemDen.Text = "Số 20 Đường Nguyễn Thị Định, Phường 3, Thành phố Bến Tre";

            ConfigureAutoComplete();
        }

        //private async void buttonCalculate_Click(object sender, EventArgs e)
        //{
        //    // Lấy tọa độ từ TextBox
        //    string origin = txt_DiemDi.Text; // Ví dụ: "48.858844,2.294351"
        //    string destination = txt_DiemDen.Text; // Ví dụ: "48.8566,2.3522"

        //    try
        //    {
        //        // Gọi API để tính toán lộ trình
        //        var route = await GetRouteFromGraphHopper(origin, destination);

        //        if (route != null)
        //        {
        //            // Hiển thị tuyến đường lên bản đồ
        //            DrawRoute(route);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không tìm thấy lộ trình.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
        //    }
        //}
        private async void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Lấy tọa độ từ TextBox
            string origin = txt_DiemDi.Text; // Ví dụ: "48.858844,2.294351"
            string destination = txt_DiemDen.Text; // Ví dụ: "48.8566,2.3522"

            try
            {
                // Gọi API để tính toán lộ trình
                var (route, distance) = await GetRouteFromGraphHopper(origin, destination);

                if (route != null)
                {
                    // Hiển thị tuyến đường lên bản đồ
                    DrawRoute(route);

                    // Cập nhật khoảng cách lên label1
                    label1.Text = $"Khoảng cách: {distance / 1000} km"; // Chia cho 1000 để chuyển sang km
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

        //private async Task<PointLatLng[]> GetRouteFromGraphHopper(string origin, string destination)
        //{
        //    string url = $"https://graphhopper.com/api/1/route?point={origin}&point={destination}&vehicle=car&points_encoded=false&key={apiKey}";

        //    using (var client = new HttpClient())
        //    {
        //        var responseMessage = await client.GetAsync(url);
        //        if (!responseMessage.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Failed to get route from GraphHopper");
        //        }

        //        var response = await responseMessage.Content.ReadAsStringAsync();
        //        dynamic jsonResponse = JsonConvert.DeserializeObject(response);

        //        if (jsonResponse.paths != null && jsonResponse.paths.Count > 0)
        //        {
        //            var path = jsonResponse.paths[0].points.coordinates;
        //            PointLatLng[] routePoints = new PointLatLng[path.Count];

        //            for (int i = 0; i < path.Count; i++)
        //            {
        //                var point = path[i];
        //                routePoints[i] = new PointLatLng((double)point[1], (double)point[0]); // Đảo ngược lat/lon
        //            }

        //            return routePoints;
        //        }

        //        return null;
        //    }
        //}
        private async Task<(PointLatLng[] routePoints, double distance)> GetRouteFromGraphHopper(string origin, string destination)
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
                    double distance = jsonResponse.paths[0].distance; // Lấy khoảng cách từ JSON

                    for (int i = 0; i < path.Count; i++)
                    {
                        var point = path[i];
                        routePoints[i] = new PointLatLng((double)point[1], (double)point[0]); // Đảo ngược lat/lon
                    }

                    return (routePoints, distance); // Trả về cả lộ trình và khoảng cách
                }

                return (null, 0); // Không tìm thấy lộ trình
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
        private void ConfigureAutoComplete()
        {
            txt_DiemDi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_DiemDi.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(suggestions.ToArray());
            txt_DiemDi.AutoCompleteCustomSource = autoCompleteCollection;

            txt_DiemDen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_DiemDen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_DiemDen.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            txt_DiemDen.Text = "";
            txt_DiemDi.Text = "";
        }

        private void btn_TimToaDo_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myProcess.Close();
            }
        }

        private async void ButtonCalculate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    PointLatLng originCoordinates = await GetCoordinatesFromAddress(txt_DiemDi.Text);
            //    PointLatLng destinationCoordinates = await GetCoordinatesFromAddress(txt_DiemDen.Text);
            //    // Tạo chuỗi tọa độ để gọi API GraphHopper
            //    string origin = $"{originCoordinates.Lat},{originCoordinates.Lng}";
            //    string destination = $"{destinationCoordinates.Lat},{destinationCoordinates.Lng}";
            //    // Gọi API để tính toán lộ trình
            //    var (route, distance) = await GetRouteFromGraphHopper(origin, destination);

            //    if (route != null)
            //    {
            //        DrawRoute(route);
            //        label1.Text = $"Khoảng cách: {distance / 1000} km";
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không tìm thấy lộ trình.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            //}
            try
            {
                // Lấy tọa độ từ địa chỉ
                PointLatLng originCoordinates = await GetCoordinatesFromAddress(txt_DiemDi.Text);
                PointLatLng destinationCoordinates = await GetCoordinatesFromAddress(txt_DiemDen.Text);

                // Chuyển đổi tọa độ từ độ thập phân (DD) sang độ phút phút (DMM)
                string originDMM = ConvertToDMM(originCoordinates.Lat, originCoordinates.Lng);
                string destinationDMM = ConvertToDMM(destinationCoordinates.Lat, destinationCoordinates.Lng);

                // Gọi API để tính toán lộ trình
                var (route, distance) = await GetRouteFromGraphHopper(originDMM, destinationDMM);

                if (route != null)
                {
                    DrawRoute(route);
                    label1.Text = $"Khoảng cách: {distance / 1000} km"; // Chia cho 1000 để chuyển sang km
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

        private async Task<PointLatLng> GetCoordinatesFromAddress(string address)
        {
            string apiKey = "88d49a17-f0ca-4b91-b3fc-e0d9e04e7676";
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={apiKey}";

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                dynamic jsonResponse = JsonConvert.DeserializeObject(response);
                if (jsonResponse.status == "OK")
                {
                    var location = jsonResponse.results[0].geometry.location;
                    return new PointLatLng((double)location.lat, (double)location.lng);
                }
                throw new Exception("Không tìm thấy tọa độ cho địa chỉ này.");
            }
        }
        private string ConvertToDMM(double latitude, double longitude)
        {
            return $"{ConvertToDMM(latitude)} N, {ConvertToDMM(longitude)} E";
        }

        private string ConvertToDMM(double coord)
        {
            int degrees = (int)coord;
            double minutes = (Math.Abs(coord) - Math.Abs(degrees)) * 60;
            return $"{Math.Abs(degrees)}°{minutes:00.00}'";
        }
    }
}
