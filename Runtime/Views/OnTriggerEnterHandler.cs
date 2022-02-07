using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnTriggerEnterHandler : ViewHandler
    {

        public string TargetTag;
        public UnityEvent _OnTriggerEnter;

        public override void Handle()
        {
            view.controller.Handle();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TargetTag))
            {
                Handle();
                _OnTriggerEnter.Invoke();// This may backfire if it is used to disable collider
            }
        }
    }
}