using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleSearchResultScraperApi.Application.Domain.Html
{
    internal class SearchResultUrlsPositionFinder : ISearchResultUrlsPositionFinder
    {
        public Task<int[]> GetPositions(string[] urls, string url, CancellationToken cancellationToken)
        {
            if (urls.Length == 0) return Task.FromResult(Array.Empty<int>());
            var results = new List<int>();
            
            for (var i = 0; i < urls.Length; i++)
            {
                if (urls[i].Contains(url))
                {
                    results.Add(i + 1);
                }
            }

            return Task.FromResult(results.ToArray());
        }
    }
}