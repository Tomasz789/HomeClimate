using HomeWeather.DAL.Wrapper;
using HomeWeather.Models.Devices;
using HomeWeatherWeb.Server.DTO;
using HomeWeatherWeb.Server.DTO.Device;
using HomeWeatherWeb.Server.Mappers;
using HomeWeatherWeb.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Server.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMainDtoMapper<Device, DeviceDto> _mapper;

        public DeviceService(IRepositoryWrapper repo)
        {
            _repo = repo;
            _mapper = new MainDtoMapper<Device, DeviceDto>();
        }

        public async Task<ServiceResponse<CreateDeviceDto>> AddAsync(CreateDeviceDto dto)
        {
            var mapper = new MainDtoMapper<Device, CreateDeviceDto>();
            var device = mapper.MapDtoToObject(dto);

            if (dto is null || device is null)
            {
                return new ServiceResponse<CreateDeviceDto>()
                {
                    IsFailed = false,
                    Status = "Invalid Device object"
                };
            }

            await _repo.DeviceRepository.AddAsync(device);

            return new ServiceResponse<CreateDeviceDto>()
            {
                Data = dto,
                IsFailed = false,
                ResponseDate = DateTime.Now,
                Status = "OK"
            };
        }

        public async Task<ServiceResponse<DeviceDto>> DeleteAsync(string Id)
        {
            var device = await _repo.DeviceRepository.GetOneByCondition(x => x.Id.ToString() == Id);
            var mapper = new MainDtoMapper<Device,DeviceDto>();

            if (device is null)
            {
                return new ServiceResponse<DeviceDto>()
                {
                    IsFailed = true,
                    Status = $"Device with id {Id}"
                };
            }

            await _repo.DeviceRepository.RemoveAsync(device);

            return new ServiceResponse<DeviceDto>()
            {
                Status = "OK",
                Data = mapper.MapObjectToDto(device),
                IsFailed = false,
            };
        }

        public async Task<ServiceResponse<IQueryable<DeviceDto>>> GetAsync()
        {
            var devices = await _repo.DeviceRepository.GetAllAsync();
            
            var mapper = new MainDtoMapper<Device, DeviceDto>();
            var mappedDevices = new List<DeviceDto>();

            foreach (var device in devices)
            {
                mappedDevices.Add(mapper.MapObjectToDto(device));
            }

            return new ServiceResponse<IQueryable<DeviceDto>>()
            {
                Data = mappedDevices.AsQueryable(),
                ResponseDate = DateTime.Now,
                IsFailed = false,
                Status = "Ok"
            };

        }

        public async Task<ServiceResponse<UpdateDeviceDto>> UpdateAsync(string Id, UpdateDeviceDto dto)
        {
            var deviceToUpdate = await _repo.DeviceRepository.GetOneByCondition(d => d.Id.ToString() == Id);
           // var mapper = new MainDtoMapper<Device, UpdateDeviceDto>();
            //var device = mapper.MapDtoToObject(dto);

            if (dto is null)
            {
                return new ServiceResponse<UpdateDeviceDto>()
                {
                    IsFailed = false,
                    Status = "Invalid Device up to date object"
                };
            }

            var updatedDevice = new Device()
            {
                Id = deviceToUpdate.Id,
                AppUser = deviceToUpdate.AppUser,
                Description = dto.Description,
                Measures = deviceToUpdate.Measures,
                Microcontroller = deviceToUpdate.Microcontroller,
                Name = dto.Name,
                SelectedSensor = deviceToUpdate.SelectedSensor,
                SensorId = dto.SensorId,
                UserId = deviceToUpdate.UserId,
            };

            await _repo.DeviceRepository.UpdateAsync(updatedDevice);

            return new ServiceResponse<UpdateDeviceDto>()
            {
                Data = dto,
                IsFailed = false,
                ResponseDate = DateTime.Now,
                Status = "OK"
            };
        }

    }
}
