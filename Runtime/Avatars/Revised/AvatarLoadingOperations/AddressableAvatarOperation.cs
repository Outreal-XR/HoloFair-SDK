using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.outrealxr.avatars.revised
{
    public class AddressableAvatarOperation : AvatarLoadingOperation
    {
        public override void Handle(AvatarOwner owner) {
            Download(owner);
        }

        public override void Stop() {
            //TODO implement. Not touched since 22/03/2023.
            throw new NotImplementedException();
        }
        
        private async void Download(AvatarOwner owner) {
            var locationsHandle = Addressables.LoadResourceLocationsAsync(owner.Src);
            await locationsHandle.Task;
            
            if (locationsHandle.Result.Count > 0) {
                var handle = Addressables.InstantiateAsync(owner.Src);
                await handle.Task;
                Debug.Log($"[AddressableAvatarOperation] Loaded {owner.Src}");
                owner.SetAvatar(handle.Result);
            } else {
                Debug.Log($"[AddressableAvatarOperation] Failed to load {owner.Src}");
                owner.SetAvatar(null);
            }

            InvokeOnOperationCompleted();
        }
    }
}