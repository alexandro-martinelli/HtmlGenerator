using HtmlGenerator.Tags;

namespace HtmlGenerator.StringGenerator
{
    public abstract class CheckInputStringGenerator : InputStringGenerator
    {
        protected override sealed string DoConvertSelfAttributes(Input pInput)
        {
            CheckInput lCheck = (CheckInput)pInput;
            if (lCheck.Checked) {
                return ConcatOnlyAttribute("checked");
            }
            return "";
        }
    }



}
