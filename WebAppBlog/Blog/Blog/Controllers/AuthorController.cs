using AutoMapper;
using System.Collections.Generic;
using BlogBL;
using System.Web.Mvc;
using Blog.Models;
using BlogBL.Models;
using System.Linq;

namespace Blog.Controllers
{
    public class AuthorController : Controller
    {

        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }


        // GET: Author
        public ActionResult Index()
        {
            var listBL = _authorService.QueryAll();

            if (!listBL.Any())
            {
                return RedirectToAction("NoAuthors");
            }

            var authors = _mapper.Map<IEnumerable<AuthorModel>>(listBL);

            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var modelBL = _authorService.FindById(id);
            var author = _mapper.Map<AuthorModel>(modelBL);

            ViewBag.Articles = _authorService.GetArticleDictionaryIdTitle(id);

            return View(author);

        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorModel model)
        {



            //TODO: Add insert logic here
            if (string.IsNullOrEmpty(model.Avatar))
                model.Avatar = "~/Resources/user-blank.png";

            var modelBL = _mapper.Map<AuthorBL>(model);

            _authorService.Create(modelBL);

            return RedirectToAction("Index");
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var modelBL = _authorService.FindById(id);
            var author = _mapper.Map<AuthorModel>(modelBL);

            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuthorModel model)
        {
            // TODO: Add update logic here

            var modelBL = _mapper.Map<AuthorBL>(model);
            _authorService.Edit(modelBL);

            return RedirectToAction("Index");
        }

        // POST: Author/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _authorService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult NoAuthors()
        {
            return View();
        }

    }
}
