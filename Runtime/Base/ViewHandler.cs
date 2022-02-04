using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class ViewHandler : MonoBehaviour
    {
        public View view;

        public abstract void Handle();
    }
}