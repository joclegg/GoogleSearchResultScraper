namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1
{
    public class SearchRequest
    {
        public string SearchTerm { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}