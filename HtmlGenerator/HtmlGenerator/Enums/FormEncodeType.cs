using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum FormEncodeType
    {

        [HtmlEnumValue(Value = "")]
        Default,
        [HtmlEnumValue(Value = "application/x-www-form-urlencoded")]
        ApplicationFormEncoded,
        [HtmlEnumValue(Value = "multipart/form-data")]
        MultipartFormData,
        [HtmlEnumValue(Value = "text/plain")]
        TextPlain
    }
}
