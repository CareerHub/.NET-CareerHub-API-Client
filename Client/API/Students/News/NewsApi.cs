using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.News {
    internal sealed class NewsApi : IDisposable, INewsApi {
        private const string ApiBase = "api/students/alpha/news";
        private readonly OAuthHttpClient client = null;

        public NewsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<GetResult<IEnumerable<NewsModel>>> GetNews() {
            return client.GetResource<IEnumerable<NewsModel>>("");
		}

        public Task<GetResult<IEnumerable<NewsModel>>> SearchNews(string text, int? take = null, int? skip = null) {
            string resource = "search?text=" + text;
            resource = UrlUtility.AddPagingParams(resource, take, skip);
            return client.GetResource<IEnumerable<NewsModel>>(resource);
        }

        public Task<GetResult<NewsModel>> GetNews(int id) {
            return client.GetResource<NewsModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
	}
}