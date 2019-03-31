using AngleSharp.Dom.Html;

namespace ObserverPattern.Pars
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
