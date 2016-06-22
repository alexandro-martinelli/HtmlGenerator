using HtmlGenerator.Enums;

namespace HtmlGenerator.Commons
{
    public class FormOptions
    {
        public string Forms { get; set; }
        public string Action { get; set; }
        public FormEncodeType EncodeType { get; set; }
        public FormMethod Method { get; set; }
        public bool FormNoValidade { get; set; }
        public Target Target { get; set; }

    }
}
