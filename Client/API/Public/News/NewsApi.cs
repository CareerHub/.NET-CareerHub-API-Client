using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Public.News {
    internal sealed class NewsApi : IDisposable, INewsApi {

        private const string ApiBase = "api/public/v1/news";
        private readonly OAuthHttpClient client = null;

        public NewsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<NewsModel>> GetNews() {
            return client.GetResource<IEnumerable<NewsModel>>("");
		}

        public Task<IEnumerable<NewsModel>> SearchNews(string text, int? take = null, int? skip = null) {
            string resource = "search?text=" + text;
            resource = UrlUtility.AddPagingParams(resource, take, skip);
            return client.GetResource<IEnumerable<NewsModel>>(resource);
        }

        public Task<NewsModel> GetNews(int id) {
            return client.GetResource<NewsModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
	}
}