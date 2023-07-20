using System.Text.RegularExpressions;

namespace SimpleWebScraper.Data;

public class ScrapeCritiria
{
    public ScrapeCritiria()
    {
        Parts = new List<ScrapeCritiriaPart>();
    }
    public string Data { get; set; }
    public string Regex { get; set; }
    public RegexOptions RegexOptions { get; set; }
    public List<ScrapeCritiriaPart> Parts { get; set; }
}