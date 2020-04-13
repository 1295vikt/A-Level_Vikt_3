using AutoMapper;
using System.Collections.Generic;
using BlogBL;
using System.Web.Mvc;
using Blog.Models;
using BlogBL.Models;
using System.Linq;
using System;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public HomeController(IArticleService articleService, IAuthorService authorService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listBL = _articleService.QueryAll().OrderByDescending(x=>x.Date).Take(3);

            var articles = _mapper.Map<IEnumerable<ArticleModel>>(listBL);

            return View(articles);

        }


        public ActionResult Contact()
        {
            return View();
        }

    }
}