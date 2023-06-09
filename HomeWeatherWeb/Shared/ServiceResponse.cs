using System;

namespace HomeWeatherWeb.Server.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public string Status { get; set; }

        public DateTime ResponseDate { get; set; }

        public bool IsFailed { get; set; }
    }
}
