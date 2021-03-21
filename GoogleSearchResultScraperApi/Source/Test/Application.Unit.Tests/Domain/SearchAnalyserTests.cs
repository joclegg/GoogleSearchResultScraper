using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using GoogleSearchResultScraperApi.Application.Domain;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using GoogleSearchResultScraperApi.Application.Ports;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Application.Unit.Tests.Domain
{
    [TestFixture]
    public class SearchAnalyserTests
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None; 
        private readonly IFixture fixture = new Fixture();
        private ISearchAnalyser analyser = null!;
        private IHtmlPageProvider provider = null!;
        private IHtmlPageParser parser = null!;

        [SetUp]
        public void SetUp()
        {
            provider = Substitute.For<IHtmlPageProvider>();
            parser = Substitute.For<IHtmlPageParser>();
            analyser = new SearchAnalyser(provider, parser);
        }

        [Test]
        public async Task Given_ProviderAndParserReturn_When_GetSearchResultPositionsCalled_Then_ReturnsArray()
        {
            // Arrange
            var expected = fixture.CreateMany<int>().ToArray();
            var searchTerm = fixture.Create<string>();
            var url = fixture.Create<string>();
            var page = fixture.Create<string>();
            provider
                .GetPage(searchTerm, cancellationToken)
                .Returns(page);

            parser
                .GetPositions(page, url, cancellationToken)
                .Returns(expected);
            
            // Act
            var actual = await analyser.GetSearchResultPositions(searchTerm, url, cancellationToken);

            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_ParserThrows_When_GetSearchResultPositionsCalled_Then_ThrowsInternal()
        {
            // Arrange
            var searchTerm = fixture.Create<string>();
            var url = fixture.Create<string>();
            var page = fixture.Create<string>();
            provider
                .GetPage(searchTerm, cancellationToken)
                .Returns(page);

            parser
                .GetPositions(page, url, cancellationToken)
                .Throws<ArgumentException>();

            // Act & Assert
            Should.Throw<ArgumentException>(async () =>
                await analyser.GetSearchResultPositions(searchTerm, url, cancellationToken));
        }

        [Test]
        public void Given_ProviderThrows_When_GetSearchResultPositionsCalled_Then_ThrowsInternal()
        {
            // Arrange
            var searchTerm = fixture.Create<string>();
            var url = fixture.Create<string>();
            provider
                .GetPage(searchTerm, cancellationToken)
                .Throws<ArgumentException>();

            // Act & Assert
            Should.Throw<ArgumentException>(async () =>
                await analyser.GetSearchResultPositions(searchTerm, url, cancellationToken));
        }
    }
}