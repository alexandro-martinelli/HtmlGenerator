using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlGenerator.StringGenerator;
using HtmlGenerator.Tags;

namespace HtmlGeneratorTest
{
    [TestClass]
    public class LabelStringGeneratorTest
    {
        [TestMethod]
        public void TestToHtmlString()
        {

            HtmlTagStringGenerator lGenerator = new HtmlTagStringGenerator();
            Label lLabel = new Label();
            lLabel.Name = "lblNome";
            lLabel.Id = "lblNome";
            lLabel.Text = "Nome";
            lLabel.For = "Nome";
            string lHtml = lGenerator.ToHtmlString(lLabel);
            Assert.AreEqual<string>("<label  for=\"Nome\" id=\"lblNome\" name=\"lblNome\">Nome</label>", lHtml);
        }
    }

}
