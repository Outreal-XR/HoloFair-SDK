namespace com.outrealxr.holomod
{
    public class UTCTimerParser : JavaScriptMessageParserT<string>
    {
        public UTCTimerParser(TimerView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit("utcTimer");
        }

        public override void Parse(string input)
        {
            view.SetValue(input);
        }
    }
}