using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.TopicDTO;
using AutoMapper;

namespace Alumni_Network_Portal_BE.Profiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicReadDTO>();

            CreateMap<Topic, TopicUserReadDTO>();


            CreateMap<TopicCreateDTO, Topic>();
        }
    }
}
