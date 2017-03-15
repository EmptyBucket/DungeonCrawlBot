using System;
using HtmlAgilityPack;

namespace BehindTheNameGenerator.Parser
{
    public class BehindTheNameParser : IParser
    {
        public string Parse(string str)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(str);
            var element = htmlDocument.QuerySelector(".heavyhuge a");
            var name = element.InnerText.Trim();
            return name;
        }
    }
}