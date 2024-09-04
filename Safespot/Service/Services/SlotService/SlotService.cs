using AutoMapper;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.Exceptions;

namespace Safespot.Service.Services.SlotService
{
    public class SlotService : ISlotService
    {
        private readonly IRepository<Slot> _repository;

        private readonly IMapper _mapper;
        public SlotService(IRepository<Slot> repository,
            IMapper mapper)
        {
           this._repository = repository;
            this._mapper = mapper;
        }
        public async ValueTask<SlotForResultDto> AddAsync(SlotForCreationDto dto)
        {
            return null;
        }

        public Task<IEnumerable<SlotForResultDto>> AllSlotsAsync(Guid parkingZoneId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SlotForResultDto> Details(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SlotForResultDto> EditAsync(SlotForCreationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
