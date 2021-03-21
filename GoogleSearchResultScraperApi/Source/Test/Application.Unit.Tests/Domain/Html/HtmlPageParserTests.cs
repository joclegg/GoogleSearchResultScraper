using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Application.Unit.Tests.Domain.Html
{
    [TestFixture]
    public class HtmlPageParserTests
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly IFixture fixture = new Fixture();
        private IHtmlPageParser parser = null!;
        private ISearchResultUrlsProvider urlsProvider = null!;
        private ISearchResultUrlsPositionFinder urlsPositionFinder = null!;

        [SetUp]
        public void SetUp()
        {
            urlsProvider = Substitute.For<ISearchResultUrlsProvider>();
            urlsPositionFinder = Substitute.For<ISearchResultUrlsPositionFinder>();
            parser = new HtmlPageParser(urlsProvider, urlsPositionFinder);
        }

        [Test]
        public async Task Given_ProviderAndFinderReturn_When_GetPositionsCalled_Then_ReturnsArray()
        {
            // Arrange
            var expected = fixture.CreateMany<int>().ToArray();
            var url = fixture.Create<string>();
            var page = fixture.Create<string>();
            var urls = fixture.CreateMany<string>().ToArray();
            urlsProvider
                .GetUrls(page, cancellationToken)
                .Returns(urls);

            urlsPositionFinder
                .GetPositions(urls, url, cancellationToken)
                .Returns(expected);
            
            // Act
            var actual = await parser.GetPositions(page, url, cancellationToken);

            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_ProviderThrows_When_GetPositionsCalled_Then_ThrowsInternal()
        {
            // Arrange
            var url = fixture.Create<string>();
            var page = fixture.Create<string>();
            urlsProvider
                .GetUrls(page, cancellationToken)
                .Throws<ArgumentException>();

            // Act & Assert
            Should.Throw<ArgumentException>(async () =>
                await parser.GetPositions(page, url, cancellationToken));
        }

        [Test]
        public void Given_FinderThrows_When_GetPositionsCalled_Then_ThrowsInternal()
        {
            // Arrange
            var url = fixture.Create<string>();
            var page = fixture.Create<string>();
            var urls = fixture.CreateMany<string>().ToArray();
            urlsProvider
                .GetUrls(page, cancellationToken)
                .Returns(urls);

            urlsPositionFinder
                .GetPositions(urls, url, cancellationToken)
                .Throws<ArgumentException>();

            // Act & Assert
            Should.Throw<ArgumentException>(async () =>
                await parser.GetPositions(page, url, cancellationToken));
        }
    }
}