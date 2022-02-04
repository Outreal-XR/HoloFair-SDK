using UnityEngine;

namespace outrealxr.holomod
{
    public class OnTriggerEnterHandler : ViewHandler
    {

        public string TargetTag;

        public override void Handle()
        {
            view.controller.Handle();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TargetTag)) Handle();
        }
    }
}