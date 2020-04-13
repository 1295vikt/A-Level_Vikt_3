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
    public class ArticleController : Controller
    {


        private readonly IArticleService _articleService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IAuthorService authorService, IMapper mapper)
        {
            _articleService = articleService;
            _authorService = authorService;
            _mapper = mapper;
        }

        // GET: Article
        public ActionResult Index()
        {
            var listBL = _articleService.QueryAll().OrderByDescending(x => x.Date).ToList();

            if (!listBL.Any())
            {
                return RedirectToAction("NoArticles");
            }

            var articles = _mapper.Map<IEnumerable<ArticleModel>>(listBL);

            var authorsDictionary = _authorService.GetAuthorDictionaryIdNickname();
            ViewBag.Authors = authorsDictionary;

            return View(articles);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            ;
            var articleBL = _articleService.FindById(id);
            var article = _mapper.Map<ArticleModel>(articleBL);

            var authorsDictionary = _authorService.GetAuthorDictionaryIdNickname();
            ViewBag.Authors = authorsDictionary;

            return View(article);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            var authorSelectList = _authorService.QueryAll().Select(x => new SelectListItem
            {
                Text = x.Nickname,
                Value = x.Id.ToString(),
            }).ToList();

            ViewBag.Authors = authorSelectList;
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //TODO: Add insert logic here
            model.Date = DateTime.Now;
            if (string.IsNullOrEmpty(model.Image))
                model.Image = "~/Resources/No_image_available.png";

            var modelBL = _mapper.Map<ArticleBL>(model);

            _articleService.Create(modelBL);

            return RedirectToAction("Index");

        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            var modelBL = _articleService.FindById(id);
            var article = _mapper.Map<AuthorModel>(modelBL);
            return View(article);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ArticleModel model)
        {
            var modelBL = _mapper.Map<ArticleBL>(model);
            _articleService.Edit(modelBL);

            return RedirectToAction("Index");

        }

        // GET: Article/Delete/5

        // POST: Article/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NoArticles()
        {
            if (!_authorService.QueryAll().Any())
            {
                return RedirectToAction("NoAuthors", "Authors");
            }
            return View();
        }

    }
}
