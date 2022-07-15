using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicUserGroupView : BasicStringView
    {
        public override void Apply() {
            Debug.LogWarning($"[BasicUserGroupView] Value updated in {gameObject.name}, but no Apply logic is provided.");
        }
    }
}