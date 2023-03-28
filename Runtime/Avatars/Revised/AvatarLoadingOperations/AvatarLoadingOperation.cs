using System;
using com.outrealxr.avatars.revised;

namespace com.outrealxr.avatars
{
    public abstract class AvatarLoadingOperation
    {
        public abstract void Handle(AvatarOwner owner);
        public abstract void Stop();
        
        public event Action OnOperationCompleted;
        protected void InvokeOnOperationCompleted() => OnOperationCompleted?.Invoke();
    }
}