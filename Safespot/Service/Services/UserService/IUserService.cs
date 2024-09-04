using Safespot.Models.Entities;
using Safespot.Service.DTO.ReservationDto;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.DTO.UserDto;

namespace Safespot.Service.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<UserForResultDto>> AllUsersAsync();

        public ValueTask<UserForResultDto> RetrieveAsync(Guid id);

        public ValueTask<UserForResultDto> AddAsync(UserForCreationDto dto);

        public Task<UserForResultDto> EditAsync(UserForCreationDto dto);

        public Task<bool> DeleteAsync(Guid Id);

    }
}
