using Alumni_Network_Portal_BE.Models.Domain;
using Alumni_Network_Portal_BE.Models.DTOs.PostDTO;
using AutoMapper;

namespace Alumni_Network_Portal_BE.Profiles
{
    public class PostProfile : Profile
    {

        public PostProfile()
        {
            //Mapping from post to the respective DTOs
            CreateMap<Post, PostReadDTO>();

            CreateMap<Post, PostGroupReadDTO>();

            CreateMap<Post, PostUserReadDTO>();

            CreateMap<PostCreateDTO, Post>();

            CreateMap<PostUpdateDTO, Post>();

        }
    }
}
