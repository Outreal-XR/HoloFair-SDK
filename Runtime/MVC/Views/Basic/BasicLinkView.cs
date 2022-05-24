namespace outrealxr.holomod
{
    public class BasicLinkView : View
    {

        string url;

        public override void Apply()
        {
            url = ((LinkModel)model).value;
        }

        public void RequestToUpdateLink() {
#if UNITY_WEBGL
            LinkUpdaterJSCommunicator.Instance.OpenInputFieldOnBrowser(this);
#endif
        }

        public void ReceiveLinkUpdate(string newUrl) {
            ((LinkModel) model).value = newUrl;
            Apply();
        }
    }
}