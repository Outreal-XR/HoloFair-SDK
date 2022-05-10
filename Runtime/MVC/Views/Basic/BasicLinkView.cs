namespace outrealxr.holomod
{
    public class BasicLinkView : View
    {

        string url;

        public override void Apply()
        {
            url = ((LinkModel)model).value;
        }
    }
}