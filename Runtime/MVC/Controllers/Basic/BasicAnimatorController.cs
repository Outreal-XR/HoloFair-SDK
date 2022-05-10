using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicAnimatorController : Controller
    {
        public override void Handle()
        {
            Debug.Log("[BasicAnimatorController] Doesn't have any handle logic. Please, use BasicAnimatorView.SetStateName(string) to trigger model update.");
        }
    }
}