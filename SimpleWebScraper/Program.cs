using System.Net;
using System.Text.RegularExpressions;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;

namespace SimpleWebScraper
{
    class Program
    {

        private const string Method = "search";

        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter Which City You Would Like To Scrape:");
                var craigslistCity = Console.ReadLine() ?? string.Empty;
                var usableCraigslistCity = craigslistCity.Replace(" ", string.Empty);

                Console.WriteLine("Please Enter The Craigslist Category You Would Like To Scrape:");
                var craigslistCategoryName = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content =
                        client.DownloadString(
                            $"http://{usableCraigslistCity}.craigslist.org/{Method}/{craigslistCategoryName}");

                    ScrapeCritiria scrapeCriteria = new ScrapeCritiriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=""result-title hdrlnk\"">(.*?)<\a>")
                        .WithRegexOptions(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCritiriaPartBuilder()
                            .WithRegex(@">(.*?)<\a>")
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeCritiriaPartBuilder()
                            .WithRegex(@"href=\""(.*?)\""")
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var element in scrapedElements)
                        {
                            Console.WriteLine(element);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches for the specified scrape criteria.");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}