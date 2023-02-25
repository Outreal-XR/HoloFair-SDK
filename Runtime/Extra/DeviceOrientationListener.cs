using UnityEngine;

namespace com.outrealxr.holomod
{
    public class DeviceOrientationListener : MonoBehaviour
    {
        public DeviceOrientation[] expectedDeviceOrientations;
        DeviceOrientation lastDeviceOrientation = DeviceOrientation.Unknown;
        public UnityEngine.Events.UnityEvent OnValid, OnInvalid;

        private void FixedUpdate()
        {
            if (lastDeviceOrientation != Input.deviceOrientation)
            {
                lastDeviceOrientation = Input.deviceOrientation;
                if (expectedDeviceOrientations.Length > 0 && System.Array.IndexOf(expectedDeviceOrientations, lastDeviceOrientation) > -1) OnValid.Invoke();
                else OnInvalid.Invoke();
            }
        }
    }
}