using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnTriggerHandler : MonoBehaviour
    {
        public string TargetTag = "LocalPlayer";
        public UnityEvent _OnTriggerEnter, _OnTriggerExit, _OnTriggerStay;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(TargetTag))
                _OnTriggerEnter.Invoke();
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag(TargetTag))
                _OnTriggerExit.Invoke();
        }

        private void OnTriggerStay(Collider other) {
            if (other.CompareTag(TargetTag))
                _OnTriggerStay.Invoke();
        }
    }
}