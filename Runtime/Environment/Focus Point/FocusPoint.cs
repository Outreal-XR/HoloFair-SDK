using UnityEngine;

namespace outrealxr.holomod {
    public class FocusPoint : MonoBehaviour {

        public bool isMain;
        public FocusPointSettings focusPointSettings;
        [SerializeField]
        private float _yawLimit = 45f;
        [SerializeField]
        private float _pitchLimit = 45;
        public float YawLimit { get { return _yawLimit; } }
        public float PitchLimit { get { return _pitchLimit; } }

    }
}