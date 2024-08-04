using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.Exceptions;
using Safespot.Service.Extentions;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Service.Services.AdminService.Services
{
    public class AdminParkingZoneService : IAdminParkingZoneService
    {
        private readonly IRepository<ParkingZone> repository;
        private readonly IMapper mapper;

        public AdminParkingZoneService(IRepository<ParkingZone> repository,
            IMapper profile
            )
        {
            this.repository = repository;
            this.mapper = profile;
        }
        public async ValueTask<ParkingZoneForResultDto> AddAsync(ParkingZoneForCreationDto dto)
        {
            var mappedUser = this.mapper.Map<ParkingZone>(dto);

            var result = this.repository.InsertAsync(mappedUser);

            var resultDto = this.mapper.Map<ParkingZoneForResultDto>(result);

            return resultDto;
        }

        public async ValueTask<bool> RemoveAsync(Guid id)
        {
            var @object = await this.repository.SelectAsync(p => p.Id == id);
            if (@object is null)
                throw new SafespotException("User does not exist in the database", 404);

            var result = await this.repository.DeleteAsync(@object);
            return result;
        }

        public async Task<IList<ParkingZoneForResultDto>> RetrieveAllAsync([FromBody] PaginationParams @params)
        {
            var result = (await this.repository.SelectAllAsync(p => p != null))
                .ToPagedList(@params);

            return this.mapper.Map<IList<ParkingZoneForResultDto>>(result);
        }

        public async ValueTask<ParkingZoneForResultDto> RetrieveAsync(Guid id)
        {
            var result = await this.repository.SelectAsync(p => p.Id == id);
            if (result is null)
                throw new SafespotException("User not found", 404);

            return this.mapper.Map<ParkingZoneForResultDto>(result);
        }

        public async ValueTask<ParkingZoneForResultDto> UpdateAsync(Guid id, ParkingZoneForCreationDto dto)
        {
            var @object = await this.repository.SelectAsync(p => p.Id == id);
            if (@object == null)
                throw new SafespotException("User not found", 404);

            var mappedUser = this.mapper.Map<ParkingZone>(dto);
            this.repository.Update(mappedUser);

            var resultDto = this.mapper.Map<ParkingZoneForResultDto>(@object);

            return resultDto;
        }
    }
}
