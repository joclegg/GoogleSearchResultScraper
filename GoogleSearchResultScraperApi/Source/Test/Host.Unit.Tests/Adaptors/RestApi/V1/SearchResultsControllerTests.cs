using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using GoogleSearchResultScraperApi.Application.Domain.Requests;
using GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Host.Unit.Tests.Adaptors.RestApi.V1
{
    [TestFixture]
    public class SearchResultsControllerTests
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly IFixture fixture = new Fixture();
        private SearchResultsController controller = null!;
        private IMediator mediator = null!;
        private IResultTranslator translator = null!;

        [SetUp]
        public void SetUp()
        {
            mediator = Substitute.For<IMediator>();
            translator = Substitute.For<IResultTranslator>();
            controller = new SearchResultsController(mediator, translator);
        }

        [Test]
        public async Task Given_ASearchRequest_When_PostCalled_Then_ReturnsExpectedString()
        {
            // Arrange
            const string? expected = "some string result";
            var ints = fixture.CreateMany<int>().ToArray();

            mediator
                .Send(Arg.Any<SearchTermUrlPositionRequest>(), cancellationToken)
                .Returns(ints);

            translator
                .Translate(ints)
                .Returns(expected);
            
            var request = new SearchRequest
            {
                SearchTerm = fixture.Create<string>(),
                Url = "www.valid.com"
            };
            
            // Act    
            var response = await controller.Post(request, cancellationToken);

            // Assert    
            var objectResult = response as OkObjectResult;
            var actual = objectResult?.Value;
            actual.ShouldBe(expected);
        }

        [Test]
        public async Task Given_ABadRequest_When_PostCalled_Then_ReturnsExpectedBadRequest()
        {
            // Arrange
            const string? expected = "some string result";
            var ints = fixture.CreateMany<int>().ToArray();

            mediator
                .Send(Arg.Any<SearchTermUrlPositionRequest>(), cancellationToken)
                .Returns(ints);

            translator
                .Translate(ints)
                .Returns(expected);
            
            var request = new SearchRequest
            {
                SearchTerm = fixture.Create<string>(),
                Url = "invalid사랑"
            };
            
            // Act    
            var response = await controller.Post(request, cancellationToken);

            // Assert    
            response.ShouldBeAssignableTo<BadRequestResult>();
        }
    }
}