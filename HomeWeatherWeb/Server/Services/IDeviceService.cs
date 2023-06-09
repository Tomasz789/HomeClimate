using HomeWeatherWeb.Server.DTO.Device;
using HomeWeatherWeb.Server.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Services
{
    public interface IDeviceService : IDataService<DeviceDto, UpdateDeviceDto, CreateDeviceDto>
    {
    }
}
