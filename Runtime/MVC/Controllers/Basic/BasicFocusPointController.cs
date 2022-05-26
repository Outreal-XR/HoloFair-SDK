using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class BasicFocusPointController : Controller
    {
        public override void Handle() {
            Debug.LogWarning("[BasicFocusPointController] You called Handle(), but it does not do anything.");
        }

        public abstract void SetNewFocusPoint(FocusPoint newFocusPoint);
        public abstract void ResetFocusToPlayer();
    }
}