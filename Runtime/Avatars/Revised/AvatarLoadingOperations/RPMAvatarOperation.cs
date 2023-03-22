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

        [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
        [SerializeField] private UnityEngine.Avatar animationAvatar;
        [SerializeField] private float timeout = 60;

        public SupportedLOD lod = SupportedLOD.Low;
        public SupportedResolutions resolution = SupportedResolutions.Low;
        public Atlas atlasResolution = Atlas.LowRes;
        public const string GltfHolderName = "GLTF Holder";
        float started;

        public override void Handle(AvatarModel model) {
            IsRunning = true;
            StartCoroutine(LoadAvatar(model));
        }

        public override void Stop() {
            throw new System.NotImplementedException();
        }

        private IEnumerator LoadAvatar(AvatarModel model) {
            var gltfHolder = new GameObject(GltfHolderName);
            var gltfAsset = gltfHolder.AddComponent<GltfAsset>();

            string src = $"{model.src}?meshLoad={(int) lod}&textureAtlas={(int) atlasResolution * 256}&textureSizeLimit={(int) resolution * 256}&morphTargets=none&useDracoMeshCompression=true&useHands=false";

            yield return gltfAsset.Load(src);

            var started = Time.time;
            var reason = "";
            yield return new WaitWhile(() => WaitWhile(started, gltfHolder, model, out reason));
            if (gltfHolder.transform.childCount == 0) {
                gltfAsset.Dispose();
                Destroy(gltfHolder);
                Debug.LogError($"[RPMAvatarOperation] Failed to load {model.src}, because {reason}. Skipped.");
                IsRunning = false;
                model.SetAvatar(null);
                yield break;
            }

            //Add the animator and assign the controller and avatar
            var animator = gltfHolder.AddComponent<Animator>();
            animator.runtimeAnimatorController = runtimeAnimatorController;
            animator.avatar = animationAvatar;
            gltfHolder.AddComponent<AnimatorParameters>();
            model.SetAvatar(gltfHolder);

            Debug.Log($"[RPMAvatarOperation] Loaded {src}");
            IsRunning = false;
        }

        private bool WaitWhile(float started, GameObject gltfHolder, AvatarModel model, out string reason)
        {
            if (Time.time > started + timeout) {
                reason = "Timeout";
                return false;
            }
            
            if (gltfHolder.transform.childCount > 0) {
                reason = "Model ready";
                return false;
            }
            
            if (!model.IsVisible()) {
                reason = "View of the model is not visible anymore";
                return false;
            }
            
            reason = "";
            return true;
        }
    }
}