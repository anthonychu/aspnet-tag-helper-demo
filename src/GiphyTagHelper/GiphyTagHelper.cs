using System.Threading.Tasks;
using Microsoft.AspNet.Razor.TagHelpers;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace GiphyTagHelper
{
    [OutputElementHint("img")]
    public class GiphyTagHelper : TagHelper
    {
        private GiphyTagHelperConfiguration _config;

        public GiphyTagHelper(GiphyTagHelperConfiguration config)
        {
            _config = config;
        }

        public string SearchTerm { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string url = await GetGiphyUrl(_config.ApiKey, SearchTerm);

            if (string.IsNullOrWhiteSpace(url))
            {
                output.SuppressOutput();
            } else
            {
                output.TagName = "img";
                output.TagMode = TagMode.SelfClosing;
                output.Attributes["src"] = url;
            }
        }

        private async Task<string> GetGiphyUrl(string apiKey, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return "";

            string giphyJson;
            string queryString =
                $"api_key={Uri.EscapeDataString(apiKey)}"
                + $"&s={Uri.EscapeDataString(searchTerm)}";

            using (var client = new HttpClient())
            {
                giphyJson = await client.GetStringAsync($"http://api.giphy.com/v1/gifs/translate?{queryString}");
            }
            dynamic giphy = JsonConvert.DeserializeObject(giphyJson);

            string url;
            try
            {
                url = giphy.data.images.original.url;
            }
            catch (Exception)
            {
                url = "";
            }

            return url;
        }
    }
}
