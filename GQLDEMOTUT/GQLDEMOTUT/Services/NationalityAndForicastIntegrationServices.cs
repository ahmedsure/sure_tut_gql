using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

namespace GQLDEMOTUT.Services
{
    public class NationalityAndForicastIntegrationServices
    {
        public readonly IConfiguration _Configuration;
        public NationalityAndForicastIntegrationServices(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        public async Task<List<WeatherForecast>> UsersWeatherForecasts(List<Guid> users)
        {
            var weatherWeb = _Configuration.GetValue<string>("Services:UsersNationalityAndForecastService");
            var weatherController = _Configuration.GetValue<string>("Services:WeatherForecastControler");
            using HttpClient httpClient = new() { BaseAddress = new Uri(weatherWeb) };
            {
                var resp = await httpClient.PostAsJsonAsync(weatherController + "/WeatherForecastForUsers", users);
                Debug.Print(resp.Headers.ToString());
                Debug.Print(await resp.Content.ReadAsStringAsync());
                if (resp.IsSuccessStatusCode)
                {

                    string respData = await resp.Content.ReadAsStringAsync();
                    var weatherF = JsonConvert.DeserializeObject<List<WeatherForecast>>(respData);
                    return weatherF;
                }
                else
                {
                    return new List<WeatherForecast>();
                }
            }
        }
    }
}
