using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace com.outrealxr.avatars.revised
{
    public class AddressableAvatarOperation : AvatarLoadingOperation
    {
        public AddressableAvatarOperation(AvatarOwner owner) {
            Owner = owner;
        }
        
        public override void Handle() {
            Download();
        }

        private async void Download() {
            try {
                var locationsHandle = Addressables.LoadResourceLocationsAsync(Owner.Src);
                await locationsHandle;

                if (locationsHandle.Result.Count > 0) {
                    var handle = Addressables.InstantiateAsync(Owner.Src);
                    await handle;
                    Debug.Log($"[AddressableAvatarOperation] Loaded {Owner.Src}");
                    Owner.SetAvatar(handle.Result);
                }
                else {
                    Debug.Log($"[AddressableAvatarOperation] Failed to load {Owner.Src}");
                    Owner.SetAvatar(null);
                }
            }
            finally {
                InvokeOnOperationCompleted();
            }
        }
    }
}