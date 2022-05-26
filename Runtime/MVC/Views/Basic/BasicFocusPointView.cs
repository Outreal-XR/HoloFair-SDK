using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicFocusPointView : View
    {
        public override void Apply() {
            Debug.LogWarning("[BasicFocusPointView] Value updated in model, but no Apply logic is provided.");
        }

        public override void Edit() {
            Debug.LogWarning("[BasicFocusPointView] This mod object has no edit functionality.");
        }

        public void SetAsFocusPoint() {
            
        }

    }
}