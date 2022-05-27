using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinkView : View
    {
        public BasicLinksController basicLinksController;

        private void Start()
        {
            basicLinksController = (BasicLinksController)controller;
            if(basicLinksController == null) Debug.LogWarning($"[BasicLinkView] There is no controller for {gameObject.name}");
            else basicLinksController.SetModel(model);
        }

        public override void Apply()
        {
            Debug.LogWarning($"[BasicLinkView] Value updated in {gameObject.name}, but no Apply logic is provided.");
        }

        public void RequestToUpdateLink() {
            LinkUpdaterJSCommunicator.instance.OpenInputFieldOnBrowser();
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