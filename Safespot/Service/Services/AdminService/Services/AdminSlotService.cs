using AutoMapper;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.Exceptions;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Service.Services.AdminService.Services
{
    public class AdminSlotService : IAdminSlotService
    {
        private readonly IRepository<Slot> repository;
        private readonly IMapper mapper;

        public AdminSlotService(
            IRepository<Slot> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IList<SlotForResultDto>> RetrieveAllAsync(SlotCategory category)
        {
            var all = (await this.repository.SelectAllAsync(p => p.Category == category));


            return this.mapper.Map<IList<SlotForResultDto>>(all);
        }

        public async ValueTask<SlotForResultDto> RetrieveAsync(Guid id)
        {
            var @object = await this.repository.SelectAsync(p => p.Id == id);
            if (@object == null)
                throw new SafespotException("User not found", 404);

            var mappedUser = this.mapper.Map<SlotForResultDto>(@object);

            return mappedUser;


        }

        public async ValueTask<SlotForResultDto> Update(Guid id, SlotForCreationDto slot)
        {
            var existSlot = await this.repository.SelectAsync(p => p.Id == id);
            if (existSlot == null)
                throw new SafespotException("Slot not found", 404);

            var dbSlot = this.mapper.Map<Slot>(slot);
            this.repository.Update(dbSlot);

            return this.mapper.Map<SlotForResultDto>(dbSlot);

        }
    }
}
