using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum InputType
    {
        Hidden,
        Button,
        CheckBox,
        Color,
        Date,
        DateTime,
        [HtmlEnumValue(Value = "datetime-local")]
        DateTimeLocal,
        Email,
        File,
        Image,
        Month,
        Number,
        Password,
        Radio,
        Range,
        Reset,
        Search,
        Submit,
        Tel,
        Text,
        Time,
        Url,
        Week
    }
}
