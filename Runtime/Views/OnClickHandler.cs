
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnClickHandler : ViewHandler
    {

        public UnityEvent OnClick;

        public override void Handle()
        {
            OnClick.Invoke();
        }
    }
}