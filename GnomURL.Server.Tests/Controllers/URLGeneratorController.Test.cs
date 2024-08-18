using Xunit;
using GnomURL.Server.Models;
using GnomURL.Server.Persistence;

namespace GnomURL.Server.Tests.Controllers
{
    public class URLGeneratorController
    {
        [Fact]
        public void GETURLfromShort()
        {
            var mockGURL = new GnomURLModel() { ShortURL = "GnomE", LongURL = "https://www.adroit-tt.com/" };
            
            InMemoryURLMap.Instance.AddGnomUrl(longURL: mockGURL.LongURL, suggestedShortURL: mockGURL.ShortURL); // Add URL

            // Call Twice to increment Count
            var result = InMemoryURLMap.Instance.GetURLFromShort(mockGURL.ShortURL);

            Assert.Equal("GnomE", result.ShortURL);
            Assert.Equal("https://www.adroit-tt.com/", result.LongURL);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void CreateShortURLFromEmptySuggestion()
        {
            string longURL = "https://www.google.com/";

            var resultShortURL = InMemoryURLMap.Instance.AddGnomUrl(longURL);

            var result = InMemoryURLMap.Instance.GetURLFromShort(resultShortURL);

            Assert.NotNull(result);
            Assert.Equal(longURL, result.LongURL);
            Assert.Equal(resultShortURL, result.ShortURL);
        }
        [Fact]
        public void CreateShortURLFromSuggestedString()
        {
            string shortURL = "m!cr0";
            string longURL = "https://www.microsoft.com/";

            var resultShortURL = InMemoryURLMap.Instance.AddGnomUrl(longURL, shortURL);

            var result = InMemoryURLMap.Instance.GetURLFromShort(resultShortURL);

            Assert.NotNull(result);
            Assert.Equal(longURL, result.LongURL);
            Assert.Equal(shortURL, resultShortURL);
            Assert.Equal(resultShortURL, result.ShortURL);
        }

        [Fact]
        public void DeleteURLfromShort()
        {
            string shortURL = "d3l3t3";
            string longURL = "https://www.deleteme.com";

            var resultShortURLAdded = InMemoryURLMap.Instance.AddGnomUrl(longURL: longURL, suggestedShortURL: shortURL);
            
            
            var result = InMemoryURLMap.Instance.GetURLFromShort(resultShortURLAdded);

            Assert.NotNull(result);

            InMemoryURLMap.Instance.DeleteShortURL(shortURL);
            var resultDeleted = InMemoryURLMap.Instance.GetURLFromShort(resultShortURLAdded);

            Assert.Null(resultDeleted);
        }

        [Fact]
        public void CountURLTimesClicked()
        {
            var mockGURL = new GnomURLModel() { ShortURL = "1nt", LongURL = "https://www.example.com/" };

            InMemoryURLMap.Instance.AddGnomUrl(longURL: mockGURL.LongURL, suggestedShortURL: mockGURL.ShortURL); // Add URL

            // Call Twice to increment Count
            var result1 = InMemoryURLMap.Instance.GetURLFromShort(mockGURL.ShortURL); // 1
            var result2 = InMemoryURLMap.Instance.GetURLFromShort(mockGURL.ShortURL); // 2
            var result3 = InMemoryURLMap.Instance.GetURLFromShort(shortUrl: mockGURL.ShortURL, dontCount: true); // 2

            Assert.Equal("1nt", result1.ShortURL);
            Assert.Equal("https://www.example.com/", result1.LongURL);

            Assert.Equal("1nt", result2.ShortURL);
            Assert.Equal("https://www.example.com/", result2.LongURL);
            
            Assert.Equal(2, result3.Count);
        }
    }
}
