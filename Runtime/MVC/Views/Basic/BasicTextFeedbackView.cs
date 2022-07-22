using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicTextFeedbackView : BasicStringView
    {
        public override void Apply()
        {
            Debug.LogWarning("[BasicTextFeedbackView] Value was updated, but not Apply logic is provided for this view");
        }
    }
}