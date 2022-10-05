using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.UserDTO;
using AutoMapper;

namespace Alumni_Network_Portal_BE.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Mapping from user to the respective DTOs
            CreateMap<User, UserReadDTO>()
                .PreserveReferences();

            CreateMap<UserCreateDTO, User>();

            CreateMap<UserUpdateDTO, User>();
        }
    }
}

