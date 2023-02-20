using UnityEngine;

namespace com.outrealxr.holomod
{
    public class DeviceOrientationListener : MonoBehaviour
    {
        public DeviceOrientation expectedDeviceOrientation;
        DeviceOrientation lastDeviceOrientation = DeviceOrientation.Unknown;
        public UnityEngine.Events.UnityEvent OnValid, OnInvalid;

        private void FixedUpdate()
        {
            if (lastDeviceOrientation != Input.deviceOrientation)
            {
                lastDeviceOrientation = Input.deviceOrientation;
                if (lastDeviceOrientation == expectedDeviceOrientation) OnValid.Invoke();
                else OnInvalid.Invoke();
            }
        }
    }
}