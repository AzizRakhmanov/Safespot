using Safespot.Models.Entities;
using Safespot.Service.DTO.SlotDto;

namespace Safespot.Service.Services.SlotService
{
    public interface ISlotService
    {
        public Task<IEnumerable<SlotForResultDto>> AllSlotsAsync(Guid parkingZoneId);

        public ValueTask<SlotForResultDto> AddAsync(SlotForCreationDto dto);

        public Task<SlotForResultDto> EditAsync(SlotForCreationDto dto);

        public Task<SlotForResultDto> Details(Guid id);

        public void DeleteAsync(Guid id);  
    }
}
