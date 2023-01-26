namespace com.outrealxr.holomod
{
    public abstract class StringView : ViewT<string>
    {
        public override void Edit() {
            JavaScriptMessageReciever.instance.StartEdit(new StringParser(this));
        }
    }
}