using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace com.outrealxr.holomod
{
    public class SceneController : MonoBehaviour
    {
        public string sceneName;
        [Tooltip("Must be a scene")]
        public AssetReference sceneAsset;

        public AsyncOperationHandle<SceneInstance> loadSceneAssetHandler;
        public static SceneController currentlyLoading;
        private static SceneController _currentlyUnloading;

        private AsyncOperationHandle<SceneInstance> _unloadSceneAssetHandler;
        private SceneInstance _sceneInstance;

        private static readonly Queue<SceneController> ScenesToLoad = new ();
        private static readonly Queue<SceneController> ScenesToUnload = new ();

        void Awake()
        {
            if (sceneAsset != null && string.IsNullOrWhiteSpace(sceneName)) sceneName = sceneAsset.RuntimeKey.ToString();
        }

        public static event Action<bool> OnSceneStateChange;
            
        public void TryToLoadNext()
        {
            Debug.Log($"[SceneController - {gameObject.name}] Trying to load {sceneName}");

            if (!ScenesToLoad.Contains(this) && !SceneManager.GetSceneByName(sceneName).isLoaded) 
                ScenesToLoad.Enqueue(this);
            
            else Debug.Log($"[SceneController - {gameObject.name}] {sceneName} already queued");
            if (currentlyLoading == null)
            {
                if (SceneLoadingView.instance)
                     SceneLoadingView.instance.View.SetActive(true);
                else Debug.LogWarning("[SceneController] SceneLoading view is missing. Don't worry, scene is still loading.");
                
                OnSceneStateChange?.Invoke(ScenesToLoad.Count == 0);
                LoadNext();
            }
            else
            {
                Debug.Log($"[SceneController - {gameObject.name}] Waiting for {currentlyLoading.sceneName} to load to continue loading {sceneName}");
            }
        }

        private void LoadNext() {
            currentlyLoading = ScenesToLoad.Dequeue();
            currentlyLoading.Load();
        }

        private void Load() {
            loadSceneAssetHandler = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            loadSceneAssetHandler.Completed += OnSceneLoadCompleted;
            
            if (SceneLoadingView.instance) SceneLoadingView.instance.current = this;
            else Debug.LogWarning("[SceneController] SceneLoading view is missing. Don't worry, scene is still loading.");

            Debug.Log($"[SceneController - {gameObject.name}] Loading {sceneName}");
        }

        [SerializeField] private UnityEvent OnSceneLoaded;

        private void OnSceneLoadCompleted(AsyncOperationHandle<SceneInstance> arg) {
            if (arg.Status == AsyncOperationStatus.Succeeded)
            {
                _sceneInstance = arg.Result;
                Debug.Log($"[SceneController - {gameObject.name}] Loaded {sceneName}: {_sceneInstance.Scene.name}");
                currentlyLoading = null;
                
                OnSceneStateChange?.Invoke(ScenesToLoad.Count == 0);

                if (ScenesToLoad.Count > 0) LoadNext();
                else {
                    if (SceneLoadingView.instance) SceneLoadingView.instance.View.SetActive(false);
                    else Debug.LogWarning("[SceneController] SceneLoading view is missing. Don't worry, scene is still loading.");
                }
                
                SceneManager.SetActiveScene(_sceneInstance.Scene);
            } else if (arg.Status == AsyncOperationStatus.Failed) {
                //Failed to load addressable

                
                Debug.LogWarning("[SceneController] It seems uploaded catalog file is newer, then uploaded target addressables. Please, try to clear your addressable build folder, update it and upload everything again to the same destination");
            }
        }

        public void TryToUnloadNext()
        {
            Debug.Log($"[SceneController - {gameObject.name}] Trying to unload {sceneName}");
            if (!ScenesToUnload.Contains(this)) ScenesToUnload.Enqueue(this);
            else Debug.Log($"[SceneController - {gameObject.name}] {sceneName} already queued");
            if (_currentlyUnloading == null) UnloadNext();
            else Debug.Log($"[SceneController - {gameObject.name}] Waiting to unload {sceneName}");
        }

        void UnloadNext()
        {
            _currentlyUnloading = ScenesToUnload.Dequeue();
            _currentlyUnloading.Unload();
        }

        void Unload()
        {
            _unloadSceneAssetHandler = Addressables.UnloadSceneAsync(_sceneInstance);
            _unloadSceneAssetHandler.Completed += OnSceneUnloadCompleted;
            Debug.Log($"[SceneController - {gameObject.name}] Unloading {sceneName}");
        }

        void OnSceneUnloadCompleted(AsyncOperationHandle<SceneInstance> arg)
        {
            if (arg.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log($"[SceneController - {gameObject.name}] Unloaded {sceneName}");
                _currentlyUnloading = null;
             
                if (ScenesToUnload.Count > 0) UnloadNext();
            }
        }
    }
}