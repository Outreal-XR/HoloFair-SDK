namespace com.outrealxr.holomod
{
    public abstract class DoubleView : ViewT<double>
    {
        public override void Edit() {
            JavaScriptMessageReciever.instance.StartEdit(new DoubleParser(this));
        }
    }
}