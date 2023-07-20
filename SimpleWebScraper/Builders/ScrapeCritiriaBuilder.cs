using System.Text.Json;
using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Builders;

public class ScrapeCritiriaBuilder
{
    private string _data;
    private string _regex;
    private RegexOptions _regexOption;
    private List<ScrapeCritiriaPart> _parts;

    public ScrapeCritiriaBuilder()
    {
        SetDefaults();
    }

    private void SetDefaults()
    {
        _data = String.Empty;
        _regex = String.Empty;
        _regexOption = RegexOptions.None;
        _parts = new List<ScrapeCritiriaPart>();
    }

    public ScrapeCritiriaBuilder WithData(String data)
    {
        _data = data;
        return this;
    }
    public ScrapeCritiriaBuilder WithRegex(String regex)
    {
        _regex = regex;
        return this;
    }
    public ScrapeCritiriaBuilder WithRegexOptions(RegexOptions regexOptions)
    {
        _regexOption = regexOptions;
        return this;
    }
    public ScrapeCritiriaBuilder WithPart(ScrapeCritiriaPart scrapeCritiriaPart)
    {
        _parts.Add(scrapeCritiriaPart);
        return this;
    }

    public ScrapeCritiria Build()
    {
        ScrapeCritiria scrapeCritiria = new ScrapeCritiria();
        scrapeCritiria.Data = _data;
        scrapeCritiria.Regex = _regex;
        scrapeCritiria.RegexOptions = _regexOption;
        scrapeCritiria.Parts = _parts;

        return scrapeCritiria;
    }
    
}
