using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BasicStringView : View
    {
        [Tooltip("Assigned automatically on start after world init. Not used in BasicVideoView")]
        BasicStringController basicStringController;

        private void Start()
        {
            basicStringController = (BasicLinksController)controller;
            if (basicStringController == null) Debug.LogWarning($"[BasicLinkView] There is no controller for {gameObject.name}");
            else basicStringController.SetModel(model);
        }

        public void RequestToUpdateLink()
        {
            LinkUpdaterJSCommunicator.instance.OpenInputFieldOnBrowser();
        }

        public void ReceiveLinkUpdate(string newUrl)
        {
            basicStringController.SetValue(newUrl);
        }

        public override void Edit()
        {
            EditStringView.instance.StartEdit(this);
        }
    }
}