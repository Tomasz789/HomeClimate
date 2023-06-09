using System;

namespace HomeWeatherWeb.Server.DTO.Device
{
    public class CreateDeviceDto
    {
        public string Name { get; set; }

        public string Microcontroller { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

    }
}
