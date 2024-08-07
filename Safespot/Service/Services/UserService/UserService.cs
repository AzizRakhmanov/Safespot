using AutoMapper;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ReservationDto;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.DTO.UserDto;
using Safespot.Service.Exceptions;

namespace Safespot.Service.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public UserService(
            IRepository<Reservation> repository,
            IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async ValueTask<ReservationForResultDto> AddReservationAsync(ReservationForCreationDto dto)
        {
            if (dto is null)
                throw new SafespotException("Reservation has incomplete fields", 404);

            var dbReservation = this._mapper.Map<Reservation>(dto);

            var result = await this._repository.InsertAsync(dbReservation);

            return this._mapper.Map<ReservationForResultDto>(result);
        }

        public async ValueTask DeleteProfileAsync(Guid userId)
        {
            var result = await this._repository.SelectAsync(p => p.Id == userId);

            if (result == null)
                throw new SafespotException("User not found",404);

             await this._repository.DeleteAsync(result);
        }

        public ValueTask<UserForResultDto> EditProfileAsync(UserForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ReservationForResultDto> EditReservationAsync(ReservationForCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public IList<SlotForResultDto> RetrieveFreeSlotsWithTime(Guid parkingZoneId, SlotCategory category, DateTime period)
        {
            throw new NotImplementedException();
        }
    }
}
