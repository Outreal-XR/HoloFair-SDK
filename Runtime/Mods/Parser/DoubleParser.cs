namespace com.outrealxr.holomod
{
    public class DoubleParser : JavaScriptMessageParserT<double>
    {
        public DoubleParser(DoubleView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit(view.name, view.ViewId, "double");
        }

        public override void Parse(string input)
        {
            if(double.TryParse(input, out double result))
            {
                view.SetValue(result);
            }
            else
            {
                view.SetValue(0);
            }
        }
    }
}