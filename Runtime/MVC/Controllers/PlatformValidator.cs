using UnityEngine;
using UnityEngine.Events;

namespace com.thedrhax14.sfsopenworldclient
{
    public class PlatformValidator : MonoBehaviour
    {
        public RuntimePlatform[] validPlatforms;
        [Tooltip("Please note, the platform validation happens before many SDK classes on Awake. The execution priority of this one is set to -20.")]
        public UnityEvent OnInvalid, OnValid;

        void Awake()
        {
            foreach (var platform in validPlatforms)
            {
                if(Application.platform == platform)
                {
                    OnValid.Invoke();
                    return;
                }
            }
            OnInvalid.Invoke();
        }
    }
}