using UnityEngine;

namespace com.outrealxr.zonetalks.Runtime
{
    public class ControlLocker : MonoBehaviour
    {
        private void OnEnable() => ControlsLockManager.Instance?.AddLock(this);
        private void OnDisable() => ControlsLockManager.Instance?.RemoveLock(this);
    }
}



