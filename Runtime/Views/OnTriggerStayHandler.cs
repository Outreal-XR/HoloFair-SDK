using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnTriggerStayHandler : MonoBehaviour
    {
        public string TargetTag;
        public UnityEvent _OnTriggerStay;

        private void OnTriggerStay(Collider other) {
            if (other.CompareTag(TargetTag))
                _OnTriggerStay.Invoke();
        }

    }
}