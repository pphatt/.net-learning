using AutoMapper;
using Server.Application.Common.Dtos.Comments;
using Server.Application.Common.Dtos.Posts;
using Server.Application.Common.Dtos.Reactions;
using Server.Domain.Entity.Content;

namespace Server.API.Common.Mapper;

public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        // Post
        CreateMap<Post, PostDto>();
        CreateMap<PostComments, PostCommentsDto>();
        CreateMap<PostLikes, PostLikesDto>();
    }
}
