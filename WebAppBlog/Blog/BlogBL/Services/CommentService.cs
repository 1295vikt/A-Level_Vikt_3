using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlogBL.Models;
using BlogDAL.Models;
using BlogDAL.Repositories;

namespace BlogBL
{
    public interface ICommentService : IGenereicService<CommentBL>
    {

    }

    public class CommentService : GenericService<CommentBL, Comment>, ICommentService
    {
        private readonly IMapper _mapper;
        public CommentService(IGenericRepository<Comment> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override CommentBL Map(Comment model)
        {
            return _mapper.Map<CommentBL>(model);
        }

        public override Comment Map(CommentBL model)
        {
            return _mapper.Map<Comment>(model);
        }

        public override IQueryable<CommentBL> Project(IQueryable<Comment> entitiesList)
        {
            return _mapper.ProjectTo<CommentBL>(entitiesList);
        }

        public override IEnumerable<CommentBL> Map(IEnumerable<Comment> entitiesList)
        {
            return _mapper.Map<IEnumerable<CommentBL>>(entitiesList);
        }

        public override IEnumerable<Comment> Map(IEnumerable<CommentBL> entitiesList)
        {
            return _mapper.Map<IQueryable<Comment>>(entitiesList);
        }
    }
}