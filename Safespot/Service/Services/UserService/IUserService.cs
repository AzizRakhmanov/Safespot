using Safespot.Models.Entities;
using Safespot.Service.DTO.ReservationDto;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.DTO.UserDto;

namespace Safespot.Service.Services.UserService
{
    public interface IUserService
    {
        public ValueTask<UserForResultDto> EditProfileAsync(UserForCreationDto dto);

        public ValueTask<ReservationForResultDto> EditReservationAsync(ReservationForCreationDto dto);

        public ValueTask DeleteProfileAsync(Guid userId);

        public IList<SlotForResultDto> RetrieveFreeSlotsWithTime(Guid parkingZoneId, SlotCategory category, DateTime period);

        public ValueTask<ReservationForResultDto> AddReservationAsync(ReservationForCreationDto dto);
    }
}
