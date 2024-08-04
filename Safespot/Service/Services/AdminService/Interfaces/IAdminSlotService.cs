using Safespot.Models.Entities;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.Extentions;

namespace Safespot.Service.Services.AdminService.Interfaces
{
    public interface IAdminSlotService
    {
        public Task<IList<SlotForResultDto>> RetrieveAllAsync(SlotCategory category, PaginationParams @params);

        public ValueTask<SlotForResultDto> RetrieveAsync(Guid id);

        public ValueTask<SlotForResultDto> Update(Guid id, SlotForCreationDto slot);

        public ValueTask<bool> DeleteAsync(Guid id);
    }
}
