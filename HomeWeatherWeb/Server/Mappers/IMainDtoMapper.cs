using HomeWeather.Models.Devices;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HomeWeatherWeb.Server.Mappers
{
    public interface IMainDtoMapper<T, U> where T : class  where U : class, new()
    {
        U MapObjectToDto(T obj);
        T MapDtoToObject(U obj);
    }
}
