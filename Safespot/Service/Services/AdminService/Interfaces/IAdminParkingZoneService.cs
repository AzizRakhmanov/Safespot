using Safespot.Service.DTO.ParkingZone;
using Safespot.Service.DTO.ParkingZoneDto;

namespace Safespot.Service.Services.AdminService.Interfaces
{
    public interface IAdminParkingZoneService
    {
        public ValueTask<ParkingZoneForResultDto> AddAsync(ParkingZoneForCreationDto dto);

        // pagination params is now deleted temporerly
        public Task<IList<ParkingZoneForResultDto>> RetrieveAllAsync();

        public ValueTask<ParkingZoneForResultDto> RetrieveAsync(Guid id);

        public ValueTask<ParkingZoneForResultDto> UpdateAsync(Guid id, ParkingZoneForCreationDto user);

        public ValueTask<bool> RemoveAsync(Guid id);

        public Task<ParkingZoneForDetailsDto> RetrieveParkingZoneDetails(Guid parkingZoneId);
    }
}
