using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnStartHandler : MonoBehaviour
    {

        public UnityEvent OnStart;
        bool eventRaised;

        public void WorldStart()
        {
            if (!eventRaised)
            {
                OnStart.Invoke();
                eventRaised = true;
            }
        }
    }
}