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

            LabelStringGenerator lGenerator = new LabelStringGenerator();
            Label lLabel = new Label();
            lLabel.Name = "lblNome";
            lLabel.Id = "lblNome";
            lLabel.Text = "Nome";
            lLabel.For = "Nome";
            string lHtml = lGenerator.ToHtmlString(lLabel);
            Assert.AreEqual<string>("<label  id=\"lblNome\" name=\"lblNome\" for=\"Nome\">Nome</label>", lHtml);
        }
    }

}
