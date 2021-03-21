using MediatR;

namespace GoogleSearchResultScraperApi.Application.Domain.Requests
{
    public record SearchTermUrlPositionRequest(string SearchTerm, string Url) : IRequest<int[]>;
}