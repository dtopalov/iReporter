﻿namespace IReporter.Services.Data
{
    using System.Linq;

    using IReporter.Data.Common;
    using IReporter.Data.Models;
    using IReporter.Services.Web;

    public class ArticlesService : IArticlesService
    {
        private readonly IDbRepository<Article> articles;
        private readonly IIdentifierProvider identifierProvider;

        public ArticlesService(IDbRepository<Article> articles, IIdentifierProvider identifierProvider)
        {
            this.articles = articles;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public IQueryable<Article> GetAllWithDeleted()
        {
            return this.articles.AllWithDeleted();
        }

        public Article GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var article = this.articles.GetById(intId);
            return article;
        }

        public void Update(Article article)
        {
            this.articles.Update(article);
            this.Save();
        }

        public void Create(Article article)
        {
            this.articles.Add(article);
            this.Save();
        }

        public void Save()
        {
            this.articles.Save();
        }
    }
}
