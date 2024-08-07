using Safespot.Service.DTO.ReservationDto;
using Safespot.Service.Extentions;

namespace Safespot.Service.Services.AdminService.Interfaces
{
    public interface IAdminReservationService
    {
        public Task<IList<ReservationForResultDto>> RetrieveAllByTimeAsync(DateTime startDate, DateTime EndDate, PaginationParams @params);

        public Task<IList<ReservationForResultDto>> RetrieveAllBySlotAsync(Guid slodId, PaginationParams @params);

        public ValueTask<ReservationForResultDto> RetrieveAsync(Guid id);

        public ValueTask<ReservationForResultDto> AddAsync(ReservationForResultDto dto);

        public ValueTask<ReservationForResultDto> Update(Guid id, ReservationForCreationDto reservation);

        public ValueTask<bool> DeleteAsync(Guid id);
    }
}
