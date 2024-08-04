using Microsoft.AspNetCore.Mvc;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.Extentions;

namespace Safespot.Service.Services.AdminService.Interfaces
{
    public interface IAdminParkingZoneService
    {
        public ValueTask<ParkingZoneForResultDto> AddAsync(ParkingZoneForCreationDto dto);

        public Task<IList<ParkingZoneForResultDto>> RetrieveAllAsync([FromBody] PaginationParams @params);

        public ValueTask<ParkingZoneForResultDto> RetrieveAsync(Guid id);

        public ValueTask<ParkingZoneForResultDto> UpdateAsync(Guid id, ParkingZoneForCreationDto user);

        public ValueTask<bool> RemoveAsync(Guid id);
    }
}
