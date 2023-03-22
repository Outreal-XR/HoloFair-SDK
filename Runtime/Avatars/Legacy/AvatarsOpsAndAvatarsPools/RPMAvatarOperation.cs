using System.Collections;
using GLTFast;
using UnityEngine;

namespace com.outrealxr.avatars
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

        [SerializeField] private string defaultKey = "yBot";
        private Coroutine _coroutine;

        [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
        [SerializeField] private AddressableAvatarOperation addressableAvatarOperation;

        [SerializeField] private UnityEngine.Avatar animationAvatar;
        [SerializeField] private float timeout = 60;

        public SupportedLOD lod = SupportedLOD.Low;
        public SupportedResolutions resolution = SupportedResolutions.Low;
        public Atlas atlasResolution = Atlas.LowRes;
        public const string GltfHolderName = "GLTF Holder";

        public override void Handle(AvatarModel model, string src) {
            _coroutine = StartCoroutine(LoadAvatar(model, src));
        }

        private IEnumerator LoadAvatar(AvatarModel model, string src) {
            var gltfHolder = new GameObject(GltfHolderName);
            var gltfAsset = gltfHolder.AddComponent<GltfAsset>();
            
            gltfHolder.transform.SetParent(model.transform);
            gltfHolder.transform.localPosition = Vector3.zero;

            src += $"?meshLoad={(int) lod}&textureAtlas={(int) atlasResolution * 256}&textureSizeLimit={(int) resolution * 256}&morphTargets=none&useDracoMeshCompression=true&useHands=false";
            model.src = src;

            var handle = gltfAsset.Load(src);
            yield return handle;

            var started = Time.time;
            yield return new WaitWhile(() => Time.time <= started + timeout && gltfHolder.transform.childCount == 0);
            if (gltfHolder.transform.childCount == 0) {
                gltfAsset.Dispose();
                Destroy(gltfHolder.gameObject);
                OnLoadFailed(model);
                yield break;
            }

            //Add the animator and assign the controller and avatar
            var animator = gltfHolder.AddComponent<Animator>();
            animator.runtimeAnimatorController = runtimeAnimatorController;
            animator.avatar = animationAvatar;
            
            var avatar = gltfHolder.AddComponent<Avatar>();
            avatar.SetOwner(model);
            avatar.type = AvatarsProvider.instance.avatarLoadingOperations.IndexOf(this);

            gltfHolder.AddComponent<AnimatorParameters>();

            Debug.Log($"[RPMAvatarOperation] Loaded {model.src}");
            model.Complete(avatar);
        }

        private void OnLoadFailed(AvatarModel model) {
            Debug.Log($"[RPMAvatarOperation] Failed to load {model.src}. Using {defaultKey} instead with addressable avatars.");
            addressableAvatarOperation.Handle(model, defaultKey);
        }

        public override void Stop() {
            StopCoroutine(_coroutine);
        }
    }
}