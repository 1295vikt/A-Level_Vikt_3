using System.Collections.Generic;
using BlogBL.Models;
using BlogDAL.Models;
using BlogDAL.Repositories;
using AutoMapper;
using System.Linq;

namespace BlogBL
{

    public interface IAuthorService : IGenereicService<AuthorBL>
    {
        Dictionary<int, string> GetArticleDictionaryIdTitle(int authorId);
        Dictionary<int, string> GetAuthorDictionaryIdNickname();
    }

    public class AuthorService : GenericService<AuthorBL, Author>, IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;
        public AuthorService(IGenericRepository<Author> repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override AuthorBL Map(Author model)
        {
            return _mapper.Map<AuthorBL>(model);
        }

        public override Author Map(AuthorBL model)
        {
            return _mapper.Map<Author>(model);
        }

        public override IQueryable<AuthorBL> Project(IQueryable<Author> entitiesList)
        {
            return _mapper.ProjectTo<AuthorBL>(entitiesList);
        }

        public override IEnumerable<AuthorBL> Map(IEnumerable<Author> entitiesList)
        {
            return _mapper.Map<IEnumerable<AuthorBL>>(entitiesList);
        }

        public override IEnumerable<Author> Map(IEnumerable<AuthorBL> entitiesList)
        {
            return _mapper.Map<IQueryable<Author>>(entitiesList);
        }

        public Dictionary<int, string> GetArticleDictionaryIdTitle(int authorId)
        {
            return _repository.Query(x => x.Id == authorId).SelectMany(x=>x.Articles).ToDictionary(x => x.Id, x => x.Title);
        }

        public Dictionary<int, string> GetAuthorDictionaryIdNickname()
        {
            return _repository.QueryAll().ToDictionary(x => x.Id, x => x.Nickname);
        }
    }
}
