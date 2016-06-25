using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Tags;

namespace HtmlGenerator.StringGenerator

{
    public class HyperLinkStringGenerator : HtmlTextContainerStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            HyperLink lLink = (HyperLink) pHtmlTag;
            string lHtml = ConcatAttributeWithValue("download", lLink.DownloadFileName);
            lHtml += ConcatAttributeWithValue("href", lLink.Url);
            lHtml += ConcatAttributeWithValue("hreflang", lLink.UrlLanguage);
            lHtml += ConcatAttributeWithValue("media", lLink.Media);
            lHtml += ConcatAttributeWithValue("rel", RelationshipToString(lLink.Relationship));
            lHtml += ConcatAttributeWithValue("target", TargetToString(lLink.Target));
            lHtml += ConcatAttributeWithValue("type", lLink.Type);
            return lHtml;
        }

        private string RelationshipToString(Relationship pRelationship)
        {
            switch (pRelationship)
            {
                case Relationship.Alternate:
                    return "alternate";
                case Relationship.Author:
                    return "author";
                case Relationship.Bookmark:
                    return "bookmark";
                case Relationship.Help:
                    return "help";
                case Relationship.License:
                    return "license";
                case Relationship.Next:
                    return "next";
                case Relationship.NoFollow:
                    return "nofollow";
                case Relationship.NoReferrer:
                    return "noreferrer";
                case Relationship.Prefetch:
                    return "prefetch";
                case Relationship.Prev:
                    return "prev";
                case Relationship.Search:
                    return "search";
                case Relationship.Tag:
                    return "tag";
            }
            return "";

        }

        protected override string GetHtmlTagName()
        {
            return "a";
        }
    }
}
