using HomeWeather.DAL.Wrapper;
using HomeWeather.Models.Devices;
using HomeWeatherWeb.Server.DTO;
using HomeWeatherWeb.Server.DTO.Device;
using HomeWeatherWeb.Server.Mappers;
using HomeWeatherWeb.Server.Models;
using HomeWeatherWeb.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService devService;
        public DeviceController(IDeviceService service)
        {
            devService = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IQueryable<DeviceDto>>>> Get()
        {
            var deviceListResponse = await devService.GetAsync();

            return Ok(deviceListResponse);
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<DeviceDto>>> Post([FromBody] CreateDeviceDto deviceDto)
        {
            var res = await devService.AddAsync(deviceDto);

            return Ok(res.Data);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<DeviceDto>>> Delete([FromRoute] string id)
        {
            var res = await devService.DeleteAsync(id);

            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<DeviceDto>> Put(string id, [FromBody] UpdateDeviceDto deviceDto)
        {
            var res = await devService.UpdateAsync(id, deviceDto);

            return Ok(res);
        }
    }
}
