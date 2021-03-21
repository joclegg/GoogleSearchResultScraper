using System;
using System.Linq;
using AutoFixture;
using GoogleSearchResultScraperApi.Host.Adaptors.RestApi.V1;
using NUnit.Framework;
using Shouldly;

namespace GoogleSearchResultScraperApi.Host.Unit.Tests.Adaptors.RestApi.V1
{
    [TestFixture]
    public class ResultTranslatorTests
    {
        private readonly IFixture fixture = new Fixture();
        private IResultTranslator translator = null!;

        [SetUp]
        public void SetUp()
        {
            translator = new ResultTranslator();
        }

        [Test]
        public void Given_AnIntArray_When_TranslateCalled_Then_ReturnsConcatString()
        {
            // Arrange
            var input = fixture.CreateMany<int>().ToArray();
            var expected = string.Join(", ", input);
            
            // Act
            var actual = translator.Translate(input);
            
            // Assert    
            actual.ShouldBe(expected);
        }

        [Test]
        public void Given_AnEmptyArray_When_TranslateCalled_Then_ReturnsZero()
        {
            // Arrange
            var input = Array.Empty<int>();
            const string expected = "0";

            // Act    
            var actual = translator.Translate(input);
            
            // Assert
            actual.ShouldBe(expected);
        }
    }
}