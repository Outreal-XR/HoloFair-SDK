using com.outrealxr.avatars.revised;
using UnityEngine;

namespace com.outrealxr.avatars
{
    public abstract class AvatarLoadingOperation : MonoBehaviour
    {
        public float Percent { get; protected set; }
        public bool IsRunning { get; protected set; } = false;

        public abstract void Handle(AvatarModel model);
        public abstract void Stop();
    }
}