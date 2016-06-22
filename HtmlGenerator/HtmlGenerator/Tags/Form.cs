using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Utils;

namespace HtmlGenerator.Tags
{

    public class Form : HtmlContainer
    {
        public string AcceptCharset { get; set; }
        public string Action { get; set; }
        public FormEncodeType EncodeType { get; set; }
        public FormMethod Method { get; set; }
        public bool NoValidade { get; set; }
        public Target Target { get; set; }

        public static Form MakeForm(Proc<Form> pMaker)
        {
            Form lForm = new Form();
            pMaker(lForm);
            return lForm;
        }
    }
}
