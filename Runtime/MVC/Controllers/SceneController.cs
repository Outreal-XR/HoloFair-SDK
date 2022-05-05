using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace outrealxr.holomod
{
    public class SceneController : MonoBehaviour
    {
        public string sceneName;
        [Tooltip("Must be a scene")]
        public AssetReference sceneAsset;

        public AsyncOperationHandle<SceneInstance> loadSceneAssetHandler;
        public static SceneController currentlyLoading;
        static SceneController currentlyUnloading;

        AsyncOperationHandle<SceneInstance> unloadSceneAssetHandler;
        SceneInstance sceneInstance;

        static Queue<SceneController> scenesToLoad = new Queue<SceneController>();
        static Queue<SceneController> scenesToUnload = new Queue<SceneController>();

        void Awake()
        {
            if (sceneAsset != null && string.IsNullOrWhiteSpace(sceneName)) sceneName = sceneAsset.RuntimeKey.ToString();
        }

        public void TryToLoadNext()
        {
            Debug.Log($"[SceneController - {gameObject.name}] Trying to load {sceneName}");
            if (!scenesToLoad.Contains(this)) scenesToLoad.Enqueue(this);
            else Debug.Log($"[SceneController - {gameObject.name}] {sceneName} already queued");
            if (currentlyLoading == null)
            {
                SceneLoadingView.instance.LoadingView.SetActive(true);
                LoadNext();
            }
            else
            {
                Debug.Log($"[SceneController - {gameObject.name}] Waiting for {currentlyLoading.sceneName} to load to continue loading {sceneName}");
            }
        }

        public void LoadNext()
        {
            currentlyLoading = scenesToLoad.Dequeue();
            currentlyLoading.Load();
        }

        public void Load()
        {
            loadSceneAssetHandler = Addressables.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            loadSceneAssetHandler.Completed += OnSceneLoadCompleted;
            SceneLoadingView.instance.current = this;
            Debug.Log($"[SceneController - {gameObject.name}] Loading {sceneName}");
        }

        void OnSceneLoadCompleted(AsyncOperationHandle<SceneInstance> arg)
        {
            if (arg.Status == AsyncOperationStatus.Succeeded)
            {
                sceneInstance = arg.Result;
                Debug.Log($"[SceneController - {gameObject.name}] Loaded {sceneName}: {sceneInstance.Scene.name}");
                currentlyLoading = null;
                if (scenesToLoad.Count > 0) LoadNext();
                else SceneLoadingView.instance.LoadingView.SetActive(false);
            }
        }

        public void TryToUnloadNext()
        {
            Debug.Log($"[SceneController - {gameObject.name}] Trying to unload {sceneName}");
            if (!scenesToUnload.Contains(this)) scenesToUnload.Enqueue(this);
            else Debug.Log($"[SceneController - {gameObject.name}] {sceneName} already queued");
            if (currentlyUnloading == null) UnloadNext();
            else Debug.Log($"[SceneController - {gameObject.name}] Waiting to unload {sceneName}");
        }

        public void UnloadNext()
        {
            currentlyUnloading = scenesToUnload.Dequeue();
            currentlyUnloading.Unload();
        }

        public void Unload()
        {
            unloadSceneAssetHandler = Addressables.UnloadSceneAsync(sceneInstance);
            unloadSceneAssetHandler.Completed += OnSceneUnloadCompleted;
            Debug.Log($"[SceneController - {gameObject.name}] Unloading {sceneName}");
        }

        void OnSceneUnloadCompleted(AsyncOperationHandle<SceneInstance> arg)
        {
            if (arg.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log($"[SceneController - {gameObject.name}] Unloaded {sceneName}");
                currentlyUnloading = null;
                if (scenesToUnload.Count > 0) UnloadNext();
            }
        }
    }
}