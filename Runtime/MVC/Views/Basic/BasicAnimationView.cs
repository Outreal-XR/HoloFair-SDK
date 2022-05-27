using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicAnimationView : View
    {
        public override void Apply()
        {
            Debug.LogWarning("[BasicAnimationView] Value updated in model, but no Apply logic is provided.");
        }

        public override void Edit()
        {
            Debug.LogWarning("[BasicAnimationView] No edit logic is provided.");
        }
    }
}