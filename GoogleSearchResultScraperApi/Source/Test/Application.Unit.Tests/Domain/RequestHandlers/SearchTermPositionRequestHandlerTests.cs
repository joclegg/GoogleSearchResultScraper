using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using GoogleSearchResultScraperApi.Application.Domain;
using GoogleSearchResultScraperApi.Application.Domain.RequestHandlers;
using GoogleSearchResultScraperApi.Application.Domain.Requests;
using MediatR;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Application.Unit.Tests.Domain.RequestHandlers
{
    [TestFixture]
    public class SearchTermPositionRequestHandlerTests
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly IFixture fixture = new Fixture();
        private IRequestHandler<SearchTermUrlPositionRequest, int[]> handler = null!;
        private ISearchAnalyser searchAnalyser = null!;

        [SetUp]
        public void SetUp()
        {
            searchAnalyser = Substitute.For<ISearchAnalyser>();
            handler = new SearchTermUrlPositionRequestHandler(searchAnalyser);
        }

        [Test]
        public async Task Given_SearchAnalyserReturnsValue_When_HandleCalled_Then_ReturnsValue()
        {
            // Arrange
            var expected = fixture.CreateMany<int>().ToArray();
            var url = fixture.Create<string>();
            var searchTerm = fixture.Create<string>();
            searchAnalyser
                .GetSearchResultPositions(searchTerm, url, cancellationToken)
                .Returns(expected);

            var request = new SearchTermUrlPositionRequest(searchTerm, url);
            
            // Act
            var actual = await handler.Handle(request, cancellationToken);
            
            // Assert
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_SearchAnalyserThrows_When_HandleCalled_Then_ThrowsInternal()
        {
            // Arrange
            var url = fixture.Create<string>();
            var searchTerm = fixture.Create<string>();
            searchAnalyser
                .GetSearchResultPositions(searchTerm, url, cancellationToken)
                .Throws<ArgumentException>();
            
            var request = new SearchTermUrlPositionRequest(searchTerm, url);
            
            // Act && Assert    
            Should.Throw<ArgumentException>(async () => await handler.Handle(request, cancellationToken));
        }
    }
}