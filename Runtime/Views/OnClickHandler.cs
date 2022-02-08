
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class OnClickHandler : ViewHandler
    {

        public UnityEvent OnEnter, OnDown, OnUp, OnExit, OnClick;

        public override void Handle()
        {
            OnClick.Invoke();
        }
    }
}