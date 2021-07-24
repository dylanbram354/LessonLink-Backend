using AutoMapper;
using capstoneBackend.DataTransferObjects;
using capstoneBackend.Models;

namespace capstoneBackend.Managers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
