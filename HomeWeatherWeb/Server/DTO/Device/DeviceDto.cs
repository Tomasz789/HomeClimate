using HomeWeather.Models;
using HomeWeather.Models.Devices;
using System;

namespace HomeWeatherWeb.Server.DTO.Device
{
    public class DeviceDto
    {
        public string Name { get; set; }

        public string Microcontroller { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

        public int SensorId { get; set; }

        public Sensor SelectedSensor { get; set; }
    }
}
