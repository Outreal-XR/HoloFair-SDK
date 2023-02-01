namespace com.outrealxr.holomod
{
    public class UTCTimerParser : JavaScriptMessageParserT<string>
    {
        public UTCTimerParser(TimerView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit(view.name, view.ViewId, "utcTimer", view.GetValue);
        }

        public override void Parse(string input)
        {
            view.Write(input);
        }
    }
}