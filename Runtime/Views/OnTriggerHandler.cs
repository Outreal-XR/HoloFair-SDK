using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnTriggerHandler : ViewHandler
    {

        public string TargetTag;
        public UnityEvent _OnTriggerEnter, _OnTriggerExit;

        public override void Handle()
        {
            view.controller.Handle();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TargetTag))
                _OnTriggerEnter.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TargetTag))
                _OnTriggerExit.Invoke();
        }
    }
}