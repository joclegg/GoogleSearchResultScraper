using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application.Domain.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SearchResultsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IResultTranslator translator;

        public SearchResultsController(
            IMediator mediator,
            IResultTranslator translator)
        {
            this.mediator = mediator;
            this.translator = translator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] SearchRequest request, CancellationToken cancellationToken)
        {
            if (!Uri.IsWellFormedUriString(request.Url, UriKind.RelativeOrAbsolute)) return new BadRequestResult();

            var uriBuilder = new UriBuilder(request.Url);
            var result = await mediator.Send(new SearchTermUrlPositionRequest(request.SearchTerm, uriBuilder.Uri.Authority), cancellationToken);
            var resultString = translator.Translate(result);
            return new OkObjectResult(resultString);
        }
    }
}