using UnityEngine;

namespace com.outrealxr.holomod
{
    public class ControlLocker : MonoBehaviour
    {
        private void OnEnable() => ControlsLockManager.Instance?.AddLock(this);
        private void OnDisable() => ControlsLockManager.Instance?.RemoveLock(this);
    }
}



