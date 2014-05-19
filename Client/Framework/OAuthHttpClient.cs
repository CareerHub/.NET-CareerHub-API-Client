using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.Framework {
	internal sealed class OAuthHttpClient : IDisposable {
        private readonly string BaseUrl;
        private readonly HttpClient httpClient;

        public OAuthHttpClient(string baseUrl, string location, string accessToken) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException("baseUrl");
            if (String.IsNullOrWhiteSpace(location)) throw new ArgumentNullException("location");
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException("accessToken");
            
			BaseUrl = baseUrl.TrimEnd('/') + '/' + location.TrimEnd('/') + '/';

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
		}

        public async Task<GetResult<T>> GetResource<T>(string resource, bool relative = true) {
            var uri = GetResourceURI(resource, relative);
            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) {
                // TODO: Get meaningful error
                return new GetResult<T>("Could not get resource");
            } else {
                T result = await response.Content.ReadAsAsync<T>();
                return new GetResult<T>(result);
            }
		}
        
        public async Task<PostResult<T>> PostResource<T>(string resource, bool relative = true) {
            var uri = GetResourceURI(resource, relative);
            var empty = new StringContent("");
            var response = await httpClient.PostAsync(uri, empty);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                return new PostResult<T>(error);
            } else {
                T result = await response.Content.ReadAsAsync<T>();
                return new PostResult<T>(result);
            }
        }

        public async Task<PostResult<R>> PostResource<T, R>(string resource, T content, bool relative = true) {
            var uri = GetResourceURI(resource, relative).ToString();
            var response = await httpClient.PostAsync<T>(uri, content, new JsonMediaTypeFormatter());

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                return new PostResult<R>(error);
            } else {
                R result = await response.Content.ReadAsAsync<R>();
                return new PostResult<R>(result);
            }
        }

        public async Task<DeleteResult> DeleteResource(string resource, bool relative = true) {
            var uri = GetResourceURI(resource, relative);
            var response = await httpClient.DeleteAsync(uri);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                return new DeleteResult(error);
            } else {
                return new DeleteResult();
            }
        }
        
        private Uri GetResourceURI(string resource, bool relative) {
            if (relative) {
                resource = BaseUrl + resource;
            }

            return new Uri(resource);
        }

        public void Dispose() {
            httpClient.Dispose();
        }
    }
}