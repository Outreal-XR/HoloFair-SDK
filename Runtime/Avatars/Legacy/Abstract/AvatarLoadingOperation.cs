using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public abstract class AvatarLoadingOperation : MonoBehaviour
    {
        public float Percent { get; protected set; }
        
        public bool running;
        public abstract void Handle(AvatarModel model);
    }
}