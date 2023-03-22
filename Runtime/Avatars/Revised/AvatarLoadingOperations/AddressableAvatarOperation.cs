using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace com.outrealxr.avatars.revised
{
    public class AddressableAvatarOperation : AvatarLoadingOperation
    {
        private DownloadStatus _downloadStatus;

        public override void Handle(AvatarModel model)
        {
            running = true;
            StartCoroutine(Download(model));
        }

        private void Update() { 
            Percent = _downloadStatus.Percent;
        }

        private IEnumerator Download(AvatarModel model) {
            AsyncOperationHandle<IList<IResourceLocation>> locationsHandle = Addressables.LoadResourceLocationsAsync(model.src);
            yield return locationsHandle;
            if (locationsHandle.Result.Count > 0)
            {
                var handle = Addressables.InstantiateAsync(model.src);
                _downloadStatus = handle.GetDownloadStatus();
                yield return handle;
                Debug.Log($"[AddressableAvatarOperation] Loaded {model.src}");
                model.SetAvatar(handle.Result);
            }
            else
            {
                Debug.Log($"[AddressableAvatarOperation] Failed to load {model.src}");
                model.SetAvatar(null);
            }
            running = false;
        }
    }
}