using Cysharp.Threading.Tasks;
using GLTFast;
using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public class RPMAvatarOperation : AvatarLoadingOperation
    {
        public enum SupportedLOD
        {
            High = 0,
            Medium = 1,
            Low = 2
        }

        public enum SupportedResolutions
        {
            Low = 1,
            Medium = 2,
            High = 4,
            Highest = 8
        }

        public enum Atlas
        {
            LowRes = 1,
            MediumRes = 2,
            HighRes = 4
        }
        
        private const string GltfHolderName = "GLTF Holder";
        private const float Timeout = 60;

        private readonly RuntimeAnimatorController _runtimeAnimatorController;
        private readonly Avatar _animationAvatar;
        private readonly SupportedLOD _lod;
        private readonly SupportedResolutions _resolution;
        private readonly Atlas _atlasResolution; 

        public RPMAvatarOperation (AvatarOwner owner, Avatar animationAvatar, RuntimeAnimatorController runtimeAnimatorController, SupportedLOD lod = SupportedLOD.Low, SupportedResolutions resolution = SupportedResolutions.Low, Atlas atlasResolution = Atlas.LowRes) {
            Owner = owner;

            _animationAvatar = animationAvatar;
            _runtimeAnimatorController = runtimeAnimatorController;
            _lod = lod;
            _resolution = resolution;
            _atlasResolution = atlasResolution;
        }

        public override void Handle() {
            LoadAvatar();
        }

        private async void LoadAvatar() {
            try {
                var gltfHolder = new GameObject(GltfHolderName);
                var gltfAsset = gltfHolder.AddComponent<GltfAsset>();

                var src = $"{Owner.Src}?meshLoad={(int) _lod}&textureAtlas={(int) _atlasResolution * 256}&textureSizeLimit={(int) _resolution * 256}&morphTargets=none&useDracoMeshCompression=true&useHands=false";

                await gltfAsset.Load(src); 

                var started = Time.time;
                
                while (true) {
                    if (gltfHolder.transform.childCount > 0)
                        break;

                    if (Time.time > started + Timeout) {
                        LoadFailed(gltfAsset, gltfHolder, "Timeout");
                        return;
                    }

                    if (!Owner.IsVisible) {
                        LoadFailed(gltfAsset, gltfHolder, "Owner of the model is not visible anymore");
                        return;
                    }

                    await UniTask.Yield();
                }

                //Add the animator and assign the controller and avatar
                var animator = gltfHolder.AddComponent<Animator>();
                animator.runtimeAnimatorController = _runtimeAnimatorController;
                animator.avatar = _animationAvatar;
                gltfHolder.AddComponent<AnimatorParameters>();
                Owner.SetAvatar(gltfHolder);
                
                Debug.Log($"[RPMAvatarOperation] Loaded {src}");
            } finally {
                InvokeOnOperationCompleted();
            }
        }

        private void LoadFailed(GltfAsset gltfAsset, GameObject gltfHolder, string reason) {
            gltfAsset.Dispose();
            Object.Destroy(gltfHolder);
            Debug.LogWarning($"[RPMAvatarOperation] Failed to load {Owner.Src}, because {reason}. Skipped.");
            Owner.SetAvatar(null);
        }
    }
}