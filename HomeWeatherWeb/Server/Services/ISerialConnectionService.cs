using HomeWeather.Models.Devices;
using HomeWeather.Serial.Models;
using HomeWeatherWeb.Server.Models;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Services
{
    public interface ISerialConnectionService
    {
        public SerialPortSettings Config { get; set; }

        Task<ServiceResponse<PortMessage>> ConnectAsync();
        Task<ServiceResponse<PortMessage>> CloseAsync();
    }
}
