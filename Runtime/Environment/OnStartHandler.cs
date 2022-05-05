using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnStartHandler : MonoBehaviour
    {

        public UnityEvent OnStart;

        public void WorldStart()
        {
            OnStart.Invoke();
        }
    }
}