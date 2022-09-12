using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public abstract class SmartStringSource : MonoBehaviour
    {
        public static SmartStringSource Instance;

        private void Awake()
        {
            Instance = this;
        }

        public abstract string GetFormattedString(string format, string guid);
    }
}
