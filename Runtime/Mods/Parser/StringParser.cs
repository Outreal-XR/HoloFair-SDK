namespace com.outrealxr.holomod
{
    public class StringParser : JavaScriptMessageParserT<string>
    {
        public StringParser(StringView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit("text");
        }

        public override void Parse(string input)
        {
            view.SetValue(input);
        }
    }
}