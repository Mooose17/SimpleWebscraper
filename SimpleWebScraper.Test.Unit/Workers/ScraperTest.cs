using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper.Test.Unit.Workers;

public class ScraperTest
{
    private readonly Scraper _scraper = new Scraper();

    [Test]
    public void FindCollectionWithNoparts()
    {
        var content = "egg <a href=\"http://domain.com\" data-id\"someId\" class=\"result-title hdrlnk\"> some text <\a> egg";
        ScrapeCritiria scrapeCritiria = new ScrapeCritiriaBuilder()
            .WithData(content)
            .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=""result-title hdrlnk\"">(.*?)<\a>")
            .WithRegexOptions(RegexOptions.ExplicitCapture)
            .Build();

        var foundElements = _scraper.Scrape(scrapeCritiria);
        
        Assert.IsTrue(foundElements.Count == 1);
        Assert.IsTrue(foundElements[0] == "<a href=\"http://domain.com\" data-id\"someId\" class=\"result-title hdrlnk\"> some text <\a>" );



    }
}