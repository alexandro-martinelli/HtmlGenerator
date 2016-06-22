using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Tags;
using HtmlGenerator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlGeneratorTest
{
    [TestClass]
    public class HtmlMakerTest
    {
        [TestMethod]
        public void TestMakeButtonTag()
        {
            Button lButton = HtmlMaker.MakeTag<Button>(pButton => {
                pButton.Class = "btn btn-Info";
                pButton.Disabled = true;
                pButton.AutoComplete = Usage.True;
                pButton.Id = "button1";
                pButton.Text = "Cancelar";
            });
            Assert.AreEqual("btn btn-Info", lButton.Class);
            Assert.AreEqual(true, lButton.Disabled);
            Assert.AreEqual(Usage.True, lButton.AutoComplete);
            Assert.AreEqual("button1", lButton.Id);
            Assert.AreEqual("Cancelar", lButton.Text);
            Assert.AreEqual(ButtonType.Button, lButton.Type);
        }

        [TestMethod]
        public void TestMakeDivTag()
        {
            Div lDiv = HtmlMaker.MakeTag<Div>(pDiv => {
                pDiv.Class = "pagination";
                pDiv.Disabled = true;
                pDiv.Id = "div1";
                pDiv.Items.AddItem<Span>(pSpan =>
                {
                    pSpan.Class = "btn btn-xs btn-danger";
                });
            });
            Assert.AreEqual(lDiv.Class, "pagination");
            Assert.AreEqual(lDiv.Disabled, true);
            Assert.AreEqual(lDiv.AutoComplete, Usage.Default);
            Assert.AreEqual(lDiv.Id, "div1");
            Assert.AreEqual(1, lDiv.Items.Count);
            HtmlTag lItem = lDiv.Items[0];
            Assert.AreEqual(true, lItem is Span);
            Assert.AreEqual("btn btn-xs btn-danger", lItem.Class);

        }


    }
}
