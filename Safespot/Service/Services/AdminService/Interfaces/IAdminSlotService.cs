using Safespot.Models.Entities;
using Safespot.Service.DTO.SlotDto;

namespace Safespot.Service.Services.AdminService.Interfaces
{
    public interface IAdminSlotService
    {
        public Task<IList<SlotForResultDto>> RetrieveAllAsync(SlotCategory category);

        public ValueTask<SlotForResultDto> RetrieveAsync(Guid id);

        public ValueTask<SlotForResultDto> Update(Guid id, SlotForCreationDto slot);

        // ambigues public ValueTask<bool> DeleteAsync(Guid id);
    }
}
