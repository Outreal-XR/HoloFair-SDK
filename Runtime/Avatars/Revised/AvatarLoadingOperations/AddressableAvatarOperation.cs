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

        public override void Handle(AvatarModel model) {
            IsRunning = true;
            StartCoroutine(Download(model));
        }

        public override void Stop() {
            //TODO implement. Not touched since 22/03/2023.
            throw new NotImplementedException();
        }

        private void Update() { 
            if (IsRunning)
                Percent = _downloadStatus.Percent;
        }

        private IEnumerator Download(AvatarModel model) {
            var locationsHandle = Addressables.LoadResourceLocationsAsync(model.src);
            yield return locationsHandle;
            
            if (locationsHandle.Result.Count > 0) {
                var handle = Addressables.InstantiateAsync(model.src);
                _downloadStatus = handle.GetDownloadStatus();
                yield return handle;
                Debug.Log($"[AddressableAvatarOperation] Loaded {model.src}");
                model.SetAvatar(handle.Result);
            } else {
                Debug.Log($"[AddressableAvatarOperation] Failed to load {model.src}");
                model.SetAvatar(null);
            }
            IsRunning = false;
        }
    }
}