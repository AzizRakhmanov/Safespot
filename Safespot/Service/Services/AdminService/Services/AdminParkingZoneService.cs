using AutoMapper;
using Safespot.Data.IRepositories;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ParkingZone;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.Exceptions;
using Safespot.Service.Services.AdminService.Interfaces;

namespace Safespot.Service.Services.AdminService.Services
{
    public class AdminParkingZoneService : IAdminParkingZoneService
    {
        private readonly IRepository<ParkingZone> parkingZoneRepository;
        private readonly IRepository<Address> addressRepository;
        private readonly IMapper mapper;

        public AdminParkingZoneService
            (
            IRepository<ParkingZone> repository,
            IRepository<Address> addressRepository,
            IMapper profile)
        {
            this.parkingZoneRepository = repository;
            this.addressRepository = addressRepository;
            this.mapper = profile;
        }

        /// <summary>
        /// admin adds the new parking zone to database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async ValueTask<ParkingZoneForResultDto> AddAsync(ParkingZoneForCreationDto dto)
        {
            if (dto is null)
                throw new SafespotException("Parking zone not initiated", 404);

            dto.AddressId = new Guid("FC7EB6CD-3F23-4D26-B764-97D06FDF7959");

            var mappedUser = this.mapper.Map<ParkingZone>(dto);

            //Guid id = new Guid("FC7EB6CD-3F23-4D26-B764-97D06FDF7959");
            //mappedUser.AddressId = id;
            //mappedUser.Address = new Address()
            //{
            //    Id = id,
            //    City = "Tashkent",
            //    District = "Yunusabod",
            //    Country = "Uzbekistan",
            //    GoogleMapUrl = "Url"
            //};

            await this.parkingZoneRepository.InsertAsync(mappedUser);
            await this.addressRepository.SaveAsync();

            var resultDto = this.mapper.Map<ParkingZoneForResultDto>(dto);

            return resultDto;
        }



        /// <summary>
        /// admins removes the parking zone in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="SafespotException"></exception>
        public async Task<bool> RemoveAsync(Guid id)
        {
            var @object = await this.parkingZoneRepository.SelectAsync(p => p.Id == id);
            if (@object is null)
                throw new SafespotException("Parking zone not found", 404);

            var result = await this.parkingZoneRepository.DeleteAsync(@object);

            return result;
        }




        /// <summary>
        /// retrieve all the parking zones from database using pagination
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        public async Task<IList<ParkingZoneForResultDto>> RetrieveAllAsync()
        {
            string[] includes = { "Address" };
            var result = await this.parkingZoneRepository.SelectAllAsync(p => p != null, includes);


            return this.mapper.Map<IList<ParkingZoneForResultDto>>(result);
        }



        /// <summary>
        /// admin retrieves parking zone by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="SafespotException"></exception>
        public async ValueTask<ParkingZoneForResultDto> RetrieveAsync(Guid id)
        {
            string[] includes = { "Address" };
            var result = await this.parkingZoneRepository.SelectAsync(p => p.Id == id, includes);

            if (result is null)
                throw new SafespotException("User not found", 404);

            return this.mapper.Map<ParkingZoneForResultDto>(result);
        }



        /// <summary>
        /// admins updates the parking zone by id and new date(ParkingZoneForCreationDto)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="SafespotException"></exception>
        public async ValueTask<ParkingZoneForResultDto> UpdateAsync(ParkingZoneForCreationDto dto)
        {
            var @object = await this.parkingZoneRepository.SelectAsync(p => p.Id == dto.Id);
            if (@object == null)
                throw new SafespotException("User not found", 404);

            var mappedUser = this.mapper.Map<ParkingZone>(dto);
            this.parkingZoneRepository.Update(mappedUser);

            var resultDto = this.mapper.Map<ParkingZoneForResultDto>(@object);

            return resultDto;
        }



        /// <summary>
        /// returns the parking zone with detailed addressRepository information
        /// </summary>
        /// <param name="parkingZoneId"></param>
        /// <returns></returns>
        public async Task<ParkingZoneForDetailsDto> RetrieveParkingZoneDetails(Guid parkingZoneId)
        {
            var includes = new string[] { "Address" };
            var result = await this.parkingZoneRepository.SelectAsync(p => p.Id == parkingZoneId, includes);

            var dto = new ParkingZoneForDetailsDto()
            {
                Id = result.Id,
                Name = result.Name,
                FreeSlot = result.FreeSlot,
                EconomSlot = result.EconomSlot,
                BusinessSlot = result.BusinessSlot,
                City = result.Address.City,
                Region = result.Address.Region,
                District = result.Address.District,
                Country = result.Address.Country,
                GoogleMapUrl = result.Address.GoogleMapUrl
            };

            return dto;
        }
    }
}
