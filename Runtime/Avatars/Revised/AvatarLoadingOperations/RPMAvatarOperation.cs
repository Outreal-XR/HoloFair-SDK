using System.Collections;
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

        private RuntimeAnimatorController runtimeAnimatorController;
        private UnityEngine.Avatar animationAvatar;
        private float timeout = 60;

        private SupportedLOD _lod = SupportedLOD.Low;
        private SupportedResolutions resolution = SupportedResolutions.Low;
        private Atlas atlasResolution = Atlas.LowRes;
        private const string GltfHolderName = "GLTF Holder";
        float started;

        public override void Handle(AvatarOwner owner) {
            LoadAvatar(owner);
        }

        public override void Stop() {
            throw new System.NotImplementedException();
        }

        private async void LoadAvatar(AvatarOwner owner) {
            var gltfHolder = new GameObject(GltfHolderName);
            var gltfAsset = gltfHolder.AddComponent<GltfAsset>();

            var src = $"{owner.Src}?meshLoad={(int) _lod}&textureAtlas={(int) atlasResolution * 256}&textureSizeLimit={(int) resolution * 256}&morphTargets=none&useDracoMeshCompression=true&useHands=false";

            await gltfAsset.Load(src);

            var started = Time.time;
            var reason = "";
            
            //await new WaitWhile(() => WaitWhile(started, gltfHolder, owner, out reason));
            
            if (gltfHolder.transform.childCount == 0) {
                gltfAsset.Dispose();
                Object.Destroy(gltfHolder);
                Debug.LogError($"[RPMAvatarOperation] Failed to load {owner.Src}, because {reason}. Skipped.");
                owner.SetAvatar(null);
                return;
            }

            //Add the animator and assign the controller and avatar
            var animator = gltfHolder.AddComponent<Animator>();
            animator.runtimeAnimatorController = runtimeAnimatorController;
            animator.avatar = animationAvatar;
            gltfHolder.AddComponent<AnimatorParameters>();
            owner.SetAvatar(gltfHolder);

            Debug.Log($"[RPMAvatarOperation] Loaded {src}");
        }

        private bool WaitWhile(float started, GameObject gltfHolder, AvatarOwner owner, out string reason)
        {
            if (Time.time > started + timeout) {
                reason = "Timeout";
                return false;
            }
            
            if (gltfHolder.transform.childCount > 0) {
                reason = "Model ready";
                return false;
            }
            
            if (!owner.IsVisible) {
                reason = "View of the model is not visible anymore";
                return false;
            }
            
            reason = "";
            return true;
        }
    }
}