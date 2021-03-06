﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlogBL.Models;
using BlogDAL.Models;
using BlogDAL.Repositories;

namespace BlogBL
{
    public interface IArticleService : IGenereicService<ArticleBL>
    {

    }

    public class ArticleService : GenericService<ArticleBL, Article>, IArticleService
    {
        private readonly IMapper _mapper;
        public ArticleService(IGenericRepository<Article> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override ArticleBL Map(Article model)
        {
            return _mapper.Map<ArticleBL>(model);
        }

        public override Article Map(ArticleBL model)
        {
            return _mapper.Map<Article>(model);
        }

        public override IQueryable<ArticleBL> Project(IQueryable<Article> entitiesList)
        {
            return _mapper.ProjectTo<ArticleBL>(entitiesList);
        }

        public override IEnumerable<ArticleBL> Map(IEnumerable<Article> entitiesList)
        {
            return _mapper.Map < IEnumerable<ArticleBL>>(entitiesList);
        }

        public override IEnumerable<Article> Map(IEnumerable<ArticleBL> entitiesList)
        {
            return _mapper.Map<IEnumerable<Article>>(entitiesList);
        }
    }
}
