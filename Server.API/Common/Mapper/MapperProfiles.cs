using AutoMapper;
using Server.Application.Common.Dtos.Comments;
using Server.Application.Common.Dtos.Posts;
using Server.Application.Common.Dtos.Reactions;
using Server.Application.Features.CommentApp.Commands.CreateComment;
using Server.Application.Features.CommentApp.Commands.UpdateComment;
using Server.Application.Features.PostApp.Commands.CreatePost;
using Server.Application.Features.PostApp.Commands.UpdatePost;
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

        CreateMap<CreatePostCommand, Post>()
            .ForMember(p => p.Id, opt => opt.Ignore())
            .ForMember(p => p.Slug, opt => opt.MapFrom(src => ""))
            .ForMember(p => p.PostComments, opt => opt.Ignore())
            .ForMember(p => p.PostLikes, opt => opt.Ignore())
            .ForMember(p => p.DateCreated, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(p => p.DateUpdated, opt => opt.Ignore())
            .ForMember(p => p.DateDeleted, opt => opt.Ignore());

        CreateMap<UpdatePostCommand, Post>()
            .ForMember(p => p.Slug, opt => opt.MapFrom(src => ""))
            .ForMember(p => p.PostComments, opt => opt.Ignore())
            .ForMember(p => p.PostLikes, opt => opt.Ignore())
            .ForMember(p => p.DateCreated, opt => opt.Ignore())
            .ForMember(p => p.DateUpdated, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(p => p.DateDeleted, opt => opt.Ignore());

        // PostComments
        CreateMap<CreateCommentCommand, PostComments>()
            .ForMember(c => c.Id, opt => opt.Ignore())
            .ForMember(c => c.DateCreated, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(c => c.DateUpdated, opt => opt.Ignore())
            .ForMember(c => c.DateDeleted, opt => opt.Ignore());

        CreateMap<UpdateCommentCommand, PostComments>()
            .ForMember(c => c.PostId, opt => opt.Ignore())
            .ForMember(c => c.UserId, opt => opt.Ignore())
            .ForMember(c => c.DateCreated, opt => opt.Ignore())
            .ForMember(c => c.DateUpdated, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(c => c.DateDeleted, opt => opt.Ignore());
    }
}
