using com.outrealxr.avatars.revised;
using Cysharp.Threading.Tasks;

namespace com.outrealxr.avatars
{
    public abstract class AvatarLoadingOperation
    {
        protected AvatarOwner Owner;
        
        public abstract UniTask Operate();
    }
}