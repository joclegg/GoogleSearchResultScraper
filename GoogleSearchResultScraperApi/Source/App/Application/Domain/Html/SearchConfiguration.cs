namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    public class SearchConfiguration
    {
        public string XPathPattern { get; set; } = null!;
        public int MaxSearchTerms { get; set; }
    }
}