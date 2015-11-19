using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Public.API.News.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.News {
    public interface INewsApi {
        [Get("api/public/v1/news")]
        Task<IEnumerable<NewsModel>> GetNews();
        [Get("api/public/v1/news/search")]
        Task<IEnumerable<NewsModel>> SearchNews(string text, int? take = null, int? skip = null);
        [Get("api/public/v1/news/{id}")]
        Task<NewsModel> GetNews(int id);
    }
}
