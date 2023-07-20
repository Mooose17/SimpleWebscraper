using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Workers;

public class Scraper
{
    public List<string> Scrape(ScrapeCritiria scrapeCritiria)
    {
        List<string> scrapedElements = new List<string>();

        MatchCollection matches = Regex.Matches(scrapeCritiria.Data, scrapeCritiria.Regex, scrapeCritiria.RegexOptions);

        foreach (Match match in matches)
        {
            if (!scrapeCritiria.Parts.Any())
            {
                scrapedElements.Add(match.Groups[0].Value);
            }
            else
            {
                foreach (var part in scrapeCritiria.Parts)
                {
                    Match matchedPart = Regex.Match(match.Groups[0].Value,part.Regex, part.RegexOptions);
                    if (matchedPart.Success)
                    {
                        scrapedElements.Add(matchedPart.Groups[1].Value);
                    }
                }
            }
        }
        return scrapedElements;
    }
}