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
    }
}