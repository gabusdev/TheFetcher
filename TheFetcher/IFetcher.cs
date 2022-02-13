using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFetcher
{
    public interface IFetcher
    {
        Task<T> GetAsync<T>(string path = "") where T : class;
        Task<string> GetAsync(string path = "");
        void AddQueryParam(string key, string value);
        string ShowLink(string path = "");
        void AddHeader(string header, string value);
    }
}
