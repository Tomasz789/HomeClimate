using HomeWeather.DAL.Contracts;
using HomeWeather.DAL.Repos.Repositories;
using HomeWeather.DAL.Wrapper;
using HomeWeatherWeb.Server.DTO;
using HomeWeatherWeb.Server.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Services
{
    public interface IDataService<T, U, C> where T : class where U : class where C : class
    {
        Task<ServiceResponse<IQueryable<T>>> GetAsync();

        Task<ServiceResponse<C>> AddAsync(C dto);

        Task<ServiceResponse<U>> UpdateAsync(string Id, U dto);

        Task<ServiceResponse<T>> DeleteAsync(string Id);

    }
}
