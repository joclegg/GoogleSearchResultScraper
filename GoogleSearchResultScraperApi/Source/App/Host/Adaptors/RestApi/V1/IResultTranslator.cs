namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1
{
    public interface IResultTranslator
    {
        public string Translate(int[] result);
    }
}