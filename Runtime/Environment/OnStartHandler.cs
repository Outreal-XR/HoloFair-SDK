using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnStartHandler : MonoBehaviour
    {

        public UnityEvent OnStart;
        bool eventRaised;

        private void Start()
        {
            if (!eventRaised)
            {
                OnStart.Invoke();
                eventRaised = true;
            }
        }
    }
}