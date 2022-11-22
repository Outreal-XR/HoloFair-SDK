using UnityEngine;

namespace outrealxr.holomod {
[CreateAssetMenu(fileName = "New FocusPointSettings", menuName = "MMOControls/Create Focus Point Settings", order = 1)]
    public class FocusPointSettings : ScriptableObject {

        public float minSnapDistance = 0.05f,
        resetDistnace = 4,
        maxDistance = 10f,
        inputAccelaration = 10,
        desktopZoomSensitivity = 0.5f,
        mobileZoomSensitivity = 0.15f,
        defaultXAngle = 15,
        lookHeight = 0,
        focusRadius = 5f,
        focusCentering = 5f,
        rotationSpeed = 90f,
        minVerticalAngle = -45f,
        maxVerticalAngle = 45f,
        alignDelay = 5,
        alignSmoothRange = 45,
        desktopSensitivity = 1f,
        mobileSensitivity = 1f;

        public bool isLocalCoordinates, applyXValue = true;
    }
}