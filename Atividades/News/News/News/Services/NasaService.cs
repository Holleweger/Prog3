using News.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    public class NasaService
    {
        public async Task<Root> GetNasa(NasaScope scope)
        {
            string url2 = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1001&api_key=wnTZt2UdCoQQGMBVIQhMRb0tX5CDqFAj8oqz0PSr";
            var webclient2 = new WebClient();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url2);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            Root retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(jsonResponse);
            return retorno;

            string url = GetUrl(scope);

            var webclient = new WebClient();
            webclient.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            string ret = string.Empty;

            try
            {
                ret = await webclient.DownloadStringTaskAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Photo retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<Photo>(ret);

            return retorno;

            //var json = await webclient.DownloadStringTaskAsync(url);
            //return Newtonsoft.Json.JsonConvert.DeserializeObject<NewsResult>(json);
        }

        private string GetUrl(NasaScope scope)
        {
            return scope switch
            {
                NasaScope.Global => Global,
                _ => throw new Exception("Undefined scope")
            };
        }
        private string Global => "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1001&api_key=wnTZt2UdCoQQGMBVIQhMRb0tX5CDqFAj8oqz0PSr";
    }
}

