using System.IO;

namespace GoogleSearchResultScraperApi.Application.Unit.Tests.Resources
{
    public static class PageProvider
    {
        public static string GetPage() => 
            File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(), 
                    "Resources",
                    "Example.html"));
        
        public static string GetBadPage() => 
            File.ReadAllText(
                Path.Combine(
                    Directory.GetCurrentDirectory(), 
                    "Resources",
                    "BadExample.html"));
    }
}