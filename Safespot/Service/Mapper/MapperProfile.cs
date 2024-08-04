using AutoMapper;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.DTO.SlotDto;
using Safespot.Service.DTO.UserDto;

namespace Safespot.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();

            CreateMap<ParkingZone, ParkingZoneForCreationDto>().ReverseMap();
            CreateMap<ParkingZone, ParkingZoneForResultDto>().ReverseMap();

            CreateMap<ParkingZoneForResultDto, ParkingZone>().ReverseMap();
            CreateMap<ParkingZone, ParkingZoneForCreationDto>().ReverseMap();

            CreateMap<Slot, SlotForCreationDto>().ReverseMap();
            CreateMap<Slot, SlotForResultDto>().ReverseMap();
        }
    }
}
