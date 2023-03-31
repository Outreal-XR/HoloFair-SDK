using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public static class AvatarOperationFactory
    {
        private const string RpmAnimationAvatarPath = "Avatars/MasculineAnimationAvatar";
        private const string RpmAnimatorControllerPath = "Avatars/AvatarMale";

        private static UnityEngine.Avatar _rpmAvatar;
        private static RuntimeAnimatorController _rpmAnimatorController;

        
        public static async Task<AvatarLoadingOperation> GetOperation(AvatarOwner owner) {
            if (_rpmAvatar == null)
                _rpmAvatar = await Resources.LoadAsync<UnityEngine.Avatar>(RpmAnimationAvatarPath) as UnityEngine.Avatar;
            if (_rpmAnimatorController == null)
                _rpmAnimatorController = await Resources.LoadAsync<RuntimeAnimatorController>(RpmAnimatorControllerPath) as RuntimeAnimatorController;

            if (_rpmAvatar == null || _rpmAnimatorController == null) 
                Debug.LogError("[AvatarsQueue] Could not load resources for " +
                               (_rpmAvatar == null ? "AnimationAvatar" : "") +
                               (_rpmAnimatorController == null ? ", RuntimeAnimatorController" : ""));

            AvatarLoadingOperation operation = owner.Src.EndsWith("glb") || owner.Src.EndsWith("gltf")
                ? new RPMAvatarOperation(owner, _rpmAvatar, _rpmAnimatorController)
                : new AddressableAvatarOperation(owner);

            return operation;
        }
    }
}
