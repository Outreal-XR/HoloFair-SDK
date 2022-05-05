using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnCollisionHandler : MonoBehaviour
    {
        public string TargetTag;
        public UnityEvent _OnCollisionEnter, _OnCollisionExit;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(TargetTag))
                _OnCollisionEnter.Invoke();
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag(TargetTag))
                _OnCollisionExit.Invoke();
        }
    }
}