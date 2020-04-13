using AutoMapper;
using BlogBL.Models;
using BlogDAL.Models;

namespace BlogBL
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<ArticleBL, Article>().ReverseMap();
            CreateMap<CommentBL, Comment>().ReverseMap();
            CreateMap<AuthorBL, Author>().ReverseMap();
        }
    }
}
