using AutoMapper;
using STUdemyKurs.DTOs;
using STUdemyKurs.Models;

namespace STUdemyKurs.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailsDto>();
            
        }
    }
}
