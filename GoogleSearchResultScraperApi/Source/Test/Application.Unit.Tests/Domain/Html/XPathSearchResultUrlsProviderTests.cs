using System.Threading;
using System.Threading.Tasks;
using GoogleSearchResultScraperApi.Application.Domain.Html;
using GoogleSearchResultScraperApi.Application.Unit.Tests.Resources;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Application.Unit.Tests.Domain.Html
{
    [TestFixture]
    public class XPathSearchResultUrlsProviderTests
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private ISearchResultUrlsProvider provider = null!;

        [SetUp]
        public void SetUp()
        {
            var config = new SearchConfiguration{XPathPattern = "//div[@class='BNeawe UPmit AP7Wnd']"};
            var options = Substitute.For<IOptionsMonitor<SearchConfiguration>>();
            options.CurrentValue.Returns(config);
            provider = new XPathSearchResultUrlsProvider(options);
        }

        [Test]
        public async Task Given_ExampleHtml_When_GetUrlsCalled_Then_ReturnsSearchUrls()
        {
            // Arrange
            var page = PageProvider.GetPage();
            
            // Act    
            var urls = await provider.GetUrls(page, cancellationToken);

            // Assert    
            urls.Length.ShouldBe(100);
        }

        [Test]
        public async Task Given_BadExampleHtml_When_GetUrlsCalled_Then_ReturnsSearchUrls()
        {
            // Arrange
            var page = PageProvider.GetBadPage();
            
            // Act    
            var urls = await provider.GetUrls(page, cancellationToken);

            // Assert    
            urls.Length.ShouldBe(0);
        }
    }
}