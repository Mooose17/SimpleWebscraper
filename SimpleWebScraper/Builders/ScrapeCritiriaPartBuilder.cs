using System.Text.RegularExpressions;
using SimpleWebScraper.Data;

namespace SimpleWebScraper.Builders;

public class ScrapeCritiriaPartBuilder
{
    private string _regex;
    private RegexOptions _regexOptions;

    public ScrapeCritiriaPartBuilder()
    {
        setDefaults();
    }

    private void setDefaults()
    {
        _regex = String.Empty;
        _regexOptions = RegexOptions.None;
    }

    public ScrapeCritiriaPartBuilder WithRegex(string regex)
    {
        _regex = regex;
        return this;
    }

    public ScrapeCritiriaPartBuilder WithRegexOptions(RegexOptions regexOptions)
    {
        _regexOptions = regexOptions;
        return this;
    }

    public ScrapeCritiriaPart Build()
    {
        ScrapeCritiriaPart scrapeCritiriaPart = new ScrapeCritiriaPart();
        scrapeCritiriaPart.Regex = _regex;
        scrapeCritiriaPart.RegexOptions = _regexOptions;
        return scrapeCritiriaPart;
    }
    
}
