using AutoMapper;
using BlogBL;
using LightInject;
using LightInject.Mvc;
using LightInject.WebApi;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace Blog.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configure()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectCongiguration.Configuration(container);

            container.Register<IAuthorService, AuthorService>();
            container.Register<IArticleService, ArticleService>();
            container.Register<ICommentService, CommentService>();

            container.EnableMvc();
        }

    }
}