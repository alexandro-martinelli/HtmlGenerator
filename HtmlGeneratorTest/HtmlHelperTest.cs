using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlGenerator.Utils;

namespace HtmlGeneratorTest
{
    [TestClass]
    public class HtmlHelperTest
    {
        [TestMethod]
        public void TestAnonymousObjectToHtmlAttribute()
        {
            string lHtml = HtmlHelper.AnonymousObjectToHtmlAttribute(new { @class = "btn btn-info" });
            Assert.AreEqual<string>(lHtml, " class=\"btn btn-info\"");
        }

        [TestMethod]
        public void TestNullAnonymousObjectToHtmlAttribute()
        {
            string lHtml = HtmlHelper.AnonymousObjectToHtmlAttribute(null);
            Assert.AreEqual<string>(lHtml, "");
        }
    }
}
