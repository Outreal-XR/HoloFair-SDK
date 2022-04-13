
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnStartHandler : ViewHandler
    {

        public UnityEvent OnStart;

        public override void Handle()
        {
            if(view && view.controller) view.controller.Handle();
            OnStart.Invoke();
        }
    }
}