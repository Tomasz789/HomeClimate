using HomeWeather.DAL.AppDataContext;
using HomeWeather.DAL.Contracts;
using HomeWeather.DAL.Repos.Repositories;
using HomeWeather.DAL.Wrapper;
using HomeWeather.Models.Devices;
using HomeWeather.Serial.Services;
using HomeWeatherWeb.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWeatherWeb.Server.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureDatabaseContext(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];

            service.AddDbContext<ApplicationDataContext>(opts => opts.UseSqlServer(connectionString,
                migr => migr.MigrationsAssembly("HomeWeatherWeb.Server")));
        }

        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddSingleton<SerialPortSettings>();
            services.AddTransient<ISerialPortService, SerialPortService>();
            services.AddTransient<ISerialConnectionService, SerialConnectionService>();
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IDeviceRepository,DeviceRepository>();
            services.AddTransient<IDeviceService, DeviceService>();
        }
    }
}
