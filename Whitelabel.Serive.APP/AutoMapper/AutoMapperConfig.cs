using Whitelabel.Service.Domain.DTOs;
using Whitelabel.Service.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Whitelabel.Service.APP.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
