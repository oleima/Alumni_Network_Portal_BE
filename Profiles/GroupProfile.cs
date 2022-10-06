using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.GroupDTO;
using AutoMapper;

namespace Alumni_Network_Portal_BE.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            //Mapping from group to the respective DTOs
            CreateMap<Group, GroupReadDTO>().MaxDepth(1);

            CreateMap<GroupCreateDTO, Group>();

            CreateMap<GroupUpdateDTO, Group>();
        }
    }
}
