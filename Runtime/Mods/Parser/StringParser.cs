namespace com.outrealxr.holomod
{
    public class StringParser : JavaScriptMessageParserT<string>
    {
        public StringParser(StringView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit(view.name, view.ViewId, "text", view.GetValue);
        }

        public override void Parse(string input)
        {
            view.Write(input);
        }
    }
}