using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.News {
    public interface INewsApi {
        Task<GetResult<IEnumerable<NewsModel>>> GetNews();
        Task<GetResult<NewsModel>> GetNews(int id);
        Task<GetResult<IEnumerable<NewsModel>>> SearchNews(string text, int? take = null, int? skip = null);
    }
}
