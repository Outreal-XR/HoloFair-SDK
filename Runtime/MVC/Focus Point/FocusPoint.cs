using UnityEngine;

namespace outrealxr.holomod {
    public class FocusPoint : MonoBehaviour {

        public bool isMain;
        public static FocusPoint main;
        public FocusPointSettings focusPointSettings;

        void Awake() {
            if(isMain && main == null) main = this;
        }

    }
}