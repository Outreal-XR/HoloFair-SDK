using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicLinkView : BasicStringView
    {
        public override void Apply()
        {
            Debug.LogWarning($"[BasicLinkView] Value updated in {gameObject.name}, but no Apply logic is provided.");
        }

        public void OpenLinkInCurrentTab()
        {
            (controller as BasicLinksController).OpenLinkInCurrentTab();
        }
    }
}