using AutoMapper;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.UserDto;
using Safespot.Service.Exceptions;

namespace Safespot.Service.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        private readonly IMapper mapper;

        public UserService(IRepository<User> repository,
            IMapper mapper)
        {
            this._repository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            if (dto is null)
                throw new SafespotException("Missing fields exists", 404);

            var userDb = this.mapper.Map<User>(dto);
            var result = await this._repository.InsertAsync(userDb);
            await this._repository.SaveAsync();

            return this.mapper.Map<UserForResultDto>(result);
        }

        public async Task<IEnumerable<UserForResultDto>> AllUsersAsync()
        {
            var allUsers = await this._repository.SelectAllAsync(p => p != null);

            return this.mapper.Map<IEnumerable<UserForResultDto>>(allUsers);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var dbEntity = await this._repository.SelectAsync(p => p.Id == Id);
            var result = await this._repository.DeleteAsync(dbEntity);
            await this._repository.SaveAsync();

            return result;
        }

        public async Task<UserForResultDto> EditAsync(UserForCreationDto dto)
        {
            var dbEntity = await this._repository.SelectAsync(p => p.Id == dto.Id);

            if (dbEntity is null)
                throw new SafespotException("Attempt to change the user that doesn't exist", 404);

            var userDb = this.mapper.Map<User>(dto);

            var result = this._repository.Update(userDb);
            await this._repository.SaveAsync();

            return this.mapper.Map<UserForResultDto>(result);
        }

        public async ValueTask<UserForResultDto> RetrieveAsync(Guid id)
        {
            var dbUser = await this._repository.SelectAsync(p => p.Id == id);

            if (dbUser == null) throw new SafespotException("User does not exist", 404);

            return this.mapper.Map<UserForResultDto>(dbUser);
        }
    }
}
