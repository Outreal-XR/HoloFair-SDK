using System;
using com.outrealxr.avatars.revised;

namespace com.outrealxr.avatars
{
    public abstract class AvatarLoadingOperation
    {
        protected AvatarOwner Owner;
        
        public abstract void Handle();

        public event Action OnOperationCompleted;
        protected void InvokeOnOperationCompleted() => OnOperationCompleted?.Invoke();
    }
}