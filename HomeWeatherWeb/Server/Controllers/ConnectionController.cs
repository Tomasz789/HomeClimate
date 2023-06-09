using HomeWeather.Models.Devices;
using HomeWeather.Serial.Models;
using HomeWeather.Serial.Services;
using HomeWeatherWeb.Server.Models;
using HomeWeatherWeb.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly ISerialConnectionService _serialPortService;

        public ConnectionController(ISerialConnectionService serialPortService)
        {
            _serialPortService = serialPortService;
        }

        [Route("start")]
        [HttpGet]

        public async Task<ServiceResponse<PortMessage>> Start()
        {

            SerialPortSettings settings = new SerialPortSettings()
            {
                PortName = "COM3",
                BaudRate = 9600,
                Parity = "None",
                DataBits = 8,
                StopBits = "One",
                Handshake = "None"
            };

            _serialPortService.Config = settings;
            var res = await _serialPortService.ConnectAsync();

            return res;
        }

        [Route("stop")]
        [HttpGet]
        public async Task<ServiceResponse<PortMessage>> Stop()
        {
            var res = await _serialPortService.CloseAsync();

            return res;
        }
    }
}
