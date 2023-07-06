using System.Threading.Tasks;
using Weather.Models;

public interface IWeatherService
{
    Task<Forecast> GetForecast(double latitude, double
   longitude);
}
