
using System.Net.Http.Headers;

namespace TheFetcher
{
    public class Fetcher: IFetcher
    {
        private readonly HttpClient _client;
        private string _link = "";
        public string BaseUrl { get; } = null!;
        public Dictionary<string,string> Headers { get; }
        public Dictionary<string, string> Params { get; }

        public Fetcher(
            string url,
            Dictionary<string, string>? queryParmas = null,
            Dictionary<string, string>? headers = null
        )
        {
            _client = new HttpClient();
            BaseUrl = url;
            Params = queryParmas ?? new Dictionary<string, string>();
            Headers = headers ?? new Dictionary<string, string>();
        }

        public async Task<T> GetAsync<T>(string path = "") where T : class
        {
            try
            {
                ReadyRequest(path);
                var response = await _client.GetAsync(_link);
                response.EnsureSuccessStatusCode();
                var item = await response.Content.ReadAsAsync<T>();
                
                return item;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        public async Task<string> GetAsync(string path = "")
        {
            try
            {
                ReadyRequest(path);
                var response = await _client.GetAsync(_link);
                response.EnsureSuccessStatusCode();
                var stringItem = await response.Content.ReadAsStringAsync();

                return stringItem;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        public void AddParam(string query, string value)
        {
            Params.Add(query, value);
        }
        public void AddHeader(string header, string value)
        {
            Headers.Add(header, value);
        }
        public string ShowLink(string path = "")
        {
            ReadyRequest(path);
            return _link;
        }
            
        private void ReadyRequest(string path)
        {
            ReadyClientHeaders();
            _link = BuildUrl(path);
        }
        private string BuildUrl (string path)
        {
            bool check;
            string urlLink;
            
            if (path.Length != 0)
            {
                check = ContainsCharacterAtPos(BaseUrl, '/', BaseUrl.Length - 1);
                urlLink = check ? BaseUrl[0..^1] : BaseUrl;
                check = ContainsCharacterAtPos(path, '/', 0);
                urlLink += check ? path: $"/{path}";
            }
            else
            {
                urlLink = BaseUrl;
            }
            
            foreach (var param in Params)
            {
                urlLink += $"?{param.Key}={param.Value}";
            }
            return urlLink;
        }
        private void ReadyClientHeaders()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var item in Headers)
            {
                _client.DefaultRequestHeaders.Add(item.Key, item.Value);
            }
        }
        private bool ContainsCharacterAtPos(string text, char character, int pos)
        {
            return text.ElementAt(pos) == character;
        }
    }
}
