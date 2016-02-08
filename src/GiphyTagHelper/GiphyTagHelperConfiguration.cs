namespace GiphyTagHelper
{
    public class GiphyTagHelperConfiguration
    {
        public string ApiKey { get; }

        public GiphyTagHelperConfiguration(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
