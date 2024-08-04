using AutoMapper;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ReservationDto;
using Safespot.Service.Exceptions;
using Safespot.Service.Extentions;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Service.Services.AdminService.Services
{
    public class AdminReservationService : IAdminReservationService
    {

        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Slot> _slotRepository;

        public AdminReservationService(
            IRepository<Reservation> repository,
            IMapper mapper,
            IRepository<Slot> slotRepository)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._slotRepository = slotRepository;
        }

        public async ValueTask<ReservationForResultDto> AddAsync(ReservationForResultDto dto)
        {
            if (dto == null)
                throw new SafespotException("Reservation can't be null", 404);

            // reservation to save in database
            var slot = await this._slotRepository.SelectAsync(p => p.Id == dto.SlotId);
            if (!slot.IsAvailableForBooking)
            {
                throw new SafespotException("Slot already booked", 200);
            }

            var dbReservation = this._mapper.Map<Reservation>(dto);
            await this._repository.InsertAsync(dbReservation);
            slot.IsAvailableForBooking = false;
            this._slotRepository.Update(slot);

            return this._mapper.Map<ReservationForResultDto>(dto);
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var isAvilabel = await this._slotRepository.SelectAsync(p => p.IsAvailableForBooking);
            return true;
        }

        public Task<IList<ReservationForResultDto>> RetrieveAllBySlotAsync(Guid slodId, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ReservationForResultDto>> RetrieveAllByTimeAsync(DateTime dateTime, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ReservationForResultDto> RetrieveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ReservationForResultDto> Update(Guid id, ReservationForCreationDto reservation)
        {
            throw new NotImplementedException();
        }
    }
}
