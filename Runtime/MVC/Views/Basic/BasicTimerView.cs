using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicTimerView : BasicStringView
    {
        public override void Apply() {
            Debug.LogWarning($"[BasicTimerView] Value updated in {gameObject.name}, but no Apply logic is provided.");
        }
    }
}