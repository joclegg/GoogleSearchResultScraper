using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Application.Unit.Tests.Domain.Html
{
    [TestFixture]
    public class SearchResultUrlsPositionFinderTests
    {
        private const string Url = "url";
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private ISearchResultUrlsPositionFinder finder = null!;

        [SetUp]
        public void SetUp()
        {
            finder = new SearchResultUrlsPositionFinder();
        }

        [Test]
        public async Task Given_StringsContainingString_When_GetPositionsCalled_Then_ReturnsPositionsArray()
        {
            // Arrange
            var expected = new[]
            {
                1,
                3,
                4
            };
            
            var urls = new[]
            {
                "url",
                "not it",
                "url/other stuff",
                "url > other stuff",
                "not it > other stuff"
            };

            // Act
            var actual = await finder.GetPositions(urls, Url, cancellationToken);
            
            // Assert    
            actual.Length.ShouldBe(expected.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                actual[i].ShouldBe(expected[i]);
            }
        }

        [Test]
        public async Task Given_EmptyArray_When_GetPositionsCalled_Then_ReturnsEmptyArray()
        {
            // Arrange
            var urls = Array.Empty<string>();

            // Act
            var actual = await finder.GetPositions(urls, Url, cancellationToken);
            
            // Assert    
            actual.ShouldBeEmpty();
        }

        [Test]
        public async Task Given_StringsDontString_When_GetPositionsCalled_Then_ReturnsEmptyArray()
        {
            // Arrange
            var urls = new[]
            {
                "not it",
                "not it/other stuff",
                "not it > other stuff"
            };

            // Act
            var actual = await finder.GetPositions(urls, Url, cancellationToken);
            
            // Assert    
            actual.ShouldBeEmpty();  
        }
    }
}