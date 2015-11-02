using CareerHub.Client.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework {
	public sealed class OAuthHttpClient : IDisposable {
        private readonly string BaseUrl;
        private readonly HttpClient httpClient;

        public OAuthHttpClient(string baseUrl, string location, string accessToken) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            if (String.IsNullOrWhiteSpace(location)) throw new ArgumentNullException(nameof(location));
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            
			BaseUrl = baseUrl.TrimEnd('/') + '/' + location.TrimEnd('/') + '/';

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
		}

        public async Task<T> GetResource<T>(string resource) {
            var uri = GetResourceURI(resource);
            var response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                throw new CareerHubApiHttpException(error, response.StatusCode);
            }

            T result = await response.Content.ReadAsAsync<T>();
            return result;
		}
        
        public async Task<T> PostResource<T>(string resource) {
            var uri = GetResourceURI(resource);
            var empty = new StringContent("");
            var response = await httpClient.PostAsync(uri, empty);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                throw new CareerHubApiHttpException(error, response.StatusCode);
            }

            T result = await response.Content.ReadAsAsync<T>();
            return result;
        }

        public async Task<R> PostResource<T, R>(string resource, T content) {
            var uri = GetResourceURI(resource).ToString();
            var response = await httpClient.PostAsJsonAsync<T>(uri, content);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                throw new CareerHubApiHttpException(error, response.StatusCode);
            } 

            R result = await response.Content.ReadAsAsync<R>();
            return result;
        }


        public async Task<R> PutResource<T, R>(string resource, T content) {
            var uri = GetResourceURI(resource).ToString();
            var response = await httpClient.PutAsJsonAsync<T>(uri, content);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                throw new CareerHubApiHttpException(error, response.StatusCode);
            }

            R result = await response.Content.ReadAsAsync<R>();
            return result;
        }

        public async Task DeleteResource(string resource) {
            var uri = GetResourceURI(resource);
            var response = await httpClient.DeleteAsync(uri);

            if (!response.IsSuccessStatusCode) {
                string error = await response.Content.ReadAsStringAsync();
                throw new CareerHubApiHttpException(error, response.StatusCode);
            }
        }
        
        private Uri GetResourceURI(string resource) {
            resource = BaseUrl + resource;
            return new Uri(resource);
        }

        public void Dispose() {
            httpClient.Dispose();
        }
    }
}