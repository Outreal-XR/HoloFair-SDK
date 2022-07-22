using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicTimerView : BasicStringView
    {
        public override void Apply() {
            (model as TimerModel).UpdateTheTimeUTC();
        }
    }
}