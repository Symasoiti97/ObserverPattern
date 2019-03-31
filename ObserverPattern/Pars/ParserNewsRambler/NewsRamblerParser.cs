using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace ObserverPattern.Pars.ParserNewsRambler
{
    class NewsRamblerParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            return document.QuerySelectorAll("link[rel='alternate']")
                .Select(el => el.GetAttribute("href")).ToArray();
        }
    }
}
