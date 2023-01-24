using UnityEngine;

namespace com.outrealxr.holomod
{
    public class SceneLoadingView : MonoBehaviour
    {
        [Tooltip("Required")]
        public GameObject View;
        [Tooltip("Optional")]
        public TMPro.TextMeshPro text;
        public string format = "{0:P2}";
        [Tooltip("Optional")]
        public UnityEngine.UI.Image image;

        public static SceneLoadingView instance;
        internal SceneController current;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            image.fillAmount = current == null || !current.loadSceneAssetHandler.IsValid() ? 0 : current.loadSceneAssetHandler.PercentComplete;
            text.text = SceneController.currentlyLoading ? string.Format(format, SceneController.currentlyLoading.sceneName, image.fillAmount) : "Waiting...";
        }

        public void SetProgress(float progress)
        {
            if (image) image.fillAmount = progress;
            if (text) text.text = string.Format(format, progress);
        }
    }
}