namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1
{
    internal class ResultTranslator : IResultTranslator
    {
        public string Translate(int[] result) =>
            result.Length == 0 
                ? "0" 
                : string.Join(", ", result);
    }
}