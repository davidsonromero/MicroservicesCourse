using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue _contentType = new MediaTypeHeaderValue("application/json"); 

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong while calling the API: {responseMessage.ReasonPhrase}");
            if(responseMessage.Content == null)
                throw new ApplicationException("Null response from API");
            string dataAsString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = _contentType;
            return client.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = _contentType;
            return client.PutAsync(url, content);
        }
    }
}
