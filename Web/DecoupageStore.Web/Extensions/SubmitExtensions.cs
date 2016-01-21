namespace DecoupageStore.Web.Extensions
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class SubmitExtensions
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, string displayText, object htmlAttributes = null)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("value", displayText);

            var attributes = (IDictionary<string, string>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            input.MergeAttributes(attributes);

            return new MvcHtmlString(input.ToString());
        }
    }
}