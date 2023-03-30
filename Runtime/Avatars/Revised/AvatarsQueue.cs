using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public static class AvatarsQueue
    {
        private static readonly Queue<AvatarOwner> Queue = new();

        private const string RpmAnimationAvatarPath = "";
        private const string RpmAnimatorControllerPath = "";

        private static UnityEngine.Avatar _rpmAvatar;
        private static RuntimeAnimatorController _rpmAnimatorController;
        
        
        public static void Enqueue(AvatarOwner owner)
        {
            Queue.Enqueue(owner);
            owner.SetQueued();

            if (Queue.Count == 1) {
                StartOperation();
            }
        }

        private static async void StartOperation() {
            if (Queue.Count == 0) return;

            if (_rpmAvatar == null)
                _rpmAvatar = await Resources.LoadAsync<UnityEngine.Avatar>(RpmAnimationAvatarPath) as UnityEngine.Avatar;
            if (_rpmAnimatorController == null)
                _rpmAnimatorController = await Resources.LoadAsync<RuntimeAnimatorController>(RpmAnimatorControllerPath) as RuntimeAnimatorController;

            if (_rpmAvatar == null || _rpmAnimatorController == null)
                Debug.LogError("[AvatarsQueue] Could not load resources for " + 
                               (_rpmAvatar == null ? "AnimationAvatar" : "") + 
                               (_rpmAnimatorController == null ? ", RuntimeAnimatorController" : ""));
            
            var owner = Queue.Dequeue();
            owner.SetDequeued();

            AvatarLoadingOperation operation = owner.Src.EndsWith("glb") || owner.Src.EndsWith("gltf")
                ? new RPMAvatarOperation(owner, null, null)
                : new AddressableAvatarOperation(owner);

            operation.OnOperationCompleted += StartOperation;
            
            if (owner.IsVisible) 
                operation.Handle();
        }
    }
}