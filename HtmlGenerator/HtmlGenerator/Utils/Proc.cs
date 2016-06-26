namespace HtmlGenerator.Utils
{
    public delegate void Proc<in T>(T pArgument);
    public delegate void Proc<in T, in T2>(T pArgument, T2 pArgument2);
    public delegate void Proc<in T, in T2, in T3>(T pArgument, T2 pArgument2, T3 pArgument3);
}
