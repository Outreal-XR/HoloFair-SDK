using UnityEngine;

namespace outrealxr.holomod {
    public class FocusPoint : MonoBehaviour {

        public FocusPointSettings focusPointSettings;
        [SerializeField]
        private float _yawLimit = 45f;
        [SerializeField]
        private float _pitchLimit = 45;
        public float YawLimit { get { return _yawLimit; } }
        public float PitchLimit { get { return _pitchLimit; } }

        public static FocusPoint main;

        void Awake()
        {
            if (IsMain()) main = this;
        }

        public void Activate()
        {
            Debug.LogError("[FocusPoint] Activate is not done");
        }

        public void ActivateMain()
        {
            if (main) main.Activate();
            else Debug.LogError("[FocusPoint] main focus point is not assigned");
        }

        public virtual bool IsMain()
        {
            return false;
        }

    }
}