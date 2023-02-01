namespace com.outrealxr.holomod
{
    public class DoubleParser : JavaScriptMessageParserT<double>
    {
        public DoubleParser(DoubleView view) : base(view) { }

        public override void OpenView()
        {
            OpenEdit(view.name, view.ViewId, "double", view.GetValue + "");
        }

        public override void Parse(string input)
        {
            if(double.TryParse(input, out double result))
            {
                view.Write(result);
            }
            else
            {
                view.Write(0);
            }
        }
    }
}