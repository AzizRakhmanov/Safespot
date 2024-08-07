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

        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Slot> _slotRepository;

        public AdminReservationService(
            IRepository<Reservation> repository,
            IMapper mapper,
            IRepository<Slot> slotRepository)
        {
            this._reservationRepository = repository;
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
            await this._reservationRepository.InsertAsync(dbReservation);
            slot.IsAvailableForBooking = false;
            this._slotRepository.Update(slot);

            return this._mapper.Map<ReservationForResultDto>(dto);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var dbSlot = await this._slotRepository.SelectAsync(p => p.Id == id);
            if (!dbSlot.IsAvailableForBooking)
            {
                dbSlot.IsAvailableForBooking = true;
                this._slotRepository.Update(dbSlot);
                return true;
            }

            return true;
        }

        public async Task<IList<ReservationForResultDto>> RetrieveAllBySlotAsync(Guid slodId, PaginationParams @params)
        {
            var all = (await this._reservationRepository.SelectAllAsync(p => p.SlotId == slodId))
                .ToPagedList(@params);

            var mappedReservation = this._mapper.Map<IList<ReservationForResultDto>>(all);

            return mappedReservation;
        }

        public async Task<IList<ReservationForResultDto>> RetrieveAllByTimeAsync(DateTime startDate, DateTime EndDate, PaginationParams @params)
        {
            var all = (await this._reservationRepository
                .SelectAllAsync(p => p.CreatedAt > startDate && p.EndDate < EndDate))
                .ToPagedList(@params);

            var mappedReservations = this._mapper.Map<IList<ReservationForResultDto>>(all);

            return mappedReservations;
        }

        public async ValueTask<ReservationForResultDto> RetrieveAsync(Guid id)
        {
            var dbReservation = await this._reservationRepository.SelectAsync(p => p.Id == id);

            var mappedReservation = this._mapper.Map<ReservationForResultDto>(dbReservation);

            return mappedReservation;
        }

        public async ValueTask<ReservationForResultDto> Update(Guid id, ReservationForCreationDto reservation)
        {
            var dbReservation = await this._reservationRepository.SelectAsync(p => p.Id == id);

            dbReservation = this._mapper.Map<Reservation>(reservation);

            var result = this._reservationRepository.Update(dbReservation);

            return this._mapper.Map<ReservationForResultDto>(result);
        }
    }
}
