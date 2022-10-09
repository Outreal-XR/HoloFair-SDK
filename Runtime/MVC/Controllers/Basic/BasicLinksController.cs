using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinksController : BasicStringController
    {

        public override void Handle()
        {
            LinkModel linkModel = (LinkModel)stringModel;
            if (linkModel.analytics) linkModel.analytics.RecordImmediateWithCustomResource(stringModel.value);
            Application.OpenURL(stringModel.value);
        }

        public virtual void OpenLinkInCurrentTab()
        {
#if UNITY_WEBGL
            Debug.Log("[BasicLinksController] No override for WebGL is added");
#else
        Handle();
#endif
        }
    }
}