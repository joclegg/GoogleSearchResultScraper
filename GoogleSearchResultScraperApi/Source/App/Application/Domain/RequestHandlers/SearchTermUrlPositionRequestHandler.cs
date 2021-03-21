using System.Threading;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application.Domain.Requests;
using MediatR;

namespace GoogleSearchResultScraperApi.Application.Domain.RequestHandlers
{
    internal class SearchTermUrlPositionRequestHandler : IRequestHandler<SearchTermUrlPositionRequest, int[]>
    {
        private readonly ISearchAnalyser searchAnalyser;

        public SearchTermUrlPositionRequestHandler(ISearchAnalyser searchAnalyser)
        {
            this.searchAnalyser = searchAnalyser;
        }
        
        public async Task<int[]> Handle(SearchTermUrlPositionRequest request, CancellationToken cancellationToken) => 
            await searchAnalyser.GetSearchResultPositions(request.SearchTerm, request.Url, cancellationToken).ConfigureAwait(false);
    }
}