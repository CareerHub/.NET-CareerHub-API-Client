﻿using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Public.News {
    public interface INewsApi {
        Task<IEnumerable<NewsModel>> GetNews();
        Task<NewsModel> GetNews(int id);
        Task<IEnumerable<NewsModel>> SearchNews(string text, int? take = null, int? skip = null);
    }
}
