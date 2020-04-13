using AutoMapper;
using BlogBL.Models;
using Blog.Models;

namespace Blog.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<ArticleModel, ArticleBL>().ReverseMap();
            CreateMap<CommentModel, CommentBL>().ReverseMap();
            CreateMap<AuthorModel, AuthorBL>().ReverseMap();
        }
    }
}