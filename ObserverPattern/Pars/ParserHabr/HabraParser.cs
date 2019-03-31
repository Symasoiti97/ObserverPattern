using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace ObserverPattern.Pars.ParsSite
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            return document.QuerySelectorAll("a")
                .Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"))
                .Select(item => item.TextContent).ToArray();
        }
    }
}
