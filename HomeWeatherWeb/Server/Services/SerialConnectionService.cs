using HomeWeather.Models.Devices;
using HomeWeather.Serial.Models;
using HomeWeather.Serial.Services;
using HomeWeatherWeb.Server.Models;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Services
{
    public class SerialConnectionService : ISerialConnectionService
    {
        private ISerialPortService _serv;
        private SerialPortSettings settings;
        public SerialConnectionService()
        {
            settings = new SerialPortSettings()
            {
                PortName = "COM3",
                BaudRate = 9600,
                Parity = "None",
                DataBits = 8,
                StopBits = "One",
                Handshake = "None"
            };

            _serv = new SerialPortService(this.settings);

        }


        public SerialPortSettings Config { get; set; }

        public async Task<ServiceResponse<PortMessage>> CloseAsync()
        {
            _serv.CloseConnection();

            var res = new ServiceResponse<PortMessage>()
            {
                Data = _serv.PortMessage,
                ResponseDate = System.DateTime.Now,
                Status = _serv.PortMessage.InfoType.ToString(),
            };

            return res;
        }

        public async Task<ServiceResponse<PortMessage>> ConnectAsync()
        {
            _serv.OpenConnection();

            var res = new ServiceResponse<PortMessage>()
            {
                Data = _serv.PortMessage,
                ResponseDate = System.DateTime.Now,
                Status = _serv.PortMessage.InfoType.ToString()
            };

            return res;
        }
    }
}
