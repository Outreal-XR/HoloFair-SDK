using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinkView : View
    {
        public BasicLinksController basicLinksController;

        private void Start()
        {
            basicLinksController = (BasicLinksController)controller;
            basicLinksController.SetModel(model);
        }

        public override void Apply()
        {
            Debug.LogWarning("[BasicLinkView] Value updated in model, but no Apply logic is provided.");
        }

        public void RequestToUpdateLink() {
#if UNITY_WEBGL
            LinkUpdaterJSCommunicator.Instance.OpenInputFieldOnBrowser(this);
#endif
        }

        public void ReceiveLinkUpdate(string newUrl) {
            basicLinksController.SetValue(newUrl);
        }

        public override void Edit()
        {
            EditLinkView.instance.StartEdit(this);
        }
    }
}